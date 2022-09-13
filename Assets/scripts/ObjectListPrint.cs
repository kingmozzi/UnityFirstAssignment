using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObjectListPrint : MonoBehaviour
{
    public Text target;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }
    
    public void ListPrint(TabButton button)
    {
        GameObject[] temp;
        string[] names = new string[]{"Sphere", "Cube", "Capsule"};
        if(button.name == "All")
        {   
            var list = new List<GameObject>();

            foreach(string name in names)
            {
                list.AddRange(GameObject.FindGameObjectsWithTag(name));
            }
            temp = list.ToArray();
        }
        else
        {
            temp = GameObject.FindGameObjectsWithTag(button.name);
        }
        target.text = "";
        
        foreach(GameObject x in temp)
        {
            target.text+=x.name+'\n';
        }
    }
}
