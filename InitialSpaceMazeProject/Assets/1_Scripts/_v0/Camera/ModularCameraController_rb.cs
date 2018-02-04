using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModularCameraController_rb : MonoBehaviour
{
    //var dec, dont change velocityX/Y
    private Vector3 currModCenter, moduleModelCoords, camPos, playerPos, camLerpedPos, camTargetPos;
    private float dirVectDot, velocityX, velocityY, posDiff, lerpTime;

    public float lerpVelocity = 10.0f;

    private void Start()
    {
        currModCenter = new Vector3(0.0f, 0.0f, 0.0f);
        moduleModelCoords = new Vector3(0.0f, 0.0f, 0.0f);
        playerPos = new Vector3(0.0f, 0.0f, 0.0f);
        camPos = new Vector3(0.0f, 0.0f, 0.0f);
        camLerpedPos = new Vector3(0.0f, 0.0f, 0.0f);
        dirVectDot = 0.0f;
    }


    //funct def
    


         //trigger handling
    private void OnTriggerStay(Collider other)
        {

        if (other.gameObject.tag == GlobalValues.tagModule)
        {
            moduleModelCoords = other.GetComponent<Transform>().InverseTransformPoint(GetComponent<Transform>().parent.position);                          //retrieve camera coords in module space
            currModCenter = other.GetComponent<Transform>().position;
            camPos = GetComponent<Transform>().position;
            playerPos = GetComponent<Transform>().parent.position;
            dirVectDot = Vector3.Dot(Vector3.right, Vector3.Normalize(currModCenter - playerPos));
            Debug.Log(dirVectDot);


            //9-way case orientation handling
            switch (other.GetComponent<ModuleManager_rb>().Orientation)
            {

                //dead ends
                case GlobalValues.Orientation.N:
                    if (moduleModelCoords.y < 0)
                    {
                        camTargetPos = new Vector3(currModCenter.x, currModCenter.y, camPos.z);

                    }
                    else
                    {
                        camTargetPos = new Vector3(currModCenter.x, playerPos.y, camPos.z);

                    }

                    break;

                case GlobalValues.Orientation.E:
                    if (moduleModelCoords.x > 0)
                    {
                        camTargetPos = new Vector3(currModCenter.x, currModCenter.y, camPos.z);

                    }
                    else
                    {
                        camTargetPos = new Vector3(playerPos.x, currModCenter.y, camPos.z);

                    }

                    break;

                //curves
                case GlobalValues.Orientation.NE:

                    if (moduleModelCoords.x < 0 && moduleModelCoords.y < 0)                 //epsilon
                    {
                        camTargetPos = new Vector3(currModCenter.x, currModCenter.y, camPos.z);

                    }
                    else if (moduleModelCoords.x < 0)                                       //zheta
                    {
                        camTargetPos = new Vector3(currModCenter.x, playerPos.y, camPos.z);

                    }
                    else if (moduleModelCoords.y < 0)                                       //delta
                    {
                        camTargetPos = new Vector3(playerPos.x, currModCenter.y, camPos.z);

                    }
                    else if ((moduleModelCoords.x > 0) && (moduleModelCoords.y > 0))        //gamma (extra handling)
                    {
                        if (dirVectDot > -0.8f)                                 //north
                        {
                            if (camPos != new Vector3(0.0f, 0.0f, camPos.z))
                            {
                                camTargetPos = new Vector3(currModCenter.x, playerPos.y, camPos.z);

                            }
                        }
                        if (dirVectDot < -0.8f)                                 //east
                        {
                            if (camPos != new Vector3(0.0f, 0.0f, camPos.z))
                            {
                                camTargetPos = new Vector3(playerPos.x, currModCenter.y, camPos.z);

                            }

                        }

                    }

                    break;

                case GlobalValues.Orientation.NW:

                    if (moduleModelCoords.x < 0 && moduleModelCoords.y < 0)                 //epsilon
                    {
                        camTargetPos = new Vector3(playerPos.x, currModCenter.y, camPos.z);

                    }
                    else if (moduleModelCoords.x < 0)                                       //zheta (extra handling)
                    {
                        if (dirVectDot < 0.8f)                                 //north
                        {
                            if (camPos != new Vector3(0.0f, 0.0f, camPos.z))
                            {
                                camTargetPos = new Vector3(currModCenter.x, playerPos.y, camPos.z);

                            }
                        }
                        if (dirVectDot > 0.8f)                                 //west
                        {
                            if (camPos != new Vector3(0.0f, 0.0f, camPos.z))
                            {
                                camTargetPos = new Vector3(playerPos.x, currModCenter.y, camPos.z);

                            }

                        }           
                        
                    }
                    else if (moduleModelCoords.y < 0)                                       //delta
                    {
                        camTargetPos = new Vector3(playerPos.x, currModCenter.y, camPos.z);

                    }
                    else if ((moduleModelCoords.x > 0) && (moduleModelCoords.y > 0))        //gamma
                    {
                        camTargetPos = new Vector3(currModCenter.x, currModCenter.y, camPos.z);

                    }

                    break;

                //straights
                case GlobalValues.Orientation.NS:
                    camTargetPos = new Vector3(currModCenter.x, playerPos.y, camPos.z);

                    break;

                case GlobalValues.Orientation.EW:
                    camTargetPos = new Vector3(currModCenter.y, playerPos.z);

                    break;

                //t-sections
                case GlobalValues.Orientation.NEW:

                    if ((moduleModelCoords.x > 0) && (moduleModelCoords.y > 0))        //gamma (extra handling)
                    {

                        if (dirVectDot > -0.8f)                                 //north
                        {
                            if (camPos != new Vector3(0.0f, 0.0f, camPos.z))
                            {
                                camTargetPos = new Vector3(currModCenter.x, playerPos.y, camPos.z);
                            }
                        }
                        if (dirVectDot < -0.8f)                                 //east
                        {
                            if (camPos != new Vector3(0.0f, 0.0f, camPos.z))
                            {
                                camTargetPos = new Vector3(playerPos.x, currModCenter.y, camPos.z);
                            }

                        }
                    }
                    else if (moduleModelCoords.x < 0)                                 //zheta (extra handling)
                    {


                        if (dirVectDot < 0.8f)                                 //north
                        {
                            if (camPos != new Vector3(0.0f, 0.0f, camPos.z))
                            {
                                camTargetPos = new Vector3(currModCenter.x, playerPos.y, camPos.z);
                            }
                        }
                        if (dirVectDot > 0.8f)                                 //west
                        {
                            if (camPos != new Vector3(0.0f, 0.0f, camPos.z))
                            {
                                camTargetPos = new Vector3(playerPos.x, currModCenter.y, camPos.z);
                            }

                        }
                    }
                    else if (moduleModelCoords.y < 0)                                 //delta/epsilon
                    {
                                camTargetPos = new Vector3(playerPos.x, currModCenter.y, camPos.z);

                    }        
                    
                    break;

                case GlobalValues.Orientation.NES:
                    if ((moduleModelCoords.x > 0) && (moduleModelCoords.y > 0))        //gamma (extra handling)
                    {

                        if (dirVectDot > -0.8f)                                 //north
                        {
                            if (camPos != new Vector3(0.0f, 0.0f, camPos.z))
                            {
                                camTargetPos = new Vector3(currModCenter.x, playerPos.y, camPos.z);
                            }
                        }
                        if (dirVectDot < -0.8f)                                 //east
                        {
                            if (camPos != new Vector3(0.0f, 0.0f, camPos.z))
                            {
                                camTargetPos = new Vector3(playerPos.x, currModCenter.y, camPos.z);
                            }

                        }
                    }
                    else if (moduleModelCoords.x < 0 && moduleModelCoords.x < 0)      //delta (extra handling)
                    {


                        if (dirVectDot > -0.8f)                                 //south
                        {
                            if (camPos != new Vector3(0.0f, 0.0f, camPos.z))
                            {
                                camTargetPos = new Vector3(currModCenter.x, playerPos.y, camPos.z);
                            }
                        }
                        if (dirVectDot < -0.8f)                                 //east
                        {
                            if (camPos != new Vector3(0.0f, 0.0f, camPos.z))
                            {
                                camTargetPos = new Vector3(playerPos.x, currModCenter.y, camPos.z);
                            }

                        }
                    }
                    else if (moduleModelCoords.y < 0)                                 //epsilon/zheta
                    {
                        camTargetPos = new Vector3(currModCenter.x, playerPos.y, camPos.z);

                    }  
                    
                    break;

                //cross
                case GlobalValues.Orientation.NESW:
                    if ((moduleModelCoords.x > 0) && (moduleModelCoords.y > 0))        //gamma (extra handling)
                    {
                        if (dirVectDot > -0.8f)                                 //north
                        {
                            if (camPos != new Vector3(0.0f, 0.0f, camPos.z))
                            {
                                camTargetPos = new Vector3(currModCenter.x, playerPos.y, camPos.z);

                            }
                        }
                        if (dirVectDot < -0.8f)                                 //east
                        {
                            if (camPos != new Vector3(0.0f, 0.0f, camPos.z))
                            {
                                camTargetPos = new Vector3(playerPos.x, currModCenter.y, camPos.z);

                            }
                        }

                    }
                    else if (moduleModelCoords.x < 0 && moduleModelCoords.x < 0)      //delta (extra handling)
                    {
                        if (dirVectDot > -0.8f)                                 //south
                        {
                            if (camPos != new Vector3(0.0f, 0.0f, camPos.z))
                            {
                                camTargetPos = new Vector3(currModCenter.x, playerPos.y, camPos.z);

                            }
                        }
                        if (dirVectDot < -0.8f)                                 //east
                        {
                            if (camPos != new Vector3(0.0f, 0.0f, camPos.z))
                            {
                                camTargetPos = new Vector3(playerPos.x, currModCenter.y, camPos.z);

                            }
                        }

                    }
                    else if (moduleModelCoords.x < 0)                                 //zheta (extra handling)
                    {                        
                        if (dirVectDot < 0.8f)                                 //north
                        {
                            if (camPos != new Vector3(0.0f, 0.0f, camPos.z))
                            {
                                camTargetPos = new Vector3(currModCenter.x, playerPos.y, camPos.z);
                            }

                        }
                        if (dirVectDot > 0.8f)                                 //west
                        {
                            if (camPos != new Vector3(0.0f, 0.0f, camPos.z))
                            {
                                camTargetPos = new Vector3(playerPos.x, currModCenter.y, camPos.z);
                            }

                        }

                    }
                    else if (moduleModelCoords.x < 0 && moduleModelCoords.y < 0)      //epsilon (extra handling)
                    {
                        if (dirVectDot < 0.8f)
                        {
                            if (camPos != new Vector3(0.0f, 0.0f, camPos.z))    //south
                            {
                                camTargetPos = new Vector3(currModCenter.x, playerPos.y, camPos.z);
                            }

                        }
                        if (dirVectDot > 0.8f)                                 //west
                        {
                            if (camPos != new Vector3(0.0f, 0.0f, camPos.z))
                            {
                                camTargetPos = new Vector3(playerPos.x, currModCenter.y, camPos.z);
                            }

                        }

                    }    
                    
                    break;
            }
            
            lerpTime = (camPos - camTargetPos).magnitude / lerpVelocity;
            camLerpedPos.x = Mathf.SmoothDamp(camPos.x, camTargetPos.x, ref velocityX, lerpTime * 1.0f);
            camLerpedPos.y = Mathf.SmoothDamp(camPos.y, camTargetPos.y, ref velocityY, lerpTime * 1.0f);
            GetComponent<Transform>().position = new Vector3(camLerpedPos.x, camLerpedPos.y, camPos.z);
        }


    }


}

/*
 * Explainations:
 * PlayerPosition = playerPos. camPos represents camera position with respect of constraint actions
 * 
 * Switch instructions assign camera Target. camera Target represents the desired camera Position in respect of constraints.
 *      mirrored cases dont have to be split in two cases (e.g. NE and SW are on case, bc the object can be rotated)
 *      
 * After assignment of the camera target the lerpTime multiplicator is calculated  with the distance between position and target position and user speed input (lerpVelocity)
 * Then a lerpedPosition that becomes the real camera position is lerped using the distance dependent lerpTimeMultiplicator (lerpTime)
 
                             if (dirVectDot > 0.8f)                                 //south
                        {
                            if (camPos != new Vector3(0.0f, 0.0f, camPos.z))
                            {
                                camTargetPos = new Vector3(playerPos.x, currModCenter.y, camPos.z);
                            }
                        }
                        if (dirVectDot < 0.8f)                                 //east
                        {
                            if (camPos != new Vector3(0.0f, 0.0f, camPos.z))
                            {
                                camTargetPos = new Vector3(playerPos.x, currModCenter.y, camPos.z);
                            }

                        }
     
     */


