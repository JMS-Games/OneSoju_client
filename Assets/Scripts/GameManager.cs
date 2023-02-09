using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using UnityEngine.Events;
using UnityEngine.EventSystems;

using SocketIO;
using TMPro;
public class GameManager : MonoBehaviour {

    public static GameManager instance = null;
    UIController ui;


    private JSONObject memberData = null;

    //여기서 게임 관련된 데이터 관리 필요 할 듯 ?

    public string myID;
    
    public bool isGameStarted;
    public int headCount; //플레이어 수

    public JSONObject myHand; //내 핸드

    public int curTurn; 
    
    

    GameManager(){
        
    }

    void Awake(){
        if(instance == null){
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else {
            Destroy(this.gameObject);
        }

        
    }
    
    void Start(){
        if (ui is not null)
        {
            ui.refreshUser();
        }
    }

    public void clear()
    {
        
    }

    public void AwakeGameManager()
    {
        ui = GameObject.Find("Canvas").GetComponent<UIController>();

    }
    public void setMyInfo(JSONObject res)
    {
        
        this.myID = res.GetString("uuid");
        if (this.myID is null)
        {
            var id  = res.GetInt("uuid");
            if (id is not null)
            {
                this.myID = (string)(id+"");
            }
        }

        PlayerContainer.instance.setMyID(this.myID);
        
        Debug.Log("my info "+res.GetField("uuid")+"/"+this.myID);
    }
    public void setMemberData(JSONObject res)
    {
        // List<GameMember> m = new List<GameMember>();
        //
        // var p = res.GetField("players");
        // for (var i = 0; i < p.Count;i++)
        // {
        //     GameMember mm = new GameMember(p[i]);
        //     m.Add(mm);
        // }

        this.memberData = res;
        
        Debug.Log("memberData "+this.memberData);
    }

    public JSONObject getInitMember()
    {
        return this.memberData;
    }

    public void onJoinRoom(JSONObject res){
        PlayerContainer.instance.joinMember(res);

        ui.refreshUser();
    }

    public void onExitRoom(JSONObject res){

    }

    public void onYourTurn(JSONObject res){

    }

    public void onUseResult(JSONObject res){

    }

    

}