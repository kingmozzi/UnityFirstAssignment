using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetObject : MonoBehaviour
{
    public Camera getCamera;
    private RaycastHit hit;

    public GameObject popupUI;

    GameObject instancePopup = null;
    public static GameObject seletedObject = null;
    GameObject trackingObject = null;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Ray ray = getCamera.ScreenPointToRay(Input.mousePosition);
            if(ObjectScript.playFlag != 1)
            {
                if(Physics.Raycast(ray, out hit))
                {
                    //Debug.Log(hit.collider.gameObject);
                    
                    if(instancePopup != null)
                    {
                        Destroy(instancePopup, 0.5f);
                        instancePopup = null;
                    }
                    else
                    {
                        if(hit.collider.gameObject.name != "Plane")
                        {
                            instancePopup = Instantiate(popupUI, new Vector2(Input.mousePosition.x, Input.mousePosition.y), Quaternion.identity, GameObject.Find("Canvas").transform); 
                            seletedObject = hit.collider.gameObject;
                        }
                    }
                }
                else
                {
                    Destroy(instancePopup, 0.5f);
                    instancePopup = null;
                }
            }
            else
            {
                if(Physics.Raycast(ray, out hit))
                {
                    if(hit.collider.gameObject.name != "Plane")
                    {
                        trackingObject = hit.collider.gameObject;
                    }
                }
            }
        }

        if(ObjectScript.playFlag == 1 && trackingObject != null)
        {
            getCamera.transform.position = trackingObject.transform.position + new Vector3(0,2,0);
        }

        if(Input.GetKeyDown(KeyCode.Keypad0))
        {
            trackingObject = null;
            getCamera.transform.position = new Vector3(-1.35f, 7.99f, -0.7f);
        }
        
    }
}
