using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using SocketIO;
using TMPro;
public class Card
{


    public int? id;
    public int? value;
    public int? shape;
    public int? type;
    public int? atk;

    Card(JSONObject card)
    {
        this.id = card.GetInt("id");
        this.value = card.GetInt("value");
        this.shape = card.GetInt("shape");
        this.type = card.GetInt("type");
        this.atk = card.GetInt("atk");
    }

}