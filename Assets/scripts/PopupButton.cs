using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class PopupButton : MonoBehaviour
{
    public GameObject idsetUI;
    public TextMeshProUGUI idInput;
    public GameObject speedsetUI;
    public TextMeshProUGUI speedInput;

    public GameObject overlapUI;

    public GameObject destinationsetUI;
    public TextMeshProUGUI destinationInput;

    //int moveFlag = 0;
    public static GameObject onSelected = null;
    Camera cam;
    // Start is called before the first frame update
    void Awake() 
    {   
        if(idsetUI)
        {
            idsetUI.SetActive(false);
            speedsetUI.SetActive(false);
            overlapUI.SetActive(false);
            destinationsetUI.SetActive(false);
        }
        
    }

    void Start()
    {
        cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        // if(moveFlag==1)
        // {   
        //     Vector3 temp = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 1.0f));
        //     onSelected.transform.position =temp;
        //     Debug.Log("moving"+onSelected.transform.position);
        // }
        // if(Input.GetMouseButtonDown(0)&&moveFlag==1)
        // {
        //     Debug.Log("endmove");
        //     moveFlag=0;
        // }
        
    }

    public void ObjectMove()
    {
        int index = ObjectScript.realObjects.IndexOf(GetObject.seletedObject);
        if(index != -1)
        {
            ObjectScript.moveFlag = 1;
            onSelected = ObjectScript.realObjects[index];
        }
    }

    public void ObjectIdSet()
    {   
        GameObject.Find("Canvas").transform.Find("IDsetPanel").gameObject.SetActive(true);
    }

    public void ObjectSpeedSet()
    {
        GameObject.Find("Canvas").transform.Find("SpeedsetPanel").gameObject.SetActive(true);
    }

    public void ObjectDestinationSet()
    {
        GameObject.Find("Canvas").transform.Find("DestinationSetPanel").gameObject.SetActive(true);

        // int index = ObjectScript.realObjects.IndexOf(GetObject.seletedObject);
        // if(index != -1)
        // {
        //     ObjectScript.objects[index].SetDestination(new Vector3(1,1,0));
        // }
    }

    public void ObjectDelete()
    {
        //Debug.Log(GetObject.seletedObject);
        int index = ObjectScript.realObjects.IndexOf(GetObject.seletedObject);
        if(index != -1)
        {
            ObjectScript.realObjects[index].SetActive(false);
            ObjectScript.statusUis[index].SetActive(false);
        }
    }

    public void ClickIdOk()
    {
        string temp = "";
        int state = 1;
        for(int i=0;i<idInput.text.Length-1;i++)
        {
            temp+=idInput.text[i];
        }
        
        foreach(ObjectClass x in ObjectScript.objects)
        {
            if(int.Parse(temp) == x.id)
            {
                state=0;
                break;
            }
        }

        if(state==1)
        {
            int index = ObjectScript.realObjects.IndexOf(GetObject.seletedObject);
            if(index != -1)
            {
                ObjectScript.objects[index].SetId(int.Parse(temp));
            }
        }
        else
        {
            GameObject.Find("Canvas").transform.Find("OverlapPanel").gameObject.SetActive(true);
        }

        idsetUI.SetActive(false); 
    }

    public void ClickSpeedOk()
    {
        int index = ObjectScript.realObjects.IndexOf(GetObject.seletedObject);
        if(index != -1)
        {
            string temp = "";
            for(int i=0;i<speedInput.text.Length-1;i++)
            {
                temp+=speedInput.text[i];
            }
            ObjectScript.objects[index].SetSpeed(int.Parse(temp));
        }
        speedsetUI.SetActive(false);
    }

    public void ClickOverlapOk()
    {
        overlapUI.SetActive(false);
    }

    public void ClickDestinationOk()
    {
        int index = ObjectScript.realObjects.IndexOf(GetObject.seletedObject);
        Vector3 VdestinationPosition;
        if(index != -1)
        {
            int destinationPosition = destinationInput.text[0]-'0';
            VdestinationPosition = ObjectScript.realObjects[destinationPosition-1].transform.position;
            ObjectScript.objects[index].SetDestination(VdestinationPosition);
        }
        destinationsetUI.SetActive(false);
    }

}
