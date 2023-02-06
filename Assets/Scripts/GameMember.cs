using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using UnityEngine.Events;
using UnityEngine.EventSystems;

using SocketIO;
using TMPro;
public class GameMember {

    public string playerID;
    public int cardLeft;
    public int rank;
    public bool isComplete;
    public bool isMaster;
    public bool isTurn;

    



    public GameMember(JSONObject res)
    {
        playerID = res.GetString("id");
    }

    void setMemberData(JSONObject res){

    }
    
}