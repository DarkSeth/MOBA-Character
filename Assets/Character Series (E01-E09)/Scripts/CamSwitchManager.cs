﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamSwitchManager : MonoBehaviour
{

    public CameraFollow camFollowScript;
    public CameraRoam camRoamScript;

    bool camViewChanged = false;

    // Start is called before the first frame update
    void Start()
    {
        camRoamScript.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(camViewChanged);

        if(camViewChanged == false)
        {
            if(Input.GetKeyDown(KeyCode.E))
            {
                camViewChanged = true;

                camRoamScript.enabled = true;
                camFollowScript.enabled = false;
            }
        }
        else if(camViewChanged == true)
        {
            if(Input.GetKeyDown(KeyCode.E))
            {
                camViewChanged = false;

                camRoamScript.enabled = false;
                camFollowScript.enabled = true;
            }
        }

    }
}
