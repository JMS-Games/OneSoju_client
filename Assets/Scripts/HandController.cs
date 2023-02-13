using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using UnityEngine.Events;
using UnityEngine.EventSystems;

using SocketIO;
using TMPro;
using UnityEditor;

public class HandController : MonoBehaviour
{
    private List<Card> cardList = new List<Card>();
    HandController(){
        
    }

    void Awake(){
        
    }

    void Start(){
        
    }

    public void setUI(List<Card> cards)
    {
        foreach (Transform child in this.transform)
        {
            Destroy(child);
        }

        var res = Resources.Load("Card");

        var count = 0;
        foreach (var card in cards)
        {
            var inst = Util.getInstByRes(res);
            inst.transform.SetParent(this.transform);
            var con = inst.GetComponent<CardController>();
            con.setCard(card);
            count++;
            con.transform.localPosition =
                new Vector3(
                    -this.GetComponent<RectTransform>().rect.width / 2 +
                    con.GetComponent<RectTransform>().rect.width / 2 + count * 30, 0, 0);

        }
    }

    

}