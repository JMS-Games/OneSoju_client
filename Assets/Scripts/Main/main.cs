using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class main : MonoBehaviour
{
    void Awake(){
        Application.targetFrameRate = 60;
    }


    void Start()
    {
        SoundManager.instance.playBGM("mainBgm", true);

    }

    // Update is called once per frame
    void Update()
    {

    }

}
