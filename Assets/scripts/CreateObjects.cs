using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class CreateObjects : MonoBehaviour
{
    public Transform spawnerPosition;

    public GameObject target;

    void Start()
    {
        
    }

    public void OnClickButton()
    {
        GameObject instance = Instantiate(target,
                            spawnerPosition.position,
                            spawnerPosition.rotation);
        ObjectScript.realObjects.Add(instance);
    }
}
