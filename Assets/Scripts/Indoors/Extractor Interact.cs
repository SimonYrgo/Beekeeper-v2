using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ExtractorInteract  : MonoBehaviour
{

    public TMP_Text messageBoard;

    WaxShaverTakeUncappedFrame waxShaverTakeUncappedFrame;

    public int framesLoaded = 0;



    public Transform extractor; // Collider framför bänken som Raycasten ska träffa >skicka vidare till StartCarryingBox > byta Transform på Honeybox 

    public bool canLoadFrame = false;

    Vector3 lowerRaycast = new Vector3(0, 2, 0); // Gör Vector 3 för att kunna subtrahera från Raycasten så den skjuter lite lägre


    public Transform extraxtorLoadFrameEmpty; // ser om jag kan lägga ett gameobjekt här i, som jag kan sno en Transform från sen
    public Transform frame;
    private Rigidbody frameRb; // måste skapa en Rigidbody-variabel för att kunna hänvisa till frames Rigidbody
    private Collider frameCollider;



    void Start()
    {
        waxShaverTakeUncappedFrame = GameObject.FindAnyObjectByType<WaxShaverTakeUncappedFrame>();

    }



    void Update()
    {
        RaycastHit hitInfo = new RaycastHit();
        bool hit = Physics.Raycast(transform.position - lowerRaycast, transform.forward, out hitInfo, 2f);


        if (waxShaverTakeUncappedFrame.unCappedFrameTaken == true)
        {

            canLoadFrame = true;    
        }




        if (hit)
        {

            if (hitInfo.transform == extractor && canLoadFrame) // förutsätter att objektet har en collider för att kunna träffas av raycast
            {

                LoadFrame();

                waxShaverTakeUncappedFrame.unCappedFrameTaken = false; // vi nollställer boolen för nu håller vi inte i den längre

                canLoadFrame = false; // och vi kan inte ladda Extractor utan en frame

                Debug.Log("Kom hit och kollar så jag inte hamnar i en loop");


            }


        }
    }


    void LoadFrame()
    {

        frameRb = frame.gameObject.GetComponent<Rigidbody>();
        frameCollider = frame.gameObject.GetComponent<Collider>();

        frame.transform.parent = null; // sätt parent till null på ditt child innan du byter parent- detta för att inte skalan på childet ska förändras till att ta relativ skala mot parent.

        frame.transform.position = extraxtorLoadFrameEmpty.position;
        frame.transform.rotation = extraxtorLoadFrameEmpty.rotation;
        frame.transform.parent = extraxtorLoadFrameEmpty;
        frameRb.isKinematic = true;
        frameCollider.isTrigger = true;


        framesLoaded += 1;

        

    }

}
