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

    public string myID;




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
        
        // GameManager.instance.AwakeGameManager();

        // this.initMember();

    }
    
    public void clear()
    {
        myID = null;
        container.Clear();

    }

    public void setMyID(string myID)
    {
        this.myID = myID;
    }

    public void initMember(JSONObject res)
    {
        for(var i = 0; i<res.Count; i++){
            this.joinMember(res[i]);
        }
        
    }
    void Start(){
    
    }

    public GameMember getMemberByID(string id){
        foreach(GameMember m in container){
            if(m.uuid == id){
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

    public void updateMember(JSONObject res)
    {
        Debug.Log("player container updateMember"+res);
        var uuid = res.GetValue("uuid");
        
        if (uuid is not null)
        {

            if (getMemberByID(uuid) is not null)
            {
                Debug.Log("update member "+uuid);

                var m = getMemberByID(uuid);
                m.updateMemberData(res);
            }
            
        }

    }
    public void joinMember(JSONObject res){
        Debug.Log("player container joinMember"+res);
        var uuid = res.GetValue("uuid");
        
        if (uuid is not null)
        {

            if (getMemberByID(uuid) is null)
            {
                GameMember m = new GameMember(res);
                this.container.Add(m);
            
                Debug.Log("join member complete "+uuid);

            }
            else
            {
                Debug.Log("already exist, update"+uuid);

                var m = getMemberByID(uuid);
                m.updateMemberData(res);
            }
            
        }

    }

    public int getSize()
    {
        return this.container.Count;
    }

    public GameMember getMine()
    {
        Debug.Log("get Mine ");
        foreach(GameMember m in container){
            Debug.Log(m.uuid + " / " + this.myID);
            if(m.uuid == this.myID){
                return m;
            }
        }

        return null;
    }

    public List<GameMember> getMemberList()
    {
        return this.container;
    }
}