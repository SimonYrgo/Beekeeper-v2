using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

/* DETTA SCRIPT ANVÄNDS INTE JUST NU
 * 
 * 
 */

public class TakeUncappedFrame : MonoBehaviour
{
    WaxShaverTakeUncappedFrame waxShaver;  // se om vi kan ta frame från den som object?

    public TMP_Text messageBoard;

    public bool canTakeUncappedFrame = false;

    public bool uncappedFrameTaken = false;



    void Start()
    {
        waxShaver = GameObject.FindAnyObjectByType<WaxShaverTakeUncappedFrame>();    


    }
            

    
    void Update()
    {

        if (canTakeUncappedFrame)
        {

            messageBoard.text = "Press P to pick up uncapped frame";

            if (Input.GetKeyUp(KeyCode.P))
            {

                Debug.Log("Snart Frame Upplockad");

                messageBoard.text = "";

            }


        }

    }


    private void OnTriggerEnter(Collider player)
    {
        if (player.tag == "PLayer" && waxShaver.frameUncapped)
        {
            canTakeUncappedFrame = true;
        }


    }

    private void OnTriggerStay(Collider player)
    {
        if (player.tag == "PLayer" && waxShaver.frameUncapped)
        {
            canTakeUncappedFrame = true;
        }
    }

    private void OnTriggerExit(Collider player)
    {
        if (player.tag == "PLayer" && canTakeUncappedFrame)
        {
            canTakeUncappedFrame = false;
            messageBoard.text = "";
        }


    } 







}
