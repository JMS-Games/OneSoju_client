using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using SocketIO;
using TMPro;
public class PlayerPanelController : MonoBehaviour
{
    private GameMember m;
    


    Image imgPlayer;
    Image imgTurn;
    List<Image> imgRank = new List<Image>();

    TextMeshProUGUI lbPlayerName;
    TextMeshProUGUI lbCardLeft;
    TextMeshProUGUI lbRank;


    PlayerPanelController(){

    }

    public void setData(GameMember m)
    {
        this.m = m;
        
        this.setUI();
    }

    void Awake(){
        var canvas = this.transform;

        this.imgPlayer = canvas.Find("imgPlayer").GetComponent<Image>();
        this.imgTurn = canvas.Find("imgTurn").GetComponent<Image>();

        for(int i = 0; i<4;i++){
            var imgRank = canvas.Find("imgRank"+(i+1)).GetComponent<Image>();
            this.imgRank.Add(imgRank);
        }

        this.lbPlayerName = canvas.Find("lbPlayerName").GetComponent<TextMeshProUGUI>();
        this.lbCardLeft = canvas.Find("lbCardLeft").GetComponent<TextMeshProUGUI>();
        this.lbRank = canvas.Find("lbRank").GetComponent<TextMeshProUGUI>();

        this.transform.localPosition = new Vector3(0, 0,0);
    }
    
    
    void Start(){
        this.transform.localPosition = new Vector3(0, 0,0);

    }

    void setUI(){
        lbPlayerName.SetText(m.uuid);
        lbCardLeft.SetText(m.leftHand+"");
        lbRank.SetText(m.rank+"");
        imgTurn.gameObject.SetActive(m.isTurn);
        
        
    }

    

}