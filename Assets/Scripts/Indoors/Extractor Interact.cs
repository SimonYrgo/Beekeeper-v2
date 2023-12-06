using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ExtractorInteract  : MonoBehaviour
{

    public TMP_Text messageBoard;

    WaxShaverTakeUncappedFrame waxShaverTakeUncappedFrame;

    public int framesLoaded = 0;



    public Transform extractor; // Collider framf�r b�nken som Raycasten ska tr�ffa >skicka vidare till StartCarryingBox > byta Transform p� Honeybox 

    public bool canLoadFrame = false;

    Vector3 lowerRaycast = new Vector3(0, 2, 0); // G�r Vector 3 f�r att kunna subtrahera fr�n Raycasten s� den skjuter lite l�gre


    public Transform extraxtorLoadFrameEmpty; // ser om jag kan l�gga ett gameobjekt h�r i, som jag kan sno en Transform fr�n sen
    public Transform frame;
    private Rigidbody frameRb; // m�ste skapa en Rigidbody-variabel f�r att kunna h�nvisa till frames Rigidbody
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

            if (hitInfo.transform == extractor && canLoadFrame) // f�ruts�tter att objektet har en collider f�r att kunna tr�ffas av raycast
            {

                LoadFrame();

                waxShaverTakeUncappedFrame.unCappedFrameTaken = false; // vi nollst�ller boolen f�r nu h�ller vi inte i den l�ngre

                canLoadFrame = false; // och vi kan inte ladda Extractor utan en frame

                Debug.Log("Kom hit och kollar s� jag inte hamnar i en loop");


            }


        }
    }


    void LoadFrame()
    {

        frameRb = frame.gameObject.GetComponent<Rigidbody>();
        frameCollider = frame.gameObject.GetComponent<Collider>();

        frame.transform.parent = null; // s�tt parent till null p� ditt child innan du byter parent- detta f�r att inte skalan p� childet ska f�r�ndras till att ta relativ skala mot parent.

        frame.transform.position = extraxtorLoadFrameEmpty.position;
        frame.transform.rotation = extraxtorLoadFrameEmpty.rotation;
        frame.transform.parent = extraxtorLoadFrameEmpty;
        frameRb.isKinematic = true;
        frameCollider.isTrigger = true;


        framesLoaded += 1;

        

    }

}
