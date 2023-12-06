using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class WaxTrayInteract : MonoBehaviour
{
    public TMP_Text messageBoard;

    public Transform waxTrayTrigger; // Collider framf�r b�nken som Raycasten ska tr�ffa >skicka vidare till StartCarryingBox > byta Transform p� Honeybox 

    public bool canPutFrameOnStand = false;

    Vector3 lowerRaycast = new Vector3(0, 0, 0); // G�r Vector 3 f�r att kunna subtrahera fr�n Raycasten s� den skjuter lite l�gre

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

            if (hitInfo.transform == waxTrayTrigger && takeFrameHoneybox.frameGrabbed) // f�ruts�tter att objektet har en collider f�r att kunna tr�ffas av raycast
            {

                canPutFrameOnStand = true;

                


            }


        }
    }
}
