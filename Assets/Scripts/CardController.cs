using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using SocketIO;
using TMPro;
using Unity.VisualScripting;
using UnityEngine.EventSystems;

public class CardController : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler, IDropHandler {

    public int cardNum;

    public Image imgCard;
    public TextMeshProUGUI lbText;
    public TextMeshProUGUI lbMark;
    
    public Card card;

    public bool touchEnable = false;
    public bool isDragging = false;
    
    CardController(int cardNum){
        this.cardNum = cardNum;
    }

    public void setCardNum(int cardNum){
        this.cardNum = cardNum;
        this.initUI();
        
    }

    public void setCard(Card card)
    {
        Debug.Log("setCard "+card);
        this.card = card;
        this.cardNum = (int)card.id;
        this.initUI();
    }
    
    void initUI(){
        string shape = "";

        switch(this.card.shape){
            case "SPADE":
                shape = "♠";
                break;
            case "DIAMOND":
                shape = "♦";
                break;
            case "HEART":
                shape = "♥";
                break;
            case "CLOVER":
                shape = "♣";
                break;
            default:
                shape = "JOKER";
                break;
        }

        string num = this.card.value+"";



        lbText.SetText(shape+"\n"+num);
        lbMark.SetText(shape+"");

        if (this.card.shape == "HEART" || this.card.shape == "DIAMOND")
        {
            lbText.color = Color.red;
            lbMark.color = Color.red;
        }

    }
    void Awake(){
        imgCard = this.transform.Find("imgCard").GetComponent<Image>();
        lbText = this.transform.Find("lbCard").GetComponent<TextMeshProUGUI>();
        lbMark =  this.transform.Find("lbMark").GetComponent<TextMeshProUGUI>();
    }
    
    
    void Start(){
        //imgCard.sprite = 
        this.initUI();
        
    }


    public void OnBeginDrag(PointerEventData eventData)
    {
        if (!touchEnable)
        {
            return;
        }
        GameManager.instance.ui.handController.onBeginDrag(eventData, this);
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (!touchEnable)
        {
            return;
        }
        GameManager.instance.ui.handController.onDrag(eventData, this);

    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (!touchEnable)
        {
            return;
        }
        GameManager.instance.ui.handController.onEndDrag(eventData, this);

    }
    
    public void OnDrop(PointerEventData eventData)
    {
        if (!touchEnable)
        {
            return;
        }
        GameManager.instance.ui.handController.onDrop(eventData, this);

    }

  
    
}