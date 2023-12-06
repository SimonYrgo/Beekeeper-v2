using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;



public class Hamburger : MonoBehaviour
{

    // högst upp skiver man oftast sina variabler (praxis) 

    public AudioClip clip_1;
    public AudioClip clip_2;
    public AudioClip clip_3;
    
    public TextManager textManager;

    public AudioClip[] hamburgarLjud = new AudioClip[3];

    
    private void Start()
    {
        // i Start voiden skriver man det som ska vara klart till andra funkioner i scriptet att jobba med

        for (int i = 0; i < hamburgarLjud.Length; i++)
        {
            if (i == 0)
            {
                hamburgarLjud[i] = clip_1;
            }
            else if (i == 1)
            {
                hamburgarLjud[i] = clip_2;
            }
            else if (i == 2)
            {
                hamburgarLjud[i] = clip_3;
            }


        }
    }



    private void OnTriggerEnter(Collider collision) // hämta collidern som går in i min trigger
    {
        // collision.gameObject.GetComponent<AudioSource>().PlayOneShot(clip_1);
        // andra sättet att spela upp 

        // collision.gameObject.GetComponent<AudioSource>().PlayOneShot(hamburgarLjud[1]);
        // spelar nu ljudet i hamburgarLjud arrayet på indexplats 1

        // int r = 0;



        int r = Random.Range(0, hamburgarLjud.Length);
        // i funktionen Random ger detta resulat randomvärde mellan 0-2. hamburgarLjud.Length = 3 och är taket
        // (min värde inkluderat, maxvärde exkluderat)

        // dock men inte på float..så här gör man där se nedan 
        // float r = Random.Range(0f, 3f);
        // (min värde inkluderat, maxvärde inkluderat)

        r = collision.gameObject.GetComponent<CharacterMove>().duplicateSoundChecker(r, hamburgarLjud.Length);
        // GetComponent<> pilar referar till vilken komponent, () = eftersom GetComponent är metod,
        // vi hämtar metoden.duplicateSoundChecker i CharacterMove scriptet och matar med "r" och hamburgarLjud.Length



        collision.gameObject.GetComponent<AudioSource>().PlayOneShot(hamburgarLjud[r]);
        // spelar nu upp ett randomljud av de 3 som finns i arrayet

        // Debug.Log(hamburgarLjud[r]);
        // printar vilken arrayplats som spelar just nu via denna funktion
        // Nödvändigt att ha att kunna print debugga 


        textManager.playerHeal(2);
        Destroy(gameObject);


    }



}
