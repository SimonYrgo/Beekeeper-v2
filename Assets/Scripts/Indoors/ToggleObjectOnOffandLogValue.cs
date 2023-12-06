using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Runtime.CompilerServices;


/*
 * Det här scriptet gör inte så mycket ännu, bara loggar slider.value om det ändras 
 * 
 * 
 */

public class ToggleObjectOnOffandLogValue : MonoBehaviour
{

    public Slider slider;

    private float extractorSpeed;

    float previousSliderValue;



    private void Start()
    {
        previousSliderValue = slider.value;
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            // objectToToggle.SetActive(!objectToToggle.activeSelf) // - om det bara är ett vanligt allmänt gameobject kan man göra så här..

            slider.gameObject.SetActive(!slider.gameObject.activeSelf); // ..men med en slider får man göra så här = sätt bool till motsats (om objektet på, stäng av - och tvärtom)


        }

        



        if (slider.value != previousSliderValue)
        {
            // Log the new value to the console
            Debug.Log("Slider value changed to: " + slider.value);

            // Update the previousSliderValue with the current value
            previousSliderValue = slider.value;
        }
    }

   

}
