using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sound {
    public string clipName;
    public string clipPath;
    public AudioClip source;

    public Sound(string name, string path){
        clipName = name;
        clipPath = path;
        source = Resources.Load(path) as AudioClip;
        Debug.Log(source);
    }

}
public class SoundManager : MonoBehaviour
{
    public static SoundManager instance = null;
    public static Dictionary<string, AudioClip> storage;

    AudioSource player;

    public AudioClip mainBGM;


    // AudioSource tickSoundSrc;

    // AudioSource source;
    // public GameObject onSpectrumTarget;

    // float specAverage;

    // float specSum;

    // float deltaSum;

    // bool isMoving;

    // float movingPoint;
    // int bpm;

    public void playEffect(string effectName){
        
    }

    public void stopBGM(){
        player.Stop();
    }
    public void playBGM(string bgmName){
        if(storage.ContainsKey(bgmName)){
             if(player.clip == storage[bgmName]){
                if(player.isPlaying){
                    return;
                }
            }
            player.clip = storage[bgmName];
            player.Play();
        } else {
            Debug.LogError("BGM Storage에 "+bgmName+" 이 존재하지 않습니다.");
        }
    }
    public void playBGM(string bgmName, bool isLoop){
        if(storage.ContainsKey(bgmName)){
            if(player.clip == storage[bgmName]){
                if(player.isPlaying){
                    return;
                }
            }
            player.clip = storage[bgmName];
            player.loop = isLoop;
            player.Play();
        } else {
            Debug.LogError("BGM Storage에 "+bgmName+" 이 존재하지 않습니다.");
        }
    }

    void init(){
        storage = new Dictionary<string,AudioClip>();
        registerSound(new Sound("mainBgm","Audio/BGM/mainSound"));
        registerSound(new Sound("bgm","Audio/BGM/bgm"));


    }

    void registerSound(Sound temp){
        storage.Add(temp.clipName, temp.source);
    }
    void Awake(){
        if(instance == null){
            instance = this;
            DontDestroyOnLoad(this.gameObject);

            player = this.gameObject.AddComponent<AudioSource>();

            player.playOnAwake = false;

            init();



        } else {
            Destroy(this.gameObject);
        }
        // source = GameObject.Find("main").gameObject.GetComponent<AudioSource>();
        // tickSoundSrc = this.transform.Find("tickSound").GetComponent<AudioSource>();
    }
    // // Start is called before the first frame update
    // void Start()
    // {
    //     source.clip = mainBGM;
    //     source.loop = true;
    //     // tickSoundSrc.clip = tickSound;
    //     source.Play();

    //     specSum = 0;

        // AudioProcessor processor = GameObject.Find("main").gameObject.GetComponent<AudioProcessor>();
	// 	processor.onBeat.AddListener (onOnbeatDetected);
	// 	processor.onSpectrum.AddListener (onSpectrum);

    //     // bpm = UniBpmAnalyzer.AnalyzeBpm(mainBGM);
    //     // Debug.Log("BPM is " + bpm);
    //     bpm = 128;
    //     deltaSum = -0.14f;
    //     specAverage = 0;
    //     movingPoint = 0;

    //     isMoving = false;
    // }

    // Update is called once per frame
    // void Update()
    // {
    //     Debug.Log(Time.deltaTime);
    //     deltaSum += Time.deltaTime;


    //     float point = 60.0f/bpm;

    //     Debug.Log("deltaSum = "+deltaSum+" , "+point);

    //     if(deltaSum > point){
    //         deltaSum = deltaSum - point;

    //         Debug.Log("Beat");
    //         movingPoint = specSum+50;
    //         specSum = 0;
    //         // tickSoundSrc.Play();
    //         processMoving(movingPoint);
    //         isMoving = true;
    //         Debug.Log(onSpectrumTarget.transform.localScale);
    //     }

    //     float accel = 0.1f * Time.deltaTime*1000.0f/2.0f*15.0f;

    //     if(isMoving){
    //         if(movingPoint > 1){
    //             if(movingPoint > 1){
    //                 onSpectrumTarget.transform.localScale += new Vector3(1,1,1)*movingPoint*accel/1000;
    //                 movingPoint = movingPoint * (1-accel);

    //                 Debug.Log("감소된 "+movingPoint);
    //             }
    //         } else {
    //             isMoving = false;
    //             Debug.Log("move stop");
    //         }
    //     } else {
    //         float currScale = onSpectrumTarget.transform.localScale.x;

    //         if(currScale > 1){
    //             float overVal = currScale - 1;
    //             onSpectrumTarget.transform.localScale -= new Vector3(1,1,1)*overVal*(1-accel);
    //             currScale -= overVal*(1-accel);

    //             if(currScale < 1){
    //                 onSpectrumTarget.transform.localScale = new Vector3(1,1,1);
    //                 currScale = 1;
    //             }
    //         }
    //     }
        
    // }// 0.033
    //  // 0.002

    // void processMoving(float point){
    //     Debug.Log(point);
    // }
    // void onOnbeatDetected ()
	// {
	// 	// Debug.Log ("Beat!!!"+specSum);
    //     // onSpectrumTarget.transform.localScale = new Vector3(1,1,1)+new Vector3(1,1,1)*specSum*0.1f;
	// }

	// //This event will be called every frame while music is playing
	// void onSpectrum (float[] spectrum)
	// {
	// 	//The spectrum is logarithmically averaged
	// 	//to 12 bands

    //     float sum = 0;
	// 	for (int i = 0; i < spectrum.Length; ++i) {
	// 		Vector3 start = new Vector3 (i, 0, 0);
	// 		Vector3 end = new Vector3 (i, spectrum [i], 0);
	// 		// Debug.Log(spectrum[i]);
    //         sum += spectrum[i];
	// 	}

    //     specSum += sum;
	// }



    
}
