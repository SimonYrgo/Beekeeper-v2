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


    // bool pickUpAble; // Vi använder istället StartStopCarryingBox.hasPutBoxOnBench eller är det vår egen canTakeFrame vi använder?  

    public bool frameGrabbed = false;

    public bool framePutOnStand = false;  // vi använder istället för frame = dropped



    public Transform grabbingPointTransform; // ser om jag kan lägga ett gameobjekt här i, som jag kan sno en Transform från sen

    public GameObject frame; // skapar slot för frame för att kunna manipulera dess tranform sen

    private Rigidbody frameRb; // måste skapa en Rigidbody-variabel för att kunna hänvisa till frames Rigidbody

    private Collider frameCollider;




    public Transform framePlaceOnStand;





    void Start()
    {
        startStopCarryingBox = GameObject.FindAnyObjectByType<StartStopCarryingBox>();

        waxTrayInteract = GameObject.FindAnyObjectByType<WaxTrayInteract>();    

    }






    private void OnTriggerEnter(Collider player)

    {
        if (player.tag == "Player" && startStopCarryingBox.hasPutBoxOnBench && !frameGrabbed && !framePutOnStand) // Om raycasten träffar en Collider OCH jag har satt kupan på bänken OCh inte bär på en frame redan: 
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

            if (frameRb == null) // && frameCollider == null, men tror det räcker med Rigidbody
            {

                createRbAndCollider();

            }


            

            if (waxTrayInteract.canPutFrameOnStand) 
            {

                frame.transform.parent = null;

                frameRb.transform.position = framePlaceOnStand.position;
                frameRb.transform.rotation = framePlaceOnStand.rotation;
                frame.transform.parent = framePlaceOnStand; // = null om man vill un-parenta den               


                // Invoke(nameof(GiveFrameBackPhysics), 0.5f); // När jag sätter på fysiken igen med denna funktion, så blir det sket konstigt

                waxTrayInteract.canPutFrameOnStand = false;     // vi kan inte kängre sätta frame på Stand..>
                framePutOnStand = true;                        // ..eftersom vi har nu satt frame på stand

                // Debug.Log("framePutOnStand" + framePutOnStand); // Vi kommer hit

                frameGrabbed = false; // vi håller inte längre i frame

            }



        }

        void createRbAndCollider() // Jag lägger denna metoden utanför Update  -  för av någon anledning funkade det bättre än inuti if-satsen rad 112 ?
        {
            frameRb = frame.AddComponent<Rigidbody>();  // skapar en Rigidbody och Collider i runtime, så inte den ska ramla ner i marken innan. Man hade ju kunnat ha den iaktiverad innan men fick det inte att funka
            frameCollider = frame.AddComponent<BoxCollider>();   // Den tyckte inte om att jag skapade bara Collider, men boxCollider gick bra

            frameRb = frame.GetComponent<Rigidbody>(); // hämtar Rigidbodyn från GameObjectet i sloten frame
            frameCollider = frame.GetComponent<Collider>(); // samma med collidern

            frame.transform.parent = null; // sätt parent till null på ditt child innan du byter parent- detta för att inte skalan på childet ska förändras till att ta relativ skala mot parent. Det är en svaghet i Unity att det är på detta sätt

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
