using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SmokeBees : MonoBehaviour
{

    public TMP_Text messageBoard;

    public WindZone windSmoke;

    Smoker smoker; // skapar dold slot där det får plats ett Smoker objekt

    BeeBehavoiur beeBehavoiur;

    bool canSmokeBees;

    bool hasSmokedBees;

    bool canExtinguishSmoker;


    public AudioSource soundPlayer;


    SoundLibrary soundLibrary;


    void Start()
    {
        smoker = GameObject.FindObjectOfType<Smoker>(); // fyller dold slot med ett Smoker object

        beeBehavoiur = GameObject.FindObjectOfType<BeeBehavoiur>();

        canSmokeBees = false;

        hasSmokedBees = false;

        canExtinguishSmoker = true;

        windSmoke.windMain = 0; // Sätter Vinden till O  

        soundLibrary = GameObject.FindAnyObjectByType<SoundLibrary>();

    }

    
    void Update()
    {
        if (canSmokeBees) // Kollar om man trycker P för att smokea bina
        {

            if (Input.GetKeyDown(KeyCode.P))
            {
               
                windSmoke.windMain = 1;
                Invoke(nameof(DisableWind), 1);
                hasSmokedBees = true;
                beeBehavoiur.beesSmoked = true; // sätter boolen i BeeBehavoiurscriptet till true
                canSmokeBees = false;

                soundPlayer.PlayOneShot(soundLibrary.soundsLevel1[3]);

            }

        }

        if (hasSmokedBees  && canExtinguishSmoker) // ev ska man göra en bool som heter canExtinguishSmoker el ngt istället -  lite som ovan att man stänger av möjlighet till loopen att upprepa sig genom att lägga en villkor i loopen
        {
            messageBoard.text = "The Bees seem calmer, extinguish smoker with C";

            if (Input.GetKeyDown(KeyCode.C))
            {
                smoker.smokeParticleSystem.Stop();
                smoker.smokerLighted = false; // kan kanske användas senare
                canExtinguishSmoker = false;

                soundPlayer.PlayOneShot(soundLibrary.soundsLevel1[3]);

            }


         }

    }

    
    private void DisableWind() // metoden stänger windSmoke efter 1s när man puffar rök 
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

                smoker.canDropSmoker = true;  // Skickar vidare till Smokerscriptet för att kunna droppa smokern

            }

        }

    }





}
