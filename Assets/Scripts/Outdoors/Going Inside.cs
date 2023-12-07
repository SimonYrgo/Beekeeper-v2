using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoingInside : MonoBehaviour
{

    public bool goingInsideHouse = false;

    

    OpenDoor openDoor;


    private void Start()
    {
        
        openDoor = GameObject.FindObjectOfType<OpenDoor>();

    }


    private void OnTriggerEnter(Collider collision)
    {

        if (goingInsideHouse)
        {
            
            // openDoor.Close();

            
            SceneManager.LoadScene(2);
            

        }

        
    }



}
