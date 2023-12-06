using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;



public class StartStopCarryingBox : MonoBehaviour
{

    public TMP_Text messageBoard; // Skapar slot för att kunna skriva meddelanden i Game Message TMP-Textobjektet
    public Transform grabbingPointTransform; // ser om jag kan lägga ett gameobjekt här i, som jag kan sno en Transform från sen

    public GameObject honeyBox; // skapar slot för boxLid för att kunna manipulera dess tranform sen
    private Rigidbody honeyBoxRb; // verkar som att även om man hänvisar till samma  gameobject måste man ändå skapa en slot på samma vis som om man tar in från ett annat script
    private Collider honeyBoxCollider; // ..samma sak med collider. Men dessutom klagade den om man inte satte "new"- ordet framför

    public Transform boxPlaceOnBench; // Hit ska HoneyBox sättas, till en emptys Transform
    private BenchInteract benchInteract;

    public bool hasPutBoxOnBench = false;


    void Start()
    {
        benchInteract = GameObject.FindObjectOfType<BenchInteract>();      

        BeginMessage();

        honeyBoxRb = honeyBox.GetComponent<Rigidbody>();
        honeyBoxCollider = honeyBox.GetComponent<Collider>();


        honeyBoxRb.transform.position = grabbingPointTransform.position;   // samma som min kod tror jag 
        honeyBoxRb.transform.rotation = grabbingPointTransform.rotation;   // samma som min kod tror jag 
        honeyBox.transform.parent = grabbingPointTransform;                // Sätter boxLid som child till parent, varför vet jag inte riktigt än varför det skulle vara bra


        honeyBoxRb.isKinematic = true;                                     // Sätter boxlid till Kinematic = den har ingen graivty och kan inte flyttas av collisions
        honeyBoxCollider.isTrigger = true;                                 // Förutom att göra till en Trigger -  har ingen fysik och kan inte flytta saker? = om jag har den här på smokerscriptet så kommer den inet att flytta på mig. 
    }

    private void Update()
    {
        if (benchInteract.canPutBoxOnBench && !hasPutBoxOnBench)
        {

            honeyBox.transform.parent = null;

            honeyBoxRb.transform.position = boxPlaceOnBench.position;
            honeyBoxRb.transform.rotation = boxPlaceOnBench.rotation;
            honeyBox.transform.parent = boxPlaceOnBench; // = null om man vill un-parenta den               


            

            Invoke(nameof(GiveHoneyBoxBackPhysics), 0.5f); 


            benchInteract.canPutBoxOnBench = false; 
            hasPutBoxOnBench=true;

            // Debug.Log("hasPutBoxOnBench: " + hasPutBoxOnBench);


        }
    }


    void  BeginMessage()
    {

        messageBoard.text = "Put Honey Box on bench";
    }

    void GiveHoneyBoxBackPhysics()
    {
        honeyBoxRb.isKinematic = false;                                     // Sätter boxlid till Kinematic = den har ingen graivty och kan inte flyttas av collisions
        honeyBoxCollider.isTrigger = false;
    }


}

