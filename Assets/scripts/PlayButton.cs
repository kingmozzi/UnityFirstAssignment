using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayButton : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ClickPlay()
    {
        ObjectScript.playFlag = 1;
    }

    public void ClickStop()
    {
        ObjectScript.playFlag = 0;
    }

    public void CLickDouble()
    {
        ObjectScript.playSpeed *=2;
    }
}
