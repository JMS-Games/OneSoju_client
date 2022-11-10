using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scene
{

    public int index;
    public string name;
    public Scene(int i, string n){
        index = i;
        name = n;
    }

}



public class SceneManager : MonoBehaviour
{
    public static SceneManager instance = null;

    void Awake(){
        if(instance == null){
            instance = this;
            DontDestroyOnLoad(this.gameObject);

            init();

        } else {
            Destroy(this.gameObject);
        }
    }


    public Scene[] SceneList = new Scene[10];

    void init(){
        SceneList[0] = new Scene(0, "main");
        SceneList[1] = new Scene(1, "nickname");
    }

    public void changeScene(string name){
        Debug.Log("change Scene =>"+name);
        UnityEngine.SceneManagement.SceneManager.LoadScene(name);
    }

    public int getCurrentSceneIndex(){
        return UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex;
    }

    public string getCurrentSceneName(){
        return UnityEngine.SceneManagement.SceneManager.GetActiveScene().name;
    }
}
