using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ObjectScript : MonoBehaviour{
    // Start is called before the first frame update
    ObjectClass ObjectClass;
    public GameObject statusUI;
    //public GameObject popupUI;
    public static List<ObjectClass> objects = new List<ObjectClass>();
    public static List<GameObject> statusUis = new List<GameObject>();
    public static List<GameObject> realObjects = new List<GameObject>();
    public static int moveFlag = 0;
    public static int playFlag = 0;
    public static float playSpeed = 0.0005f;

    public GameObject ConllisionUi;
    
    void Start()
    {
        if(realObjects.Count == 0)
        {
            GameObject[] temp = GameObject.FindGameObjectsWithTag("Sphere");
            foreach(GameObject x in temp)
            {
                realObjects.Add(x);
            }
        }

        ObjectClass instanceObject = null;
        instanceObject = new ObjectClass();
        objects.Add(instanceObject);

        

        Vector3 pos = this.transform.position;
        Vector2 pos2 = Camera.main.WorldToScreenPoint(pos);
        statusUis.Add(Instantiate(statusUI, pos2 + new Vector2(0, 80), Quaternion.identity, GameObject.Find("Canvas").transform));
        TextMeshProUGUI child = statusUI.transform.Find("IDText").gameObject.GetComponent<TextMeshProUGUI>();
        child.text = "ID:"+ instanceObject.id.ToString();
        TextMeshProUGUI child2 = statusUI.transform.Find("SpeedText").gameObject.GetComponent<TextMeshProUGUI>();
        child2.text = "Speed:"+ instanceObject.speed.ToString();
        TextMeshProUGUI child3 = statusUI.transform.Find("DestinationText").gameObject.GetComponent<TextMeshProUGUI>();
        child3.text = "Dest.:"+ instanceObject.destination.ToString();

        instanceObject.SetStartpoint(pos);
        instanceObject.SetDestination(pos);
        instanceObject.SetToward(pos);
    }

    // Update is called once per frame
    void Update()
    {
        if(moveFlag==1)
        {   
            Vector3 temp = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 7.5f));
            PopupButton.onSelected.transform.position =temp;
        }
        if(Input.GetMouseButtonDown(0)&&moveFlag==1)
        {
            moveFlag=0;
            int index = ObjectScript.realObjects.IndexOf(PopupButton.onSelected);
            if(index != -1)
            {
                objects[index].SetStartpoint(PopupButton.onSelected.transform.position);
            }
        }

        if(playFlag==1)
        {
            for(int i=0;i<objects.Count;i++)
            {
                if(realObjects[i].transform.position == objects[i].destination)
                {
                    objects[i].toward = objects[i].startpoint;
                }
                else if(realObjects[i].transform.position == objects[i].startpoint){
                    
                    objects[i].toward = objects[i].destination;
                }
                else if(objects[i].toward!=objects[i].startpoint && objects[i].toward!=objects[i].destination)
                {
                    objects[i].toward = objects[i].destination;
                }
                realObjects[i].transform.position = Vector3.MoveTowards(realObjects[i].transform.position, objects[i].toward, objects[i].speed * playSpeed);
            }
        }

        for(int i=0;i<objects.Count;i++){
            Vector3 pos = realObjects[i].transform.position;
            Vector2 pos2 = Camera.main.WorldToScreenPoint(pos);
            statusUis[i].transform.position = pos2+new Vector2(0,80);
            statusUis[i].transform.Find("IDText").gameObject.GetComponent<TextMeshProUGUI>().text ="ID:"+ objects[i].id.ToString();
            statusUis[i].transform.Find("SpeedText").gameObject.GetComponent<TextMeshProUGUI>().text ="Speed:"+ objects[i].speed.ToString();
            statusUis[i].transform.Find("DestinationText").gameObject.GetComponent<TextMeshProUGUI>().text = "Dest.:"+ objects[i].destination.ToString();
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.name != "Plane")
        {
            other.GetComponent<Renderer>().material.color = Color.red;
            GameObject tempinst = Instantiate(ConllisionUi, new Vector2(200, 200), Quaternion.identity, GameObject.Find("Canvas").transform);
            tempinst.transform.Find("ConllisionText").gameObject.GetComponent<TextMeshProUGUI>().text = other.name + " and " + this.transform.name + " collided.";
        }
    }

    private void OnTriggerStay(Collider other)
    {
        //Debug.Log("Trigger Stay : " + other.name);
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.name != "Plane")
        {
            other.GetComponent<Renderer>().material.color = Color.white;
        }
    }
}
