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
using Unity.VisualScripting.Antlr3.Runtime;

[System.Serializable]
public class GameMember
{

    public string id;
    public string uuid;
    public string roomID;

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
        this.updateMemberData(res);
    }

    public void updateMemberData(JSONObject res){
        var uuid = res.GetValue("uuid");
        
        this.uuid = uuid;
        
        var id = res.GetValue("id");
        
        this.id = id;


        this.roomID = res.GetValue("roomID");
        this.isAdmin = res.GetBool("isAdmin") ?? false;
        this.isTurn = res.GetBool("isTurn") ?? false;

        var hand = res.GetField("hand");
        this.hand = new List<Card>();
        
        for (var i = 0; i < hand.Count; i++)
        {
            var card = new Card(hand[i]);
            this.hand.Add(card);
        }

        this.leftHand = res.GetInt("leftHand") ?? -1;
        this.rank = res.GetInt("rank") ?? -1;

        this.onPlaying = res.GetBool("onPlaying") ?? false;


    }
    
}