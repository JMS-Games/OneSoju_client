using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConfigManager : MonoBehaviour {
    public static ConfigManager instance = null;

    // public Configuration config = null;
    void Awake(){
        // if(instance == null){
        //     instance = this;

            // config = Configuration.LoadFromResource("Jsons/game");
            // DontDestroyOnLoad(this.gameObject);
            
            
        // } else {
        //     Destroy(this.gameObject);
        // }
    }

    // public Section get(string section){
    //     return config[section];
    // }

    

    // public string get(string section, string key){
    //     return config[section][key].StringValue;
    // }

    // public string sig(string key){
    //     return config["Signal"][key].StringValue;
    // }
}