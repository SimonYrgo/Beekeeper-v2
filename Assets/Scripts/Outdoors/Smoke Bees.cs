using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SmokeBees : MonoBehaviour
{

    public TMP_Text messageBoard;

    public WindZone windSmoke;

    Smoker smoker; // skapar dold slot d�r det f�r plats ett Smoker objekt

    BeeBehavoiur beeBehavoiur;

    bool canSmokeBees;

    bool hasSmokedBees;

    bool canExtinguishSmoker;


    void Start()
    {
        smoker = GameObject.FindObjectOfType<Smoker>(); // fyller dold slot med ett Smoker object

        beeBehavoiur = GameObject.FindObjectOfType<BeeBehavoiur>();

        canSmokeBees = false;

        hasSmokedBees = false;

        canExtinguishSmoker = true;

        windSmoke.windMain = 0; // S�tter Vinden till O  

    }

    
    void Update()
    {
        if (canSmokeBees) // Kollar om man trycker P f�r att smokea bina
        {

            if (Input.GetKeyDown(KeyCode.P))
            {
               
                windSmoke.windMain = 1;
                Invoke(nameof(DisableWind), 1);
                hasSmokedBees = true;
                beeBehavoiur.beesSmoked = true; // s�tter boolen i BeeBehavoiurscriptet till true
                canSmokeBees = false;



            }

        }

        if (hasSmokedBees  && canExtinguishSmoker) // ev ska man g�ra en bool som heter canExtinguishSmoker el ngt ist�llet -  lite som ovan att man st�nger av m�jlighet till loopen att upprepa sig genom att l�gga en villkor i loopen
        {
            messageBoard.text = "The Bees seem calmer, extinguish smoker with C";

            if (Input.GetKeyDown(KeyCode.C))
            {
                smoker.smokeParticleSystem.Stop();
                smoker.smokerLighted = false; // kan kanske anv�ndas senare
                canExtinguishSmoker = false;

            }


         }

    }

    
    private void DisableWind() // metoden st�nger windSmoke efter 1s n�r man puffar r�k 
    {
            windSmoke.windMain = 0;
    }

    


    private void OnTriggerEnter(Collider player) 

    {  

        if (player.tag == "Player" && smoker.smokerLighted)
        {
            canSmokeBees = true;

            messageBoard.text = "To To Puff Smoke press P";

        }

    }


    private void OnTriggerExit(Collider player) 
    {

        if (player.tag == "Player" && hasSmokedBees && !smoker.smokerLighted)
        {
            {

                smoker.canDropSmoker = true;  // Skickar vidare till Smokerscriptet f�r att kunna droppa smokern

            }

        }

    }





}
