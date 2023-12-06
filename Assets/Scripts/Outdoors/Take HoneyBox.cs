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

    public Transform grabbingPointTransform; // ser om jag kan l�gga ett gameobjekt h�r i, som jag kan sno en Transform fr�n sen

    public GameObject honeyBox; // skapar slot f�r boxLid f�r att kunna manipulera dess tranform sen

    private Rigidbody honeyBoxRb; // m�ste skapa en Rigidbody-variabel f�r att kunna h�nvisa till boxLids Rigidbody

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
            if (Input.GetKeyDown(KeyCode.G)) // Varf�r detta funkar h�r och inte i OnTriggerEnter vet jag inte
            {

                grabbed = true;


            }
        }

        if (grabbed) // ska det inte vara while h�r i st�llet?  Verkar ju funka iofs
        {
            //boxLidRb.MovePosition(grabbingPointTransform.position); // S�tter boxLids tranform + rotation till grabbingPointens. Hade kanske varit enklare att childa boxLid till Player (som Nose) ? 
            //boxLidRb.MoveRotation(grabbingPointTransform.rotation);


            honeyBoxRb.transform.position = grabbingPointTransform.position;   // samma som min kod tror jag 
            honeyBoxRb.transform.rotation = grabbingPointTransform.rotation;   // samma som min kod tror jag 
            honeyBox.transform.parent = grabbingPointTransform;                // S�tter boxLid som child till parent, varf�r vet jag inte riktigt �n varf�r det skulle vara bra
            honeyBoxRb.isKinematic = true;                                     // S�tter boxlid till Kinematic = den har ingen graivty och kan inte flyttas av collisions
            honeyBoxCollider.isTrigger = true;                                 // F�rutom att g�ra till en Trigger -  har ingen fysik och kan inte flytta saker? = om jag har den h�r p� smokerscriptet s� kommer den inet att flytta p� mig. 


        }
    }

    private void OnTriggerEnter(Collider player) // verkar referera till Objektet som g�r in i triggern via dess collider 
    {

        // if-sats som kollar taggen p� objektet, vars collider gick i i triggern

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
