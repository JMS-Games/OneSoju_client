using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SocketIO;
using TMPro;
public class DispatchEventManager : MonoBehaviour {
    public static DispatchEventManager instance = null;

    void Awake(){
        
        if(instance == null){
            instance = this;
            DontDestroyOnLoad(this.gameObject);
            
        } else {
            Destroy(this.gameObject);
        }



    }

    public void setRoomSceneUI(JSONObject data){
        foreach(Transform child in GameObject.Find("Content").transform){
            GameObject.Destroy(child.gameObject);
        }

        GameObject svObject = GameObject.Find("Canvas").transform.Find("svObject").gameObject;
        for(var i = 0; i<data.Count; i++){
            JSONObject tempData = data[i];
            // room.roomtitle;
            // room.playerCount;
            // room.status; //0 : 대기중, 1 : 꽉 참, 2 : 플레이 중
            GameObject roomUI = GameObject.Instantiate(svObject, Vector3.zero, Quaternion.identity);

            roomUI.transform.Find("roomname").GetComponent<TMP_Text>().text = tempData.GetField("roomtitle").str;
            roomUI.transform.Find("humanCount").GetComponent<TMP_Text>().text = tempData.GetField("playerCount").f.ToString();
            roomUI.transform.SetParent(GameObject.Find("Content").transform, false);

            roomUI.SetActive(true);

            // roomUI.transform.position = new Vector3(roomUI.transform.position.x+50, roomUI.transform.position.y, 0);

        }
    }
    

}