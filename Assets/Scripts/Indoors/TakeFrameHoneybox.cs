using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using static TMPro.SpriteAssetUtilities.TexturePacker_JsonArray;

public class TakeFrameHoneybox : MonoBehaviour
{
    public TMP_Text messageBoard;

    public bool canTakeFrame = false;

    StartStopCarryingBox startStopCarryingBox;

    WaxTrayInteract waxTrayInteract;


    // bool pickUpAble; // Vi anv�nder ist�llet StartStopCarryingBox.hasPutBoxOnBench eller �r det v�r egen canTakeFrame vi anv�nder?  

    public bool frameGrabbed = false;

    public bool framePutOnStand = false;  // vi anv�nder ist�llet f�r frame = dropped



    public Transform grabbingPointTransform; // ser om jag kan l�gga ett gameobjekt h�r i, som jag kan sno en Transform fr�n sen

    public GameObject frame; // skapar slot f�r frame f�r att kunna manipulera dess tranform sen

    private Rigidbody frameRb; // m�ste skapa en Rigidbody-variabel f�r att kunna h�nvisa till frames Rigidbody

    private Collider frameCollider;




    public Transform framePlaceOnStand;





    void Start()
    {
        startStopCarryingBox = GameObject.FindAnyObjectByType<StartStopCarryingBox>();

        waxTrayInteract = GameObject.FindAnyObjectByType<WaxTrayInteract>();    

    }






    private void OnTriggerEnter(Collider player)

    {
        if (player.tag == "Player" && startStopCarryingBox.hasPutBoxOnBench && !frameGrabbed && !framePutOnStand) // Om raycasten tr�ffar en Collider OCH jag har satt kupan p� b�nken OCh inte b�r p� en frame redan: 
        {

            // Debug.Log("Entered Take Frame Trigger Collider");
            
            canTakeFrame = true;

            // Debug.Log("canTakeFrame: " + canTakeFrame);

            messageBoard.text = "Take frame from Box (T)";



        }
    }

  

    private void OnTriggerExit(Collider player) 
    {
        if (player.tag == "Player" && startStopCarryingBox.hasPutBoxOnBench)
        {

            // Debug.Log("Exited Take Frame Trigger Collider");

            canTakeFrame = false;

            // Debug.Log("canTakeFrame: " + canTakeFrame);

            messageBoard.text = "";
        }

    }


    void Update()
    {
        if (canTakeFrame)
        {
            if (Input.GetKeyDown(KeyCode.T))
            {
                // Debug.Log("You Pressed T");

                messageBoard.text = "";

                frameGrabbed = true;

            }

        }

        if (frameGrabbed)
        {
            messageBoard.text = "Put frame on Wax Removal Stand";

            if (frameRb == null) // && frameCollider == null, men tror det r�cker med Rigidbody
            {

                createRbAndCollider();

            }


            

            if (waxTrayInteract.canPutFrameOnStand) 
            {

                frame.transform.parent = null;

                frameRb.transform.position = framePlaceOnStand.position;
                frameRb.transform.rotation = framePlaceOnStand.rotation;
                frame.transform.parent = framePlaceOnStand; // = null om man vill un-parenta den               


                // Invoke(nameof(GiveFrameBackPhysics), 0.5f); // N�r jag s�tter p� fysiken igen med denna funktion, s� blir det sket konstigt

                waxTrayInteract.canPutFrameOnStand = false;     // vi kan inte k�ngre s�tta frame p� Stand..>
                framePutOnStand = true;                        // ..eftersom vi har nu satt frame p� stand

                // Debug.Log("framePutOnStand" + framePutOnStand); // Vi kommer hit

                frameGrabbed = false; // vi h�ller inte l�ngre i frame

            }



        }

        void createRbAndCollider() // Jag l�gger denna metoden utanf�r Update  -  f�r av n�gon anledning funkade det b�ttre �n inuti if-satsen rad 112 ?
        {
            frameRb = frame.AddComponent<Rigidbody>();  // skapar en Rigidbody och Collider i runtime, s� inte den ska ramla ner i marken innan. Man hade ju kunnat ha den iaktiverad innan men fick det inte att funka
            frameCollider = frame.AddComponent<BoxCollider>();   // Den tyckte inte om att jag skapade bara Collider, men boxCollider gick bra

            frameRb = frame.GetComponent<Rigidbody>(); // h�mtar Rigidbodyn fr�n GameObjectet i sloten frame
            frameCollider = frame.GetComponent<Collider>(); // samma med collidern

            frame.transform.parent = null; // s�tt parent till null p� ditt child innan du byter parent- detta f�r att inte skalan p� childet ska f�r�ndras till att ta relativ skala mot parent. Det �r en svaghet i Unity att det �r p� detta s�tt

            frameRb.transform.position = grabbingPointTransform.position;
            frameRb.transform.rotation = grabbingPointTransform.rotation;
            frame.transform.parent = grabbingPointTransform;
            frameRb.isKinematic = true;
            frameCollider.isTrigger = true;

        }
    }

    void GiveFrameBackPhysics()
    {
        frameRb.isKinematic = false;                                     
        frameCollider.isTrigger = false;
    }

}
