using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxInteract : MonoBehaviour
{
    public Transform theRealHoneyBox; // Collider framf�r b�nken som Raycasten ska tr�ffa >skicka vidare till StartCarryingBox > byta Transform p� Honeybox 

    StartStopCarryingBox startStopCarryingBox; // skapar referens till StartStopCarryingBox f�r att kunna h�mta boolen hasPutBoxOnBench

    Vector3 lowerRaycast = new Vector3 (0, 0, 0); // G�r Vector 3 f�r att kunna addera/subtrahera fr�n Raycasten s� den skjuter lite h�gre/l�gre

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

            if (hitInfo.transform == theRealHoneyBox && startStopCarryingBox.hasPutBoxOnBench ) // f�ruts�tter att objektet har en collider f�r att kunna tr�ffas av raycast
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
