using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckCollider : MonoBehaviour
{
    TakeFrameHoneybox takeFrameHoneybox;

    private void Start()
    {
        
        takeFrameHoneybox = GameObject.FindObjectOfType<TakeFrameHoneybox>();

    }

    private void OnTriggerEnter (Collider player)
    {
        if (player.tag == "Player")//  && takeFrameHoneybox.framePutOnStand)
        {
            Debug.Log("Hi");

            Debug.Log(takeFrameHoneybox.framePutOnStand);

        }

    }



    private void OnTriggerStay(Collider player)
    {
        if (player.tag == "Player" && takeFrameHoneybox.framePutOnStand)
        {
            Debug.Log("Hi");

            Debug.Log(takeFrameHoneybox.framePutOnStand);
            
        }

    }

    private void OnTriggerExit(Collider player)
    {
        if (player.tag == "Player" && takeFrameHoneybox.framePutOnStand)
        {
            Debug.Log("Bye");

            Debug.Log(takeFrameHoneybox.framePutOnStand);

        }
    }
}
