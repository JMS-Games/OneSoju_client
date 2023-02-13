using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using SocketIO;
using TMPro;
public class Card
{


    public int id;
    public string value;
    public string shape;
    public int type;
    public int atk;

    public Card(JSONObject card)
    {
        this.id = card.GetInt("id") ?? -1;
        this.value = card.GetString("value") ?? "";
        this.shape = card.GetString("shape") ?? "";
        this.type = card.GetInt("type") ?? -1;
        this.atk = card.GetInt("atk") ?? -1;
    }

}