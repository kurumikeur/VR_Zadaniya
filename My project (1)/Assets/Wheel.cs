using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;



public class Wheel : MonoBehaviour
{
    public GameObject obj;
    public GameObject drive;
    Vector3 buff;
    float angle;
    // Start is called before the first frame update
    void Start()
    {
        buff = obj.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        angle = drive.GetComponent<CircularDrive>().outAngle;
        obj.transform.position = buff + new Vector3((float)0.075 * angle / 360, 0, 0) ;

    }
}
