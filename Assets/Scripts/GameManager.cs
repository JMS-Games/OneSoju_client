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

    }

    public void AwakeGameManager()
    {
        ui = GameObject.Find("Canvas").GetComponent<UIController>();

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
    }

    public void onExitRoom(JSONObject res){

    }

    public void onYourTurn(JSONObject res){

    }

    public void onUseResult(JSONObject res){

    }

    

}