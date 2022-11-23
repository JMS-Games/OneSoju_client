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

    public int playerID;
    public int cardLeft;
    public int rank;
    public bool isComplete;
    public bool isMaster;
    public bool isTurn;

    



    public GameMember(JSONObject res){
        
    }

    void setMemberData(JSONObject res){

    }
    
}