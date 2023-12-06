using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeeBehavoiur: MonoBehaviour
{

    private ParticleSystem ps;
    
    RemoveLid removelid; // skapat "dold slot" d�r bara ett script av typen (och namnet?) Removelid f�r plats
    
    public bool beesSmoked = false; // bool som kollar om man har gett r�k till bina, man kan ge variabler ett startv�rde (f�r det mesta ) och det blir samma sak som att g�ra det i Startmetoden. 

   


    void Start()
    {
        ps = GetComponent<ParticleSystem>(); // S�tt ps till partikelsystemet du hittar p� detta gameObject

        removelid = GameObject.FindObjectOfType<RemoveLid>(); // fyllt "dold slot" = Leta ute i hela Unity-Hierarkin om du hittar en s�n h�r , och l�gg i s�na fall p� denna plats


    }



    void Update()
    {
        var emission = ps.emission; //varf�r �r denna i Update? �r det s� att ps.emission f�r�ndras hela tiden?  Har iofs f�r mig att man var tvungen att referera till ett partikelsystem med en variabel (ist f direkt).
        
        if (removelid.grabbed)    // anv�nder det i "dold slot" , boolen m�ste vara public i Remove Lid scriptet annars kan jag inte komma �t den verkar det som? Kolla andra script om detta st�mmer         
        {
            emission.rateOverTime = 300f; // p� partikelsystemet finns denna parameter,  som n�r den �kas g�r att partiklarna blir fler tror jag
        }

        if (beesSmoked)
        {
            emission.rateOverTime = 15f;

        }
        
    }

}
    




    

        

        





