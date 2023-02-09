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
public class GameMember {

    [CanBeNull] public string uuid;
    public int? cardLeft;
    public int? rank;
    public bool? isComplete;
    public bool isAdmin;
    public bool? isTurn;

    



    public GameMember(JSONObject res)
    {
        
        var uuid = res.GetString("uuid");

        if (uuid is null)
        {
            var id  = res.GetInt("uuid");
            if (id is not null)
            {
                uuid = (string)(id+"");
            }
        }
        
        this.uuid = uuid;
        
        isAdmin = res.GetBool("isAdmin") ?? false;
        


    }

    void setMemberData(JSONObject res){
        
    }
    
}