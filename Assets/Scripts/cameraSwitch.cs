using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraSwitch : MonoBehaviour
{
   // public TotalControl totalc;
    public Camera actionPhaseCamera;
    public Camera decisionPhaseCamera1;
    public Camera decisionPhaseCamera2;
    public static bool decisionPhase;
    // Start is called before the first frame update*/
    void Start()
    {
        actionPhaseCamera.enabled = true;
        decisionPhaseCamera1.enabled = false;
        decisionPhaseCamera2.enabled = false;
        decisionPhase = false;
    }

    public static void camerChange(Camera targetCamera, Camera camera1, Camera camera2)
    {
        targetCamera.enabled = true;
        camera1.enabled = false;
        camera2.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            camerChange(decisionPhaseCamera1, actionPhaseCamera, decisionPhaseCamera2);
        }else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            camerChange(decisionPhaseCamera2, actionPhaseCamera, decisionPhaseCamera1);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha0))
        {
            camerChange(actionPhaseCamera, decisionPhaseCamera2, decisionPhaseCamera1);
        }
        /*if (Input.GetKeyDown(KeyCode.C))
        {
            actionPhaseCamera.enabled = !actionPhaseCamera.enabled;
            decisionPhaseCamera.enabled = !decisionPhaseCamera.enabled;
            decisionPhase = !decisionPhase;
            if (totalc.selected == 1)
            {
                totalc.selected = 0;
                totalc.cardBack(totalc.card1);
            }
            else if (totalc.selected == 2)
            {
                totalc.selected = 0;
                totalc.cardBack(totalc.card2);
            }
            else if (totalc.selected == 3)
            {
                totalc.selected = 0;
                totalc.cardBack(totalc.card3);
            }
            else if (totalc.selected == 4)
            {
                totalc.selected = 0;
                totalc.cardBack(totalc.card4);
            }
        }*/
    }

    /*public static void switchCamera()
    {
        actionPhaseCamera.enabled = !actionPhaseCamera.enabled;
        decisionPhaseCamera.enabled = !decisionPhaseCamera.enabled;
        decisionPhase = !decisionPhase;
        if (totalc.selected == 1)
        {
            totalc.selected = 0;
            totalc.cardBack(totalc.card1);
        }
        else if (totalc.selected == 2)
        {
            totalc.selected = 0;
            totalc.cardBack(totalc.card2);
        }
        else if (totalc.selected == 3)
        {
            totalc.selected = 0;
            totalc.cardBack(totalc.card3);
        }
        else if (totalc.selected == 4)
        {
            totalc.selected = 0;
            totalc.cardBack(totalc.card4);
        }
    }*/
}
