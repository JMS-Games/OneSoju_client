using System;
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.UI;

using UnityEngine.Events;
using UnityEngine.EventSystems;

using TMPro;
public class PopupController : MonoBehaviour {

    public static PopupController instance = null;

    public TextMeshProUGUI lbText;
    public Button btnOk;

    public Canvas canvas;
    PopupController(){
        
    }

    void Awake(){
        if(instance == null){
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else {
            Destroy(this.gameObject);
        }
        this.canvas = this.transform.Find("Canvas").GetComponent<Canvas>();
        this.lbText = this.canvas.transform.Find("lbText").GetComponent<TextMeshProUGUI>();
        this.btnOk = this.canvas.transform.Find("btnOk").GetComponent<Button>();


        this.canvas.gameObject.SetActive(false);

        
    }

    public void showPopup(string content, Action cb){
        this.canvas.gameObject.SetActive(true);
        this.lbText.text = content;
        this.btnOk.onClick.RemoveAllListeners();
        this.btnOk.onClick.AddListener(()=>{
            this.canvas.gameObject.SetActive(false);

            cb();
            
        });
    }
    

    public void showPopup(string content){
        this.canvas.gameObject.SetActive(true);
        this.lbText.text = content;
        this.btnOk.onClick.RemoveAllListeners();
        this.btnOk.onClick.AddListener(()=>{
            this.canvas.gameObject.SetActive(false);
        });
    }

    

    

}