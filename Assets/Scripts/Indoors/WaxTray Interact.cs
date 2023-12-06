using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class WaxTrayInteract : MonoBehaviour
{
    public TMP_Text messageBoard;

    public Transform waxTrayTrigger; // Collider framför bänken som Raycasten ska träffa >skicka vidare till StartCarryingBox > byta Transform på Honeybox 

    public bool canPutFrameOnStand = false;

    Vector3 lowerRaycast = new Vector3(0, 0, 0); // Gör Vector 3 för att kunna subtrahera från Raycasten så den skjuter lite lägre

    TakeFrameHoneybox takeFrameHoneybox;




    void Start()
    {

        takeFrameHoneybox = GameObject.FindAnyObjectByType<TakeFrameHoneybox>();

    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hitInfo = new RaycastHit();
        bool hit = Physics.Raycast(transform.position - lowerRaycast, transform.forward, out hitInfo, 2f);

        if (hit)
        {

            if (hitInfo.transform == waxTrayTrigger && takeFrameHoneybox.frameGrabbed) // förutsätter att objektet har en collider för att kunna träffas av raycast
            {

                canPutFrameOnStand = true;

                


            }


        }
    }
}
