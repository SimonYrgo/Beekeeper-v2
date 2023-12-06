using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndCube : MonoBehaviour
{
    public AudioSource apljud;

    private void OnTriggerEnter(Collider collision)
    {
        //apljud.Play();
        //Destroy(gameObject);
        SceneManager.LoadScene(2);
    }



}



