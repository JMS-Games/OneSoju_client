using System;
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.UI;

using UnityEngine.Events;
using UnityEngine.EventSystems;

using SocketIO;
using TMPro;
public class GameMember
{

    public string id;
    public string uuid;
    public int roomID;

    // public int cardLeft;
    // public bool isComplete;
    public bool isAdmin;

    public bool isTurn;
    
    public List<Card> hand;
    public int leftHand;
    public int rank;

    public bool onPlaying;
    
    



    public GameMember(JSONObject res)
    {
        
        var uuid = res.GetValue("uuid");
        
        this.uuid = uuid;
        
        isAdmin = res.GetBool("isAdmin") ?? false;
        


    }

    void setMemberData(JSONObject res){
        
    }
    
}