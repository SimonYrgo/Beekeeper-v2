using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxInteract : MonoBehaviour
{
    public Transform theRealHoneyBox; // Collider framför bänken som Raycasten ska träffa >skicka vidare till StartCarryingBox > byta Transform på Honeybox 

    StartStopCarryingBox startStopCarryingBox; // skapar referens till StartStopCarryingBox för att kunna hämta boolen hasPutBoxOnBench

    Vector3 lowerRaycast = new Vector3 (0, 0, 0); // Gör Vector 3 för att kunna addera/subtrahera från Raycasten så den skjuter lite högre/lägre

    public bool canTakeFrame = false;


    void Start()
    {
        
        startStopCarryingBox = GameObject.FindObjectOfType<StartStopCarryingBox>(); ;

    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hitInfo = new RaycastHit();
        bool hit = Physics.Raycast(transform.position + lowerRaycast, transform.forward, out hitInfo, 2f);

        if (hit)
        {

            Debug.Log("Reached outer- if loop");

            if (hitInfo.transform == theRealHoneyBox && startStopCarryingBox.hasPutBoxOnBench ) // förutsätter att objektet har en collider för att kunna träffas av raycast
            {
                canTakeFrame = true;
                //Debug.Log("Reached inner if-loop" + canTakeFrame);
            }

            else
            {
                canTakeFrame= false;
                //Debug.Log("Reached inner else-loop" + canTakeFrame);
            }
        }

        else
        {

            Debug.Log("Reached outer - else loop");
            canTakeFrame = false;
        }


           
    }
}
