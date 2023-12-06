using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{

    public TextManager textManager;
    public int damage;

    private void OnTriggerEnter(Collider collision)
    {
        gameObject.GetComponent<AudioSource>().Play(); // Spela ljudet p� AudioSource-komponenten p� detta objekt.
        // vill du skelettet ska f�rsvinna efter�t  s� f�r du nog ha audiosource p� ett annat objekt f�r ljud kan inte spelas om du destroyar object. 

        textManager.playerDamage(damage);

    }



}

