using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using UnityEngine.Events;
using UnityEngine.EventSystems;

using SocketIO;
using TMPro;
public class GameManager : MonoBehaviour {

    public static GameManager instance = null;
    UIController ui;
    GameManager(){

    }

    void Awake(){
        if(instance == null){
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else {
            Destroy(this.gameObject);
        }

        ui = this.GetComponent<UIController>();

        
    }
    
    void Start(){

    }

    

}