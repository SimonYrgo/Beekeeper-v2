using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BenchInteract : MonoBehaviour
{
    
    public Transform benchTrigger; // Collider framf�r b�nken som Raycasten ska tr�ffa >skicka vidare till StartCarryingBox > byta Transform p� Honeybox 

    public bool canPutBoxOnBench = false;

    Vector3 lowerRaycast = new Vector3 (0, 2, 0); // G�r Vector 3 f�r att kunna subtrahera fr�n Raycasten s� den skjuter lite l�gre

    


    void Start()
    {
        

            
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hitInfo = new RaycastHit();
        bool hit = Physics.Raycast(transform.position - lowerRaycast, transform.forward, out hitInfo, 2f);

        if (hit)
        {

            if (hitInfo.transform == benchTrigger) // f�ruts�tter att objektet har en collider f�r att kunna tr�ffas av raycast
            {

                canPutBoxOnBench = true;


            }

           
        }
    }
}

   

