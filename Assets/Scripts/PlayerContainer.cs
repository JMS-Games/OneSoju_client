using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using UnityEngine.Events;
using UnityEngine.EventSystems;

using SocketIO;
using TMPro;
public class PlayerContainer : MonoBehaviour {

    public static PlayerContainer instance = null;

    List<GameMember> container = new List<GameMember>();




    PlayerContainer(){

    }

    void Awake(){
        if(instance == null){
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else {
            Destroy(this.gameObject);
        }
        
        GameManager.instance.AwakeGameManager();

        this.initMember();

    }

    void initMember()
    {
        var memberList = GameManager.instance.getInitMember();
        
        for(var i = 0; i<memberList.Count; i++){
            this.joinMember(memberList[i]);
        }
    }
    void Start(){
    
    }

    public GameMember getMemberByID(string id){
        foreach(GameMember m in container){
            if(m.playerID == id){
                return m;
            }
        }
        return null;
    }
    public void removeMember(string targetID){
        var m = this.getMemberByID(targetID);
        if(m != null){
            this.container.Remove(m);
        }
    }

    public void joinMember(JSONObject res){
        var playerID = res.GetInt("id");
        if (playerID is not null)
        {
            GameMember m = new GameMember(res);
            this.container.Add(m);

        }

    }
}