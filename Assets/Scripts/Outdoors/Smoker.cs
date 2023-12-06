using System.Collections;
using System.Collections.Generic;
// using System.Diagnostics;
using UnityEngine;
using TMPro;

/*
 *  
 */





public class Smoker : MonoBehaviour
{

    public TMP_Text messageBoard; // Skapar slot för att kunna skriva meddelanden i Game Message TMP-Textobjektet

    public ParticleSystem smokeParticleSystem; 


    bool pickUpAble;

    bool grabbed;

    public bool smokerLighted; // kan kanske användas senare

    public bool canDropSmoker; // ska användas senare

    public bool smokerDropped;


    RemoveLid isLidDropped;

    DoorInteract doorInteract;

    



    public Transform grabbingPointTransform; // ser om jag kan lägga ett gameobjekt här i, som jag kan sno en Transform från sen

    public GameObject smoker; // skapar slot för smoker för att kunna manipulera dess tranform sen

    // public WindZone windSmoke;

    private Rigidbody smokerRb; // måste skapa en Rigidbody-variabel för att kunna hänvisa till smoker Rigidbody

    private Collider smokerCollider;



    void Start()
    {
        isLidDropped = GameObject.FindObjectOfType<RemoveLid>();

        doorInteract = GameObject.FindObjectOfType<DoorInteract>();      

        pickUpAble = false;

        grabbed = false;

        smokerLighted = false;

        canDropSmoker = false; // ska användas senare

        smokerDropped = false;

        smokerRb = smoker.GetComponent<Rigidbody>(); // hämtar Rigidbodyn från GameObjectet i sloten smoker

        smokerCollider = smoker.GetComponent<Collider>();

        smokeParticleSystem = smokeParticleSystem.GetComponent<ParticleSystem>(); // måste man göra det? kanske .. 

        smokeParticleSystem.Stop();

       // windSmoke.windMain = 0; // Sätter Vinden till O  

       



}


    private void OnTriggerEnter(Collider player) // verkar referera till Objektet som går in i triggern via dess collider 
    {

        // if-sats som kollar taggen på objektet, vars collider gick i i triggern mfl villkor

        if (player.tag == "Player" && !smokerDropped && isLidDropped.lidDropped) // Om Player går in här -- OCH smoker inte är Dropped -- OCH lid är dropped (man ska inte kunna plocka upp smoker innan lid) 
        {

            //messageBoard.gameObject.SetActive(true);

            messageBoard.text = "To pick up smoker press P";

            pickUpAble = true;




        }

        
    }

    private void Update()
    {
        if (pickUpAble) // om man kan plocka upp smoker >
        {
            if (Input.GetKeyDown(KeyCode.P)) //  > Trycker man P? 
            {

                grabbed = true;              //  > sätt grabbed till True


            }
        }

        if (grabbed) // > sätt iså fall grabbed till trur och flytta på smokers position 
        {
            //smokerRb.MovePosition(grabbingPointTransform.position); // min kod kör Carls nedan istället. 
            //smokerRb.MoveRotation(grabbingPointTransform.rotation);
            // smokerRb.useGravity = false;


            // Grabfunktionen nedan skulle kunna vara en metod utanför update,  som man bara kallar en gång? 

            smokerRb.transform.position = grabbingPointTransform.position;   // gör samma som min kod tror jag 
            smokerRb.transform.rotation = grabbingPointTransform.rotation;   // gör samma som min kod tror jag 
            smoker.transform.parent = grabbingPointTransform;                // Sätter boxLid som child till parent, varför vet jag inte riktigt än varför det skulle vara bra
            smokerRb.isKinematic = true;                                     // Sätter boxlid till Kinematic = den har ingen graivty och kan inte flyttas av collisions
            smokerCollider.isTrigger = true;                                 // Förutom att göra till en Trigger -  har ingen fysik och kan inte flytta saker? .. > 
                                                                             // > ..  = om jag har den här på smokerscriptet så kommer den inet att flytta på mig. 


            if (Input.GetKeyDown(KeyCode.L))                                // Drar igång smokeParticleSystem och sätter boolen smokerLighted till true
            {

                smokeParticleSystem.Play();                                  
                smokerLighted = true; // kan kanske användas senare
                messageBoard.text = "Smoker lighted, go give bees smoke.";

            }

            /*

            if (Input.GetKeyDown(KeyCode.P) && smokerLighted) // Sätter på windSmoke, väntar 1 s innan den kallar metod som disablar
            {

                // Debug.Log("P nedtryckt");
                windSmoke.windMain = 1;
                Invoke(nameof(DisableWind), 1);
            }



            */


            if (canDropSmoker)
            {

                messageBoard.text = "Press E to Drop Smoker";

                if (Input.GetKeyDown(KeyCode.E) ) // funktion för att släppa smoker på marken när man gått ur TriggerCollidern vid kupan. Detta ska inte hända ännu så koden är utkommenterad. 
                {
                    grabbed = false;

                    smoker.transform.parent = null;
                    smokerRb.isKinematic = false;
                    smokerCollider.isTrigger = false;

                    

                    canDropSmoker = false;

                    pickUpAble = false;

                    smokerDropped = true;

                    doorInteract.doorCanOpen = true;

                    messageBoard.text = "Open Door to Shed with Q";
                }

                

            }

           
        }


    }


    private void OnTriggerExit(Collider player) // Här måste vi ändra i kedjan för vad som ska hända
    {

        if (player.tag == "Player")
        {


            // canDropSmoker = true;   // denna ska inte bli sann ännu var ska vi lägga den tror på BeeHive Trigger? 




            if (grabbed)
            {
                messageBoard.text = "To líght Smoker press L";


                

            }



        }

    }

    /*

    public void DisableWind() // metoden stänger windSmoke efter 1s när man puffar rök 
    {
        windSmoke.windMain = 0;
    }

    */

}

