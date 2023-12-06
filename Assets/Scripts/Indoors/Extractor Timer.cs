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

        // sliderDefautValue = slider.minValue;   // ..om vi ändrar i Unity på Sliderns värde så behöver vi inte ändra den här, flyttar ner den till Update för vill ha den oaktiverad till den ska användas

        slider.gameObject.SetActive(false);

        extractorSpeedControl.gameObject.SetActive(false);

        changeHoneyColor = GameObject.FindObjectOfType<ChangeHoneyColor>();

    }






    // Update is called once per frame
    void Update()
    {

        if (extractorMoveLerp.isLerping) // Detta är en klockfunktion som räknar ner i tid på Slungan och påverkas av hur snabbt man sätter hastigheten i slidern
        {

            slider.gameObject.SetActive(true);
            
            sliderDefautValue = slider.minValue;

            extractorSpeedControl.gameObject.SetActive(true);

            totalTime -= Time.deltaTime * (1 + slider.value -sliderDefautValue); // så som inställt nu så blir slidern 0 i värde och vi lägger till1 för att den ska rör sig alls på klockan
            timerText.text = "Time left:  " + Mathf.Round(totalTime).ToString();

            if (totalTime <= 0) // måste vara <= för time.Deltatime kan bli mindre än 0 beroende på när vår funktion kallas
            {
                extractorMoveLerp.isLerping = false;

                timerText.text = "Finished!!!";

                messageboard.text = "";

                changeHoneyColor.ChangeColor();

               Invoke(nameof(LoadEndScene), 2f);
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
