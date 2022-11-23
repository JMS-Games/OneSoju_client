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

        ui = this.transform.parent.Find("Canvas").GetComponent<UIController>();
        
    }
    
    void Start(){

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