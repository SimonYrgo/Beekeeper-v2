using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TakeHoneyBox : MonoBehaviour
{

    public bool canGetHoneyBox = false;

    bool pickUpAble = false;

    bool grabbed = false;

    public TMP_Text messageBoard;

    public Transform grabbingPointTransform; // ser om jag kan lägga ett gameobjekt här i, som jag kan sno en Transform från sen

    public GameObject honeyBox; // skapar slot för boxLid för att kunna manipulera dess tranform sen

    private Rigidbody honeyBoxRb; // måste skapa en Rigidbody-variabel för att kunna hänvisa till boxLids Rigidbody

    private Collider honeyBoxCollider; 

    GoingInside goingInside;


    void Start()
    {
        honeyBoxRb = honeyBox.GetComponent<Rigidbody>();

        honeyBoxCollider = honeyBox.GetComponent<Collider>();

        goingInside = GameObject.FindObjectOfType<GoingInside>();

    }


    void Update()
    {

        if (pickUpAble)
        {
            if (Input.GetKeyDown(KeyCode.G)) // Varför detta funkar här och inte i OnTriggerEnter vet jag inte
            {

                grabbed = true;


            }
        }

        if (grabbed) // ska det inte vara while här i stället?  Verkar ju funka iofs
        {
            //boxLidRb.MovePosition(grabbingPointTransform.position); // Sätter boxLids tranform + rotation till grabbingPointens. Hade kanske varit enklare att childa boxLid till Player (som Nose) ? 
            //boxLidRb.MoveRotation(grabbingPointTransform.rotation);


            honeyBoxRb.transform.position = grabbingPointTransform.position;   // samma som min kod tror jag 
            honeyBoxRb.transform.rotation = grabbingPointTransform.rotation;   // samma som min kod tror jag 
            honeyBox.transform.parent = grabbingPointTransform;                // Sätter boxLid som child till parent, varför vet jag inte riktigt än varför det skulle vara bra
            honeyBoxRb.isKinematic = true;                                     // Sätter boxlid till Kinematic = den har ingen graivty och kan inte flyttas av collisions
            honeyBoxCollider.isTrigger = true;                                 // Förutom att göra till en Trigger -  har ingen fysik och kan inte flytta saker? = om jag har den här på smokerscriptet så kommer den inet att flytta på mig. 


        }
    }

    private void OnTriggerEnter(Collider player) // verkar referera till Objektet som går in i triggern via dess collider 
    {

        // if-sats som kollar taggen på objektet, vars collider gick i i triggern

        if (player.tag == "Player" && canGetHoneyBox)
        {

            //messageBoard.gameObject.SetActive(true);

            messageBoard.text = "To Take Honeybox press G";

            pickUpAble = true;




        }

        
    }

        private void OnTriggerExit(Collider player)
        {

            if (grabbed)
            {

            Debug.Log("grabbed = "+  grabbed);

            messageBoard.text = "Take HoneyBox inside and put on bench";
                goingInside.goingInsideHouse = true;

            }

        }



    }
