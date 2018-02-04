using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBehaviourScript : MonoBehaviour
{
    //var dec
    [SerializeField] private float speed = 1.0f;
    private Vector3 V3target;
    public int CamState { get; set; }
    private float pathLength, coveredDistance;
    private Transform TfPlayer;

 //var init
	private void Start ()
    {
        TfPlayer = GameObject.FindWithTag(TagSystemClass.playerTag).transform;
        V3target = new Vector3(TfPlayer.position.x, transform.position.y, TfPlayer.position.z);
        CamState = 0;

	}

    //funct def
    void PosHandler()
    {        
        if (CamState == 0)
        {
            SetTarget(TfPlayer.position);
            transform.position = new Vector3(V3target.x, transform.position.y, V3target.z);
        }
        else if (CamState == 1)
        {

            //target is set in PlayerBehaviour c33
            pathLength = Vector3.Distance(TfPlayer.position, V3target);
            coveredDistance = Vector3.Distance(TfPlayer.position, transform.position);

            transform.position = Vector3.Lerp(transform.position, V3target, pathLength / coveredDistance);

        }
                
        

    }

    public void SetTarget(Vector3 target)
    {
        V3target = new Vector3(target.x, transform.position.y, target.z);

    }
    /*
    public void SetState(System.String str)
    {
        if (str == "sync")
        {
            CamState = State.sync;

        }
        else if(str == "delay")
        {
            CamState = State.delay;

        }

    }*/

 //unity calls
	void Update ()
    {

        PosHandler();
                
	}
}
