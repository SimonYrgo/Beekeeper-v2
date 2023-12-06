using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{

    public TextManager textManager;
    public int damage;

    private void OnTriggerEnter(Collider collision)
    {
        gameObject.GetComponent<AudioSource>().Play(); // Spela ljudet på AudioSource-komponenten på detta objekt.
        // vill du skelettet ska försvinna efteråt  så får du nog ha audiosource på ett annat objekt för ljud kan inte spelas om du destroyar object. 

        textManager.playerDamage(damage);

    }



}

