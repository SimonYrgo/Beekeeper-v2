using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;



public class StartStopCarryingBox : MonoBehaviour
{

    public TMP_Text messageBoard; // Skapar slot f�r att kunna skriva meddelanden i Game Message TMP-Textobjektet
    public Transform grabbingPointTransform; // ser om jag kan l�gga ett gameobjekt h�r i, som jag kan sno en Transform fr�n sen

    public GameObject honeyBox; // skapar slot f�r boxLid f�r att kunna manipulera dess tranform sen
    private Rigidbody honeyBoxRb; // verkar som att �ven om man h�nvisar till samma  gameobject m�ste man �nd� skapa en slot p� samma vis som om man tar in fr�n ett annat script
    private Collider honeyBoxCollider; // ..samma sak med collider. Men dessutom klagade den om man inte satte "new"- ordet framf�r

    public Transform boxPlaceOnBench; // Hit ska HoneyBox s�ttas, till en emptys Transform
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
        honeyBox.transform.parent = grabbingPointTransform;                // S�tter boxLid som child till parent, varf�r vet jag inte riktigt �n varf�r det skulle vara bra


        honeyBoxRb.isKinematic = true;                                     // S�tter boxlid till Kinematic = den har ingen graivty och kan inte flyttas av collisions
        honeyBoxCollider.isTrigger = true;                                 // F�rutom att g�ra till en Trigger -  har ingen fysik och kan inte flytta saker? = om jag har den h�r p� smokerscriptet s� kommer den inet att flytta p� mig. 
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
        honeyBoxRb.isKinematic = false;                                     // S�tter boxlid till Kinematic = den har ingen graivty och kan inte flyttas av collisions
        honeyBoxCollider.isTrigger = false;
    }


}

