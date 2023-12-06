using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OtherObjectJump : MonoBehaviour
{
    public GameObject jumper;

    private Rigidbody jumperRigidBody;

    void Start()
    {
         jumperRigidBody = jumper.GetComponent<Rigidbody>();
    }

    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.J))
        {
            jumperRigidBody.AddForce(Vector3.up * 500);
            

        }
    }
}
