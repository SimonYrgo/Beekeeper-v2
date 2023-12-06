using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BenchInteract : MonoBehaviour
{
    
    public Transform benchTrigger; // Collider framför bänken som Raycasten ska träffa >skicka vidare till StartCarryingBox > byta Transform på Honeybox 

    public bool canPutBoxOnBench = false;

    Vector3 lowerRaycast = new Vector3 (0, 2, 0); // Gör Vector 3 för att kunna subtrahera från Raycasten så den skjuter lite lägre

    


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

            if (hitInfo.transform == benchTrigger) // förutsätter att objektet har en collider för att kunna träffas av raycast
            {

                canPutBoxOnBench = true;


            }

           
        }
    }
}

   

