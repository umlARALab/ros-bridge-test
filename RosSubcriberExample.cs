using System.Collections;
using System.Collections.Generic;
using System;
//using System.Boolean;

using UnityEngine;
using Unity.Robotics.ROSTCPConnector;
using RosColor = RosMessageTypes.UnityRoboticsDemo.UnityColorMsg; 
// replicate line6 to show ros status 
using RobotStat = RosMessageTypes.Std.StringMsg; 


public class RosSubscriberExample : MonoBehaviour
{
    public GameObject cube;
    public static bool stat; 

    void Start()
    {
        ROSConnection.GetOrCreateInstance().Subscribe<RobotStat>("robot status", RobotStatus);
    }

    void ColorChange(RosColor colorMessage) // change to return bool of ros status
    {
        cube.GetComponent<Renderer>().material.color = new Color32((byte)colorMessage.r, (byte)colorMessage.g, (byte)colorMessage.b, (byte)colorMessage.a);
    }

 void RobotStatus(RobotStat status) // change to return bool of ros status
    {
    	string var1 = "Robot Ready";
    	int v1 = var1.Compare(status.data, var1, true);
        
        if (v1 == 0){
        	stat = true;
        }
        else { 
        	stat = false; 
        }
    }
}
