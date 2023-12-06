using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class ExtractorTimer : MonoBehaviour
{
    public Slider slider;

    public TMP_Text timerText;

    public TMP_Text extractorSpeedControl;

    public TMP_Text messageboard;

    ExtractorOperate extractorMoveLerp;

    float totalTime = 75f;

    float sliderDefautValue;


    ChangeHoneyColor changeHoneyColor;


    // Start is called before the first frame update
    void Start()
    {
        extractorMoveLerp = GameObject.FindObjectOfType<ExtractorOperate>();

        // sliderDefautValue = slider.minValue;   // ..om vi �ndrar i Unity p� Sliderns v�rde s� beh�ver vi inte �ndra den h�r, flyttar ner den till Update f�r vill ha den oaktiverad till den ska anv�ndas

        slider.gameObject.SetActive(false);

        extractorSpeedControl.gameObject.SetActive(false);

        changeHoneyColor = GameObject.FindObjectOfType<ChangeHoneyColor>();

    }






    // Update is called once per frame
    void Update()
    {

        if (extractorMoveLerp.isLerping) // Detta �r en klockfunktion som r�knar ner i tid p� Slungan och p�verkas av hur snabbt man s�tter hastigheten i slidern
        {

            slider.gameObject.SetActive(true);
            
            sliderDefautValue = slider.minValue;

            extractorSpeedControl.gameObject.SetActive(true);

            totalTime -= Time.deltaTime * (1 + slider.value -sliderDefautValue); // s� som inst�llt nu s� blir slidern 0 i v�rde och vi l�gger till1 f�r att den ska r�r sig alls p� klockan
            timerText.text = Mathf.Round(totalTime).ToString();

            if (totalTime <= 0) // m�ste vara <= f�r time.Deltatime kan bli mindre �n 0 beroende p� n�r v�r funktion kallas
            {
                extractorMoveLerp.isLerping = false;

                timerText.text = "Finished!!!";

                messageboard.text = "";

                changeHoneyColor.ChangeColor();

               Invoke(nameof(LoadEndScene), 3f);
            }

        }

        if(Input.GetKeyDown(KeyCode.I)) 
        {
            slider.value = slider.value + 1f;
            
        }

        if (Input.GetKeyDown(KeyCode.U))
        {
            slider.value = slider.value - 1f;

        }


    }

    private void LoadEndScene()
    {
        SceneManager.LoadSceneAsync(3);
    }
}
