using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour
{

    public GameObject target;
    public float targetDistance = 5f;


    private Vector3 offset;

    //private void Start()
    //{
    //    transform.position = target.transform.position + target.transform.up * targetDistance + Vector3.forward * -5;
    //    transform.LookAt(target.transform, Vector3.up);
    //}

    void LateUpdate()
    {
        transform.position = target.transform.position + (target.transform.up * targetDistance) + (target.transform.up + Vector3.back) * 2;
        transform.rotation = target.transform.rotation;
        transform.LookAt(target.transform,Vector3.up);
    }
}