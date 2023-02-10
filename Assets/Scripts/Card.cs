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
    public int value;
    public int shape;
    public int type;
    public int atk;

    public Card(JSONObject card)
    {
        this.id = card.GetInt("id") ?? -1;
        this.value = card.GetInt("value") ?? -1;
        this.shape = card.GetInt("shape") ?? -1;
        this.type = card.GetInt("type") ?? -1;
        this.atk = card.GetInt("atk") ?? -1;
    }

}