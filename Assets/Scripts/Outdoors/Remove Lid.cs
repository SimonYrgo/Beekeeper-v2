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
    
    public TMP_Text messageBoard; // Skapar slot för att kunna skriva meddelanden i Game Message TMP-Textobjektet


    bool pickUpAble;

    public bool grabbed;

    bool canDropLid;

    public bool lidDropped;



    public Transform grabbingPointTransform; // ser om jag kan lägga ett gameobjekt här i, som jag kan sno en Transform från sen

    public GameObject boxLid; // skapar slot för boxLid för att kunna manipulera dess tranform sen

    private Rigidbody boxLidRb; // måste skapa en Rigidbody-variabel för att kunna hänvisa till boxLids Rigidbody

    private Collider boxLidCollider;



    void Start()
    {
        pickUpAble = false;

        grabbed = false;

        canDropLid = false;

        lidDropped = false;

        boxLidRb = boxLid.GetComponent<Rigidbody>(); // hämtar Rigidbodyn från GameObjectet i sloten boxLid

        boxLidCollider = boxLid.GetComponent<Collider>();
}

    
    private void OnTriggerEnter(Collider player) // verkar referera till Objektet som går in i triggern via dess collider 
    {

        // if-sats som kollar taggen på objektet, vars collider gick i i triggern

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
            if (Input.GetKeyDown(KeyCode.R)) // Varför detta funkar här och inte i OnTriggerEnter vet jag inte
            {
                
                grabbed = true;

            
            }
        }

        if (grabbed) // ska det inte vara while här i stället?  Verkar ju funka iofs
        {
            //boxLidRb.MovePosition(grabbingPointTransform.position); // Sätter boxLids tranform + rotation till grabbingPointens. Hade kanske varit enklare att childa boxLid till Player (som Nose) ? 
            //boxLidRb.MoveRotation(grabbingPointTransform.rotation);

            
            boxLidRb.transform.position = grabbingPointTransform.position;   // samma som min kod tror jag 
            boxLidRb.transform.rotation = grabbingPointTransform.rotation;   // samma som min kod tror jag 
            boxLid.transform.parent = grabbingPointTransform;                // Sätter boxLid som child till parent, varför vet jag inte riktigt än varför det skulle vara bra
            boxLidRb.isKinematic = true;                                     // Sätter boxlid till Kinematic = den har ingen graivty och kan inte flyttas av collisions
            boxLidCollider.isTrigger = true;                                 // Förutom att göra till en Trigger -  har ingen fysik och kan inte flytta saker? = om jag har den här på smokerscriptet så kommer den inet att flytta på mig. 

           

            // boxLidRb.useGravity = false; // Om den är trigger har den ingen gravity. 

            

            if (Input.GetKeyDown(KeyCode.E) && canDropLid) // funktion för att släppa boxLid på marken när man gått ur TriggerCollidern vid kupan
            {

                boxLid.transform.parent = null;
                boxLidRb.isKinematic = false;                                     // Sätter boxlid till Kinematic = den har ingen graivty och kan inte flyttas av collisions
                boxLidCollider.isTrigger = false;

                grabbed = false;

                boxLidRb.useGravity = true;

                messageBoard.text = "The bees seem angry, maybe you should try some smoke? ";

                canDropLid = false;

                pickUpAble = false; // så att man inte kan plocka upp lid igen när den är på marken
                
                // GetComponent<Collider>().enabled = false; // stänger av Collidern på detta gameobjectet, inte riktigt det jag ville men funkar för att inte tjata om Remove Lid.
                                                          // .. Kan ju också förstöra textPanelerna eter hand men då får man kanske error om man inte kör Try Set Active el liknande. 

                lidDropped = true; // testar detta så kan jag behålla Collidern på istället. 
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
