using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using UnityEngine.Events;
using UnityEngine.EventSystems;

using SocketIO;
using TMPro;
public class OneSojuUIController : MonoBehaviour {

    Button btnEndTurn;
    Button btnExit;
    OneSojuUIController(){

    }

    void Awake(){
        var canvas = this.transform;

        this.btnEndTurn = canvas.Find("btnEndTurn").GetComponent<Button>();
        this.btnExit = canvas.Find("btnExit").GetComponent<Button>();


        this.initBtn();
    }

    void initBtn(){
        this.btnEndTurn.onClick.AddListener(delegate{onBtnEndTurnClick();});
        this.btnExit.onClick.AddListener(delegate{onBtnExitClick();});
    }

    void onBtnEndTurnClick(){

    }

    void onBtnExitClick(){

    }    
    
    void Start(){

    }

    

}