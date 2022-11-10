using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;


public static class JsonManager<T>
{
    public static Dictionary<string, T> json;
    
    public static void addKey(string key, string path){

        string jsonStr = readJsonFromPath(path);
        Debug.Log(jsonStr);
        T jsonObj = JsonUtility.FromJson<T>(jsonStr);
        Debug.Log(jsonObj);
        


        json.Add(key,jsonObj);

        Debug.Log("addKey complete "+key);

        // return json[key];
    }

    public static string readJsonFromPath(string path){
        FileInfo file = new FileInfo(path);
        if(file.Exists == false){
            Debug.LogError("파일이 존재하지 않습니다 -->"+path);
            return null;
        }

        return File.ReadAllText(file.FullName);
    }

    public static T getKey(string key){
        return json[key];
    }
}