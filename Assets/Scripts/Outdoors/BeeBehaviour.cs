using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeeBehavoiur: MonoBehaviour
{

    private ParticleSystem ps;
    
    RemoveLid removelid; // skapat "dold slot" där bara ett script av typen (och namnet?) Removelid får plats
    
    public bool beesSmoked = false; // bool som kollar om man har gett rök till bina, man kan ge variabler ett startvärde (för det mesta ) och det blir samma sak som att göra det i Startmetoden. 

   


    void Start()
    {
        ps = GetComponent<ParticleSystem>(); // Sätt ps till partikelsystemet du hittar på detta gameObject

        removelid = GameObject.FindObjectOfType<RemoveLid>(); // fyllt "dold slot" = Leta ute i hela Unity-Hierarkin om du hittar en sån här , och lägg i såna fall på denna plats


    }



    void Update()
    {
        var emission = ps.emission; //varför är denna i Update? Är det så att ps.emission förändras hela tiden?  Har iofs för mig att man var tvungen att referera till ett partikelsystem med en variabel (ist f direkt).
        
        if (removelid.grabbed)    // använder det i "dold slot" , boolen måste vara public i Remove Lid scriptet annars kan jag inte komma åt den verkar det som? Kolla andra script om detta stämmer         
        {
            emission.rateOverTime = 300f; // på partikelsystemet finns denna parameter,  som när den ökas gör att partiklarna blir fler tror jag
        }

        if (beesSmoked)
        {
            emission.rateOverTime = 15f;

        }
        
    }

}
    




    

        

        





