using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class ButtonEvent : MonoBehaviour {

    public void onMultiPlayClick(){
        SocketManager.instance.connect();

        PlayerContainer.instance.clear();
        GameManager.instance.clear();
        
        SocketManager.instance.canShowSubloading = true;

        StartCoroutine(SocketManager.instance.subLoadingUntilConnect(()=>{
            SocketManager.instance.requestSync(Sig.REQUEST_MATCH,
            new { uuid = SystemInfo.deviceUniqueIdentifier }, (res)=>
            {
                PlayerContainer.instance.initMember(res.GetField("players"));
                GameManager.instance.setMyInfo(res.GetField("myInfo"));
                
                SceneManager.instance.changeScene("OneSoju");
                Debug.Log("request match res "+res);
            });
    }));
    }


    IEnumerator checkSocket(float timeout){
        SubLoading.instance.showSubLoading();
        for(float t=0;t<timeout;t+=0.5f){
            // Debug.Log(SocketManager.instance.socket.IsConnected);
            if(SocketManager.instance.socket.IsConnected){
                yield return null;
                break;                
            }
            Debug.LogError("socket is not connected");
            yield return new WaitForSeconds(0.5f);
        }
        SubLoading.instance.endSubLoading();

        if(!SocketManager.instance.socket.IsConnected){
            SubLoading.instance.showErrorCanvas("socket is not connected");
        } else {
            SceneManager.instance.changeScene("roomscene");
            
        }
    }



    public void onJoinClick(){
        // var temp = GameObject.Find("Content");

        // var activeCount = 0;
        // var roomName = "";
        // for(var i = 0; i < temp.transform.childCount; i++){
        //     var loc_svObject = temp.transform.GetChild(i).gameObject;

        //     if(loc_svObject.transform.Find("PanelSelected").gameObject.activeSelf){
        //         activeCount++;
        //         Debug.Log(loc_svObject + "/" + loc_svObject.transform.Find("roomname").gameObject.name);
        //         roomName = loc_svObject.transform.Find("roomname").gameObject.GetComponent<TMP_Text>().text;
        //     }
        // }

        // if(activeCount == 1 && roomName != ""){
        //     SocketManager.instance.requestSync(Sig.JOIN_ROOM,
        //     new {roomname = roomName},
        //     (res)=>{
        //         Player.setRoomData(res.GetField("roomData"));
        //         Player.gameStatus = GameStatus.onStart;
        //         Player.updatePlayer(res.GetField("player"));

        //         SceneManager.instance.changeScene("gamescene");
        //     });
        // }
    }


    public void onErrorCanvasOKClick(){
        SubLoading.instance.endErrorCanvas();
    }

    // public void onMultiPlayClick(){
    //     SceneManager.instance.changeScene("nickname");
    // }
}