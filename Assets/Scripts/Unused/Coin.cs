using System.Collections;
using System.Collections.Generic;
using UnityEngine;
     
public class Coin: MonoBehaviour
{
    public TextManager textManager;
    public int value;

    public AudioSource objekt_med_audiosource; // skapar slot dit du kan dra ett objekt med en audioSource

    private void OnTriggerEnter(Collider collision)
    {
        objekt_med_audiosource.Play(); // .Play letar upp audiosourcen på objektet och spelar den? 
        textManager.AddCoins(value);
        Destroy(gameObject);
    }

    
   
}
