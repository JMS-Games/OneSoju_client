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

    }
    
    void Start(){
    
    }

    public GameMember getMemberByID(int id){
        foreach(GameMember m in container){
            if(m.playerID == id){
                return m;
            }
        }
        return null;
    }
    public void removeMember(int targetID){
        var m = this.getMemberByID(targetID);
        if(m != null){
            this.container.Remove(m);
        }
    }

    public void joinMember(JSONObject res){
        int playerID = res.GetField("playerID").i;
        GameMember m = new GameMember(res);

        this.container.Add(m);
    }
}