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
    public UIController ui;


    private JSONObject memberData = null;

    //여기서 게임 관련된 데이터 관리 필요 할 듯 ?

    public string myID;
    
    public bool isGameStarted = false;
    public int headCount = 0; //플레이어 수

    public List<Card> myHand; //내 핸드

    public int curTurn;

    public Card currentCard;
    
    

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

    public void onJoinRoom(JSONObject res){
        PlayerContainer.instance.joinMember(res.GetField("player"));

        ui.refreshUser();
    }

    public void onExitRoom(JSONObject res)
    {
        var target = res.GetField("player");
        
        var uuid = target.GetValue("uuid");
        
        PlayerContainer.instance.removeMember(uuid);

        ui.refreshUser();
    }

    public void onStartGame(JSONObject res)
    {
        Debug.Log("onStartGame "+res);
        var myCards = res.GetField("yourHand");
        myHand = new List<Card>();
        
        for (var i = 0; i < myCards.Count; i++)
        {
            myHand.Add(new Card(myCards[i]));
        }

        
        ui.setMyHand(myHand);

    }
    
    public void onYourTurn(JSONObject res){
                
        currentCard = new Card(res.GetField("currentCard"));
        ui.setDequeCard(currentCard);
        
    }

    public void onUseResult(JSONObject res){
        
    }

    public void onSomeoneWin(JSONObject res){
        
    }
    public void onEndGame(JSONObject res){
        
    }

}