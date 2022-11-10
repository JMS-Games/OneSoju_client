using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SocketIO;
public class SocketManager : MonoBehaviour {
    public static SocketManager instance = null;

    public bool isConnected;

    public int requestID;

    public SocketIOComponent socket = null;
    void Awake(){
        
        if(instance == null){
            instance = this;
            // client = null;
            DontDestroyOnLoad(this.gameObject);
            // client = new SocketIOComponent("ws://127.0.0.1:3314/socket.io/?EIO=4&transport=websocket");
            isConnected = false;
            requestID = 1000;

           
        } else {
            Destroy(this.gameObject);
        }



    }

    public IEnumerator subLoadingUntilConnect(Action cb){
        SubLoading.instance.showSubLoading();
        for(;;){
            if(this.socket.socket.IsConnected){
                SubLoading.instance.endSubLoading();
                cb();
                yield return null;
                break;
            }
            yield return new WaitForSeconds(0.5f);
        }
        
    }
    public void registerEvent(){
        if(socket == null){
            Debug.LogError("소켓이 null이라 event register에 실패함");
            return;
        }
        
        // socket.On(Sig.HAND_SHAKE,(e) => {
        //     JSONObject res = e.data;
        //     SubLoading.instance.endSubLoading();
            
            
        //     // Debug.Log("결과 오브젝트"+ress.CODE);
        //     Debug.Log("RESULT");
        //     // Debug.Log(res.CODE);
        //     if(res.GetField("CODE").f==500){
        //         //do nothing
        //     } else if(res.GetField("CODE").f ==200){
        //         Player.create();
        //         Player.nickname = res.GetField("nickname").str;

        //         SceneManager.instance.changeScene("roomscene");
        //     }
        // });

        // socket.On(Sig.CREATE_ROOM,(e) => {
        //     JSONObject res = e.data;
        //     SubLoading.instance.endSubLoading();

        //     if(res.GetField("CODE").f==500){
        //         //do nothing
        //     } else if(res.GetField("CODE").f ==200){
        //         Player.setRoomData(res.GetField("roomData"));

        //         SceneManager.instance.changeScene("roomscene");
        //     }
        // });


        // socket.On(Sig.REFRESH_ROOM,(e) => {
        //     JSONObject res = e.data;

        //     if(res.GetField("CODE").f==500){
        //         //do nothing
        //         SubLoading.instance.showErrorCanvas("Failed to refresh room info");

        //     } else if(res.GetField("CODE").f ==200){
        //         if(SceneManager.instance != null && SceneManager.instance.getCurrentSceneName() == "roomscene"){
        //             // RoomScene.setUI(res.roomInfo);
        //             DispatchEventManager.instance.setRoomSceneUI(res.GetField("roomInfo"));
        //         }
        //     }
        // });
    }


    public void connect(){
        if(socket == null){
            socket = this.GetComponent<SocketIOComponent>();
            registerEvent();

        }


        socket.Connect();
    }

    public void disconnect(){
        if(socket != null && this.socket.socket.IsConnected){
            SubLoading.instance.subLoadingCount--;
            this.socket.Close();
        }
    }

    private void SocketOpened(object sender, System.EventArgs e)
    {
        Debug.Log("Socket Opened");
    }


    public void Emit(string ev)
    {
        socket.Emit(ev);
    }

    public void Emit(string ev, Action<JSONObject> action)
    {
        socket.Emit(ev, action);
    }

    public void Emit(string ev, JSONObject data)
    {
        socket.Emit(ev, data);
    }

    public void Emit(string ev, JSONObject data, Action<JSONObject> action)
    {
        socket.Emit(ev, data, action);
    }

    public void On(string ev, Action<SocketIOEvent> callback)	{
        socket.On(ev,callback);
    }




    public void Emit(int ev)
    {
        socket.Emit(ev.ToString());
    }

    public void Emit(int ev, Action<JSONObject> action)
    {
        socket.Emit(ev.ToString(), action);
    }

    public void Emit(int ev, JSONObject data)
    {
        socket.Emit(ev.ToString(), data);
    }

    public void Emit(int ev, JSONObject data, Action<JSONObject> action)
    {
        socket.Emit(ev.ToString(), data, action);
    }

    public void On(int ev, Action<SocketIOEvent> callback)	{
        socket.On(ev.ToString(),callback);
    }

    public void Off(int ev)	{
        socket.OffAll(ev.ToString());
    }


    public IEnumerator subLoadingUntilRequest(Action cb){
        SubLoading.instance.showSubLoading();
        for(;;){
            if(this.socket.socket.IsConnected){
                SubLoading.instance.endSubLoading();
                cb();
                yield return null;
            }
            yield return new WaitForSeconds(0.5f);
        }
        
    }

    public void requestSync(int sig, object obj, Action<JSONObject> callback){
        if(instance == null){
            UnityEngine.SceneManagement.SceneManager.LoadScene("main");
        }
        SubLoading.instance.showSubLoading();
        this.Emit(sig, Util.getJSON(obj),(e) => 
            {
                Debug.Log("request response "+e.ToString());
                SubLoading.instance.endSubLoading();
                callback(e[0]);
            }
        );
    }

    void OnDisable(){
        // client.Close();
    }

    // public void request(string route, JsonObject message, System.Action<JsonObject> action){
    //     client.request(route, message, (result)=>{

    //     });
    // }

    

}