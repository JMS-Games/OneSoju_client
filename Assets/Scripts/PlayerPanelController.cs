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
    Image[] imgRank;

    TextMeshProUGUI lbPlayerName;
    TextMeshProUGUI lbCardLeft;
    TextMeshProUGUI lbRank;


    PlayerPanelController(){

    }

    public void setCardNum(int cardNum){
        this.initUI();
        
    }

    void initUI(){


    }
    void Awake(){
    }
    
    
    void Start(){
        //imgCard.sprite = 
        this.initUI();
    }

    

}