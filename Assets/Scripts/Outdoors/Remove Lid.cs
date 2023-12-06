using System.Collections;
using System.Collections.Generic;
// using System.Diagnostics;
using UnityEngine;
using TMPro;

/*
 * 
 * 
 */






public class RemoveLid : MonoBehaviour
{
    
    public TMP_Text messageBoard; // Skapar slot f�r att kunna skriva meddelanden i Game Message TMP-Textobjektet


    bool pickUpAble;

    public bool grabbed;

    bool canDropLid;

    public bool lidDropped;



    public Transform grabbingPointTransform; // ser om jag kan l�gga ett gameobjekt h�r i, som jag kan sno en Transform fr�n sen

    public GameObject boxLid; // skapar slot f�r boxLid f�r att kunna manipulera dess tranform sen

    private Rigidbody boxLidRb; // m�ste skapa en Rigidbody-variabel f�r att kunna h�nvisa till boxLids Rigidbody

    private Collider boxLidCollider;



    void Start()
    {
        pickUpAble = false;

        grabbed = false;

        canDropLid = false;

        lidDropped = false;

        boxLidRb = boxLid.GetComponent<Rigidbody>(); // h�mtar Rigidbodyn fr�n GameObjectet i sloten boxLid

        boxLidCollider = boxLid.GetComponent<Collider>();
}

    
    private void OnTriggerEnter(Collider player) // verkar referera till Objektet som g�r in i triggern via dess collider 
    {

        // if-sats som kollar taggen p� objektet, vars collider gick i i triggern

        if (player.tag == "Player" && !lidDropped)
        {

            //messageBoard.gameObject.SetActive(true);

            messageBoard.text = "To Remove Lid Press R";

            pickUpAble = true;

            
            

        }

         // Debug.Log("lidDropped " + lidDropped); // Kollade om lidDropped funkade
    }

    private void Update() 
    {
        if(pickUpAble)
        {
            if (Input.GetKeyDown(KeyCode.R)) // Varf�r detta funkar h�r och inte i OnTriggerEnter vet jag inte
            {
                
                grabbed = true;

            
            }
        }

        if (grabbed) // ska det inte vara while h�r i st�llet?  Verkar ju funka iofs
        {
            //boxLidRb.MovePosition(grabbingPointTransform.position); // S�tter boxLids tranform + rotation till grabbingPointens. Hade kanske varit enklare att childa boxLid till Player (som Nose) ? 
            //boxLidRb.MoveRotation(grabbingPointTransform.rotation);

            
            boxLidRb.transform.position = grabbingPointTransform.position;   // samma som min kod tror jag 
            boxLidRb.transform.rotation = grabbingPointTransform.rotation;   // samma som min kod tror jag 
            boxLid.transform.parent = grabbingPointTransform;                // S�tter boxLid som child till parent, varf�r vet jag inte riktigt �n varf�r det skulle vara bra
            boxLidRb.isKinematic = true;                                     // S�tter boxlid till Kinematic = den har ingen graivty och kan inte flyttas av collisions
            boxLidCollider.isTrigger = true;                                 // F�rutom att g�ra till en Trigger -  har ingen fysik och kan inte flytta saker? = om jag har den h�r p� smokerscriptet s� kommer den inet att flytta p� mig. 

           

            // boxLidRb.useGravity = false; // Om den �r trigger har den ingen gravity. 

            

            if (Input.GetKeyDown(KeyCode.E) && canDropLid) // funktion f�r att sl�ppa boxLid p� marken n�r man g�tt ur TriggerCollidern vid kupan
            {

                boxLid.transform.parent = null;
                boxLidRb.isKinematic = false;                                     // S�tter boxlid till Kinematic = den har ingen graivty och kan inte flyttas av collisions
                boxLidCollider.isTrigger = false;

                grabbed = false;

                boxLidRb.useGravity = true;

                messageBoard.text = "The bees seem angry, maybe you should try some smoke? ";

                canDropLid = false;

                pickUpAble = false; // s� att man inte kan plocka upp lid igen n�r den �r p� marken
                
                // GetComponent<Collider>().enabled = false; // st�nger av Collidern p� detta gameobjectet, inte riktigt det jag ville men funkar f�r att inte tjata om Remove Lid.
                                                          // .. Kan ju ocks� f�rst�ra textPanelerna eter hand men d� f�r man kanske error om man inte k�r Try Set Active el liknande. 

                lidDropped = true; // testar detta s� kan jag beh�lla Collidern p� ist�llet. 
            }


        }


    }


    private void OnTriggerExit(Collider player) 
    {

        if (player.tag == "Player")
        {
            

            canDropLid = true;

            


            if (grabbed)
            {
                messageBoard.text = "Good, now drop lid on ground (E)";

                


            }

            

        }

    }


}
