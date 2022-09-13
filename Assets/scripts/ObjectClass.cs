using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectClass
{
    public static int count = 0;
    public int id;
    public int speed;
    public Vector3 destination;
    public Vector3 startpoint;
    public Vector3 toward;

    public ObjectClass()
    {
        id = count;
        count++;
        speed =0;
        destination = new Vector3(0,0,0);
        startpoint = new Vector3(0,0,0);
        toward = new Vector3(0,0,0);
    }

    public int GetId()
    {
        return id;
    }
    
    public int GetSpeed()
    {
        return speed;
    }

    public Vector3 GetDestination()
    {
        return destination;
    }

    public Vector3 GetStartpoint()
    {
        return startpoint;
    }

    public Vector3 GetToward()
    {
        return toward;
    }

    public void SetId(int _id)
    {
        id = _id;
    }

    public void SetSpeed(int _speed)
    {
        speed = _speed;
    }

    public void SetDestination(Vector3 _destination)
    {
        destination = _destination;
    }

    public void SetStartpoint(Vector3 _startpoint)
    {
        startpoint = _startpoint;
    }

    public void SetToward(Vector3 _toward)
    {
        toward = _toward;
    }
}
