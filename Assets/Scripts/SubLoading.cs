using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SubLoading : MonoBehaviour
{
    public static SubLoading instance = null;
    private GameObject newCanvas = null;
    private GameObject errorCanvas = null;

    Canvas c;
    Canvas errorCanvasC;
    CanvasScaler scaler;
    CanvasScaler errorscaler;

    GameObject panel;
    GameObject errorpanel;
    GameObject inst;
    GameObject errorinst;

    GameObject errorpanelContent;

    public int subLoadingCount = 0;

    public int errorCount = 0;
    void Awake(){
        if(instance == null){
            if(SceneManager.instance == null){
                // UnityEngine.SceneManagement.SceneManager.LoadScene("main");
            }
            instance = this;
            DontDestroyOnLoad(this.gameObject);

            newCanvas = new GameObject("loadingCanvas");
            c = newCanvas.AddComponent<Canvas>();
            c.renderMode = RenderMode.ScreenSpaceOverlay;
            scaler = newCanvas.AddComponent<CanvasScaler>();
            newCanvas.AddComponent<GraphicRaycaster>();

            scaler.uiScaleMode = CanvasScaler.ScaleMode.ScaleWithScreenSize;
            scaler.referenceResolution = new Vector2(2160,3840);
            scaler.screenMatchMode = CanvasScaler.ScreenMatchMode.Expand;

            newCanvas.layer=5;

            c.sortingOrder=10000;
            c.worldCamera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();

            panel = new GameObject("Panel");
            panel.AddComponent<CanvasRenderer>();
            UnityEngine.UI.Image i = panel.AddComponent<UnityEngine.UI.Image>();
            i.color = new Color(100,100,100,0.3f);

            Object subloading = Resources.Load("Circle rotating 1");

            inst = (GameObject) GameObject.Instantiate( subloading , Vector3.zero, Quaternion.identity);

            inst.transform.SetParent(newCanvas.transform);
            inst.transform.localScale = new Vector3(2f,2f,2f);
            inst.transform.localPosition = new Vector3(0f,0f,0f);
            // inst.transform.Translate((float)Screen.width/2, (float)Screen.height/2,0);

            panel.transform.SetParent(newCanvas.transform);
            panel.transform.localPosition = new Vector3(0f,0f,-1000f);
            panel.transform.localScale = new Vector3(Screen.width,Screen.height,1);


            newCanvas.SetActive(false);

            


//=============================================================================================================



//             errorCanvas = new GameObject("errorCanvas");
//             errorCanvasC = errorCanvas.AddComponent<Canvas>();
//             errorCanvasC.renderMode = RenderMode.ScreenSpaceCamera;
//             errorscaler = errorCanvas.AddComponent<CanvasScaler>();
//             errorCanvas.AddComponent<GraphicRaycaster>();

//             errorscaler.uiScaleMode = CanvasScaler.ScaleMode.ScaleWithScreenSize;
//             errorscaler.referenceResolution = new Vector2(2160,3840);
//             errorscaler.screenMatchMode = CanvasScaler.ScreenMatchMode.Expand;

//             errorCanvas.layer=5;

//             errorCanvasC.sortingOrder=10000;
//             errorCanvasC.worldCamera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();

//             errorpanel = new GameObject("errorPanel");
//             errorpanel.AddComponent<CanvasRenderer>();
//             UnityEngine.UI.Image ierror = errorpanel.AddComponent<UnityEngine.UI.Image>();
//             ierror.color = new Color(100,100,100,0.3f);

//             errorpanel.transform.SetParent(errorCanvas.transform);
//             errorpanel.transform.localPosition = new Vector3(0f,0f,-1000f);
//             errorpanel.transform.localScale = new Vector3(Screen.width/50.0f,Screen.height/50.0f,1);
// //=======================================================================//

//             errorpanelContent = new GameObject("errorPanelContent");
//             errorpanelContent.AddComponent<CanvasRenderer>();
//             UnityEngine.UI.Image ierrorContent = errorpanelContent.AddComponent<UnityEngine.UI.Image>();
//             ierrorContent.color = new Color(0.1f,0.1f,0.1f,0.6f);

//             // Object subloading = Resources.Load("Circle rotating 1");

//             // inst = (GameObject) GameObject.Instantiate( subloading , Vector3.zero, Quaternion.identity);

//             // inst.transform.SetParent(newCanvas.transform);
//             // inst.transform.localScale = new Vector3(2f,2f,2f);
//             // inst.transform.localPosition = new Vector3(0f,0f,0f);
//             // inst.transform.Translate((float)Screen.width/2, (float)Screen.height/2,0);

//             errorpanelContent.transform.SetParent(errorCanvas.transform);
//             errorpanelContent.transform.localPosition = new Vector3(0f,0f,-1000f);
//             errorpanelContent.transform.localScale = new Vector3(1f,1f,1);
//             errorpanelContent.GetComponent<RectTransform>().sizeDelta = new Vector2(1300,2000);


//             var messageText = new GameObject("messageText");
//             // messageText.AddComponent<CanvasRenderer>();
//             var textComponent = messageText.AddComponent<TextMeshProUGUI>();

//             textComponent.SetText("Hello world\n hello");
//             textComponent.horizontalAlignment = TMPro.HorizontalAlignmentOptions.Center;
//             textComponent.fontSize = 7;
            

//             // textComponent.SetText("dummy");

//             messageText.transform.SetParent(errorpanelContent.transform);
//             messageText.transform.localPosition = new Vector3(0f,1f,0f);

//             messageText.GetComponent<RectTransform>().sizeDelta = new Vector2(50,50);
            
            this.errorCanvas = GameObject.Find("subloading").transform.Find("errorCanvas").gameObject;

            var okButton = GameObject.Find("subloading").transform.Find("errorCanvas").Find("errorCanvasBtnOK").gameObject;
            okButton.GetComponent<Lean.Gui.LeanButton>().OnClick.AddListener(endSubLoading);

            errorCanvas.SetActive(false);
            DontDestroyOnLoad(this.newCanvas);
            DontDestroyOnLoad(this);

            subLoadingCount = 0;
            errorCount = 0;

        } else {
            Destroy(this.gameObject);
        }





    }
    public static SubLoading Instance
        {
            get
            {
                if (null == instance)
                {
                    return null;
                }
                return instance;
            }
        }
    // Start is called before the first frame update
    public void showSubLoading(){
        subLoadingCount++;
        Debug.Log("showSubLoading "+subLoadingCount);
        if(subLoadingCount>=1){
            newCanvas.SetActive(true);
        }
    }

    public void endSubLoading(){
        subLoadingCount--;
        Debug.Log("endSubLoading "+subLoadingCount);

        if(subLoadingCount<=0){
            newCanvas.SetActive(false);
        }
        if(subLoadingCount < 0){
            subLoadingCount = 0;
        }
    }

    public void showErrorCanvas(string msg){
        errorCount++;

        if(errorCount >= 1){

            this.errorCanvas.transform.Find("errorPanelContent").Find("messageText").gameObject.GetComponent<TextMeshProUGUI>().SetText(msg);

            this.errorCanvas.GetComponent<CanvasGroup>().alpha = 0;
           
            errorCanvas.SetActive(true);
        }
    }

    public void endErrorCanvas(){
        
        errorCount = 0;

        if(errorCount <= 0){
            errorCanvas.SetActive(false);
        }

        if(errorCount < 0){
            errorCount = 0;
        }
    }

    void Update(){
        if(this.errorCount >= 1){
            var alpha = this.errorCanvas.GetComponent<CanvasGroup>().alpha;
            if(alpha < 1){;
                this.errorCanvas.GetComponent<CanvasGroup>().alpha += (1.2f*Time.deltaTime);
            }
        }
    }

    public void showSubLoadingUntilSocketConnect(float timeout){
        StartCoroutine(checkSocket(timeout));
    }

    IEnumerator checkSocket(float timeout){
        showSubLoading();
        for(float t=0;t<timeout;t+=0.5f){
            if(SocketManager.instance.socket.IsConnected){
                yield return null;
                break;                
            }
            Debug.Log("socket is not connected");
            yield return new WaitForSeconds(0.5f);
        }
        if(!SocketManager.instance.socket.IsConnected){
            showErrorCanvas("socket is not connected");
        }
        endSubLoading();
    }
}
