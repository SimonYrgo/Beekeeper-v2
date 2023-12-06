using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeHoneyColor : MonoBehaviour
{
    
    /*

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            gameObject.GetComponent<Renderer>().material.color = new Color (0.9f, 0.6f, 0.1f,1); // Funkade !!!
        }
    }

    */
    
    public void ChangeColor()
    {
        gameObject.GetComponent<Renderer>().material.color = new Color (0.9f, 0.6f, 0.1f,1);
    }

    
}
