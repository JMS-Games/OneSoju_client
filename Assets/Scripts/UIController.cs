using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using UnityEngine;
using UnityEngine.UI;

using UnityEngine.Events;
using UnityEngine.EventSystems;

using SocketIO;
using TMPro;
using Unity.VisualScripting;

public class UIController : MonoBehaviour {

    Button btnDraw;
    Button btnExit;
    private Button btnStart;

    private PlayerContainer container;
    UIController(){

    }

    void Awake(){
        var canvas = this.transform;

        this.btnDraw = canvas.Find("btnDraw").GetComponent<Button>();
        this.btnExit = canvas.Find("btnExit").GetComponent<Button>();
        this.btnStart = canvas.Find("btnStart").GetComponent<Button>();

        this.btnStart.gameObject.SetActive(false);
        
        var my = PlayerContainer.instance.getMine();
        if (my.isAdmin)
        {
            this.btnStart.gameObject.SetActive(true);
        }
        
        this.initBtn();

        container = GameObject.Find("PlayerContainer").GetComponent<PlayerContainer>();
    }

    void initBtn(){
        this.btnDraw.onClick.AddListener(delegate{onBtnDrawClick();});
        this.btnExit.onClick.AddListener(delegate{onBtnExitClick();});
        this.btnStart.onClick.AddListener(delegate { onBtnStartClick();});
        

    }

    void onBtnStartClick(){
        //내가 방장인지 체크 필요
        var my = PlayerContainer.instance.getMine();
        if (!my.isAdmin)
        {
            return;
        }
        
        SocketManager.instance.requestSync(Sig.START_GAME, new {}, (res) =>
        {
            if (Util.checkError(res))
            {
                PopupController.instance.showPopup("start error");
                return;
            }
            this.btnStart.gameObject.SetActive(false);
        });
    }
    
    void onBtnDrawClick(){
        SocketManager.instance.requestSync(Sig.DRAW_CARD, new {}, (res) =>
        {
            
        });
    }

    void onBtnExitClick(){
        SocketManager.instance.requestSync(Sig.EXIT_ROOM, new {}, (res) =>
        {
            SceneManager.instance.changeScene("Main");
            SocketManager.instance.disconnect();
        });
    }

    public void refreshUser()
    {
        Debug.Log("refresh user "+container.getSize());
    }
    void Start(){

    }

    

}