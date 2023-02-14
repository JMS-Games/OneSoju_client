using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using UnityEngine.Events;
using UnityEngine.EventSystems;

using SocketIO;
using TMPro;
using Unity.VisualScripting;
using UnityEditor;

public class HandController : MonoBehaviour
{
    private List<Card> cardList = new List<Card>();

    public bool dragEnable = false;
    public bool dragging = false;
    private CardController dragTarget = null;

    private Camera cam;
    
    GraphicRaycaster gr = null;

    HandController(){
        
    }

    void Awake(){
        
    }

    void Start()
    {
        gr = GameObject.Find("Canvas").GetComponent<GraphicRaycaster>();
    }

    public void setUI(List<Card> cards)
    {
        foreach (Transform child in this.transform)
        {
            Destroy(child);
        }

        var res = Resources.Load("Card");

        var count = 0;
        foreach (var card in cards)
        {
            var inst = Util.getInstByRes(res);
            inst.transform.SetParent(this.transform);
            var con = inst.GetComponent<CardController>();
            con.setCard(card);
            count++;
            con.transform.localPosition =
                new Vector3(
                    -this.GetComponent<RectTransform>().rect.width / 2 +
                    con.GetComponent<RectTransform>().rect.width / 2 + count * 30, 0, 0);
            
            
            

        }
    }

    public void onBeginDrag(PointerEventData e, CardController c)
    {
        if (!dragEnable)
        {
            return;
        }

        dragEnable = false;
        c.isDragging = true;

        var res = Resources.Load("Card");
        var inst = Util.getInstByRes(res);
        
        inst.transform.SetParent(this.transform);

        dragTarget = inst.GetComponent<CardController>();
        
        dragTarget.setCard(c.card);

        Debug.Log(dragTarget.imgCard);
        dragTarget.imgCard.color = new Color(1,1,1,0.5f);


        
        

    }

    public void onDrag(PointerEventData e, CardController c)
    {
        if (!dragTarget)
        {
            return;
        }

        dragTarget.transform.position = e.position;
    }
    public void onEndDrag(PointerEventData e, CardController c)
    {
        bool hitComplete = false;
        PointerEventData ped;

        ped = new PointerEventData(null);
        
        ped.position = Input.mousePosition;
        List<RaycastResult> results = new List<RaycastResult>();
        gr.Raycast(ped, results);

        for (int i = 0; i < results.Count; i++)
        {
            if (results[i].gameObject.transform.parent.parent.name == "posDeque")
            {
                hitComplete = true;
                break;
            }
        }

        dragEnable = true;
        Destroy(dragTarget.gameObject);
        dragTarget = null;
        c.isDragging = false;
        dragging = false;
        
        
        if (hitComplete)
        {
            //서버로 보내자
            dragEnable = false;
            
            SocketManager.instance.request(Sig.USE_CARD, new { nextCard=c.card }, (res) =>
            {
                Debug.Log("use card result "+res);
                if (Util.checkError(res))
                {
                    PopupController.instance.showPopup("use error");
                    dragEnable = true;

                    return;
                }
                
                
                
                
            });
        }


    }
    public void onDrop(PointerEventData e, CardController c)
    {
        
    }
}