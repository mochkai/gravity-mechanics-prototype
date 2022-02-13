using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 10f;
    public LayerMask obstaclesMask;

    private Rigidbody myRigidbody;
    private Vector3 moveAmount;
    private Vector3 moveDir;
    private Vector3 smothMoveVelocity;
    private Color rayColor = Color.yellow;
    private Text debugText;

    void Start()
    {
        myRigidbody = GetComponent<Rigidbody>();
        Debug.Log(GameObject.Find("debugLog"));
        debugText = GameObject.Find("debugLog").GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        moveDir = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical")).normalized;
        float moveAngle = Mathf.Atan2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")) * Mathf.Rad2Deg;

        String debug = "";
        debug += "moveAngle: " + moveAngle + "\n";

        if (moveDir.magnitude == 1)
            transform.rotation = Quaternion.AngleAxis(moveAngle, transform.up);

        debug += "Horizontal: " + Input.GetAxisRaw("Horizontal") + "\n";

        debug += "Vertical: " + Input.GetAxisRaw("Vertical") + "\n";

        Vector3 targetMoveAmount = transform.forward * moveDir.magnitude * moveSpeed;

        debug += "targetMoveAmount: " + targetMoveAmount.ToString() + "\n";

        moveAmount = Vector3.SmoothDamp(moveAmount, targetMoveAmount, ref smothMoveVelocity, 0.05f);

        debug += "moveAmount: " + moveAmount.ToString() + "\n";
        debug += "moveDir.magnitude: " + moveDir.magnitude + "\n";

        //Ray directionRay = new Ray(transform.position, transform.forward);
        //RaycastHit hit;

        rayColor = Color.yellow;

        //if (Physics.Raycast(directionRay, out hit, 1f))
        //{
        //    Debug.Log("Hit: " + hit.collider);
        //    rayColor = Color.red;
        //    smothMoveVelocity = Vector3.zero;
        //    moveAmount = Vector3.zero;
        //}

        Debug.DrawRay(transform.position, transform.forward * 10f, rayColor);
        debugText.text = debug;
    }

    void FixedUpdate()
    {
        myRigidbody.MovePosition(myRigidbody.position + moveAmount * Time.deltaTime);
    }
}
