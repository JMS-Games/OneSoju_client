using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
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

    private Transform posMe;
    
    private Transform posPlayer1;
    private Transform posPlayer2;
    private Transform posPlayer3;
    
    private Transform posHand;
    private Transform posDeque;
    private Transform posSideDeque;
    
    
    UIController(){

    }

    void Awake(){
        if (PlayerContainer.instance is null)
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene("Main");
            return;
        }
        var canvas = this.transform;

        this.btnDraw = canvas.Find("btnDraw").GetComponent<Button>();
        this.btnExit = canvas.Find("btnExit").GetComponent<Button>();
        this.btnStart = canvas.Find("btnStart").GetComponent<Button>();

        this.btnStart.gameObject.SetActive(false);
        this.btnDraw.gameObject.SetActive(false);
        
        var my = PlayerContainer.instance.getMine();
        if (my.isAdmin)
        {
            this.btnStart.gameObject.SetActive(true);
        }
        
        this.initBtn();

        container = GameObject.Find("PlayerContainer").GetComponent<PlayerContainer>();


        posMe = canvas.Find("posMe");
        
        posPlayer1 = canvas.Find("posPlayer1");
        posPlayer2 = canvas.Find("posPlayer2");
        posPlayer3= canvas.Find("posPlayer3");
        
        posHand = canvas.Find("posHand");
        posDeque = canvas.Find("posDeque");
        posSideDeque = canvas.Find("posSideDeque");
        
        GameManager.instance.AwakeGameManager();

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

    void onBtnExitClick()
    {
        SocketManager.instance.canShowSubloading = false;
        SocketManager.instance.disconnect();
        SceneManager.instance.changeScene("Main");
    }

    public void refreshUser()
    {
        Debug.Log("refresh user "+container.getSize());
        var pCount = 0;
        Transform target = null;
        
        var panel = Resources.Load("PlayerPanel");

        foreach (Transform child in posPlayer1)
        {
            Destroy(child.gameObject);
        }
        foreach (Transform child in posPlayer2)
        {
            Destroy(child.gameObject);
        }        
        foreach (Transform child in posPlayer3)
        {
            Destroy(child.gameObject);
        }
        
        foreach (var m in container.getMemberList())
        {
            Debug.Log("m = "+m.uuid);
            if (container.getMine() == m)
            {
                target = posMe;
            }
            else
            {
                switch (pCount)
                {
                    case 0:
                        target = posPlayer1;
                        break;
                    case 1:
                        target = posPlayer2;
                        break;
                    case 2:
                        target = posPlayer3;
                        break;
                }
                pCount++;
            }

            Debug.Log(pCount +" / "+target.name);
            foreach (Transform child in target)
            {
                Destroy(child.gameObject);
            }
            
            var inst = (GameObject) GameObject.Instantiate( panel , Vector3.zero, Quaternion.identity);
            inst.transform.SetParent(target);

            var con = inst.GetComponent<PlayerPanelController>();

            con.setData(m);


        }
    }
    void Start(){
        this.refreshUser();
    }

    

}