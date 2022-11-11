using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using SocketIO;
using TMPro;
public class CardController : MonoBehaviour {

    public int cardNum;

    Image imgCard;
    TextMeshProUGUI text;

    CardController(int cardNum){
        this.cardNum = cardNum;
    }

    public void setCardNum(int cardNum){
        this.cardNum = cardNum;
        this.initUI();
    }

    void initUI(){

        string shape = "";

        switch(this.cardNum/13){
            case 0:
                shape = "♠";
                break;
            case 1:
                shape = "♦";
                break;
            case 2:
                shape = "♥";
                break;
            case 3:
                shape = "♣";
                break;
            case 4:
                shape = "JOKER";
                break;
        }

        string num = this.cardNum%13+"";



        text.SetText(shape+" "+num);
    }
    void Awake(){
        imgCard = this.transform.Find("Canvas").Find("Image").GetComponent<Image>();
        text = this.transform.Find("Canvas").Find("lbCard").GetComponent<TextMeshProUGUI>();
    }
    
    
    void Start(){
        //imgCard.sprite = 
        this.initUI();
    }

    

}