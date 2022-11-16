using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using SocketIO;
using TMPro;
public class PlayerPanelController : MonoBehaviour {

    public int playerID;
    public int playerRank;
    public bool isComplete;
    public bool isMaster;
    public bool isTurn;
    public int leftTime;
    public int leftCard;
    

    


    Image imgPlayer;
    Image imgTurn;
    List<Image> imgRank = new List<Image>();

    TextMeshProUGUI lbPlayerName;
    TextMeshProUGUI lbCardLeft;
    TextMeshProUGUI lbRank;


    PlayerPanelController(){

    }

    public void setData(JSONObject data){
        this.playerID = data.GetField("playerID") != null ? data.GetField("playerID").i : this.playerID;
        this.playerRank = data.GetField("playerRank") != null ? data.GetField("playerRank").i : this.playerRank;
        this.isComplete = data.GetField("isComplete") != null ? data.GetField("isComplete").b : this.isComplete;
        this.isMaster = data.GetField("isMaster") != null ? data.GetField("isMaster").b : this.isMaster;
        this.isTurn = data.GetField("isTurn") != null ? data.GetField("isTurn").b : this.isTurn;
        this.leftTime = data.GetField("leftTime") != null ? data.GetField("leftTime").i : this.leftTime;
        this.leftCard = data.GetField("leftCard") != null ? data.GetField("leftCard").i : this.leftCard;

        this.setUI();
    }

    void Awake(){
        var canvas = this.transform.Find("Canvas");

        this.imgPlayer = canvas.Find("imgPlayer").GetComponent<Image>();
        this.imgTurn = canvas.Find("imgTurn").GetComponent<Image>();

        for(int i = 0; i<4;i++){
            var imgRank = canvas.Find("imgRank"+(i+1)).GetComponent<Image>();
            this.imgRank.Add(imgRank);
        }

        this.lbPlayerName = canvas.Find("lbPlayerName").GetComponent<TextMeshProUGUI>();
        this.lbCardLeft = canvas.Find("lbCardLeft").GetComponent<TextMeshProUGUI>();
        this.lbRank = canvas.Find("lbRank").GetComponent<TextMeshProUGUI>();
    }
    
    
    void Start(){
        
    }

    void setUI(){

    }

    

}