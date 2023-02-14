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

    public bool canShowSubloading = true;
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
        if (canShowSubloading)
        {
            SubLoading.instance.showSubLoading();
        }
        for(;;){
            if(this.socket.socket.IsConnected){
                //debug.log("소켓 연결 완료 ");
                if (canShowSubloading)
                {
                    SubLoading.instance.endSubLoading();
                }

                cb();
                yield return null;
                break;
            }
            yield return new WaitForSeconds(0.5f);
        }
        
    }
    public void registerEvent(){
        if(socket == null){
            //debug.logError("소켓이 null이라 event register에 실패함");
            return;
        }

        socket.On(Sig.START_GAME,(e) => {
            JSONObject res = e.data;
            //debug.log("START_GAME "+res);
            if(res.GetInt("CODE")==500){
                //debug.log("START_GAME fail");//do nothing
                
            } else if(res.GetInt("CODE") ==200){
                //debug.log("START_GAME success");//do nothing

                GameManager.instance.onStartGame(res);
            }
        });
        
        
        socket.On(Sig.JOIN_ROOM,(e) => {
            JSONObject res = e.data;
            //debug.log("join_room "+res);
            if(res.GetInt("CODE")==500){
                //debug.log("join_room fail");//do nothing
                
            } else if(res.GetInt("CODE") ==200){
                //debug.log("join_room success");//do nothing

                GameManager.instance.onJoinRoom(res);
            }
        });
        
        socket.On(Sig.EXIT_ROOM,(e) => {
            JSONObject res = e.data;
            //debug.log("exit_room "+res);
            if(res.GetInt("CODE")==500){
                //debug.log("exit_room fail");//do nothing
                
            } else if(res.GetInt("CODE") ==200){
                //debug.log("exit_room success");//do nothing

                GameManager.instance.onExitRoom(res);
            }
        });

        socket.On(Sig.YOUR_TURN,(e) => {
            JSONObject res = e.data;
            Debug.Log("your_turn "+res);
            if(res.GetInt("CODE")==500){
                //debug.log("your_turn fail");//do nothing
                
            } else if(res.GetInt("CODE") ==200){
                //debug.log("your_turn success");//do nothing

                GameManager.instance.onYourTurn(res);
            }
        });

        socket.On(Sig.USE_RESULT,(e) => {
            JSONObject res = e.data;
            //debug.log("your_turn "+res);
            if(res.GetInt("CODE")==500){
                //debug.log("your_turn fail");//do nothing
                
            } else if(res.GetInt("CODE") ==200){
                //debug.log("your_turn success");//do nothing

                GameManager.instance.onUseResult(res);
            }
        });
        
        socket.On(Sig.SOMEONE_WIN,(e) => {
            JSONObject res = e.data;
            //debug.log("your_turn "+res);
            if(res.GetInt("CODE")==500){
                //debug.log("your_turn fail");//do nothing
                
            } else if(res.GetInt("CODE") ==200){
                //debug.log("your_turn success");//do nothing

                GameManager.instance.onSomeoneWin(res);
            }
        });
        
        socket.On(Sig.END_GAME,(e) => {
            JSONObject res = e.data;
            //debug.log("your_turn "+res);
            if(res.GetField("CODE").f==500){
                //debug.log("your_turn fail");//do nothing
                
            } else if(res.GetField("CODE").f ==200){
                // OneSojuUIController.
                //debug.log("your_turn success");//do nothing

                GameManager.instance.onEndGame(res);
            }
        });
        
    }


    public void connect(){
        if(socket == null){
            socket = this.GetComponent<SocketIOComponent>();
            //debug.log("register event");
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
        //debug.log("Socket Opened");
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

    public void notify(int sig, object obj){
        if(instance is null){
            UnityEngine.SceneManagement.SceneManager.LoadScene("main");
        }
        this.Emit(sig, Util.getJSON(obj));
        
    }

    
    public void request(int sig, object obj, Action<JSONObject> callback){
        if(instance is null){
            UnityEngine.SceneManagement.SceneManager.LoadScene("main");
        }
        this.Emit(sig, Util.getJSON(obj),(e) => 
            {
                //debug.log("#request response "+e.ToString());
                callback(e[0]);
            }
        );
    }
    
    public void requestSync(int sig, object obj, Action<JSONObject> callback){
        if(instance is null){
            UnityEngine.SceneManagement.SceneManager.LoadScene("main");
        }
        SubLoading.instance.showSubLoading();
        this.Emit(sig, Util.getJSON(obj),(e) => 
            {
                //debug.log("request response "+e.ToString());
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