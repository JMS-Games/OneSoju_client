using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using Newtonsoft.Json;

public static class Util {

    public static GameObject getInst(string name)
    {
        var res = Resources.Load(name);

        var inst = (GameObject)GameObject.Instantiate(res, Vector3.zero, Quaternion.identity);

        return inst;
    }
    
    public static GameObject getInstByRes(Object obj)
    {

        var inst = (GameObject)GameObject.Instantiate(obj, Vector3.zero, Quaternion.identity);

        return inst;
    }
    
    public static JSONObject getJSON2(string str, params object[] args){
        foreach(var arg in args){
            int idx = str.IndexOf("@");
            str = str.Remove(idx, 1).Insert(idx,arg.ToString());
        }

        return new JSONObject(str);

    }

    public static JSONObject getJSON(object obj){
        return new JSONObject(Newtonsoft.Json.JsonConvert.SerializeObject(obj));
        // Debug.Log("오브젝트 변환 시도 "+obj.ToString());
        // Debug.Log("오브젝트 변환 결과 "+JsonUtility.ToJson(obj));
        // return new JSONObject(JsonUtility.ToJson(obj));
        
    }

    public static bool checkError(JSONObject res)
    {
        if (res.GetField("CODE").f != 200)
        {
            return true;
        }

        return false;
    }

    // public static Dictionary<string,string> getDict(JSONObject obj){
    //     return JsonConvert.DeserializeObject<Dictionary<string,string>>(obj.ToString());
    // }


    // public static object getObject(JSONObject obj){
    //      return JsonConvert.DeserializeObject(obj.ToString());
       
    // }

    // public static dynamic getDynamic(JSONObject obj){
    //      return new JDynamic(obj.ToString());
    // }

}