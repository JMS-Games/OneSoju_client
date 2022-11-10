using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using Newtonsoft.Json;
// using Chsword;

public static class Util {
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