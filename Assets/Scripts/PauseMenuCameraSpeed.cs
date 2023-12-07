using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    public Slider slider; // Assign your panel in the Inspector // Kan ju lika gärna vara en slider

    public TMP_Text pauseText;

    public TMP_Text cameraSpeedText;



    void Start()
    {

        DontDestroyOnLoad(gameObject);
       



        if (slider != null) //Om det finns det ett gameobject i pausePanel sloten här avaktivera den
        {
            
            slider.gameObject.SetActive(false);
            pauseText.gameObject.SetActive(false) ;
            cameraSpeedText.gameObject.SetActive(false);


            slider.onValueChanged.AddListener(ChangeCameraSpeed);
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            TogglePauseMenu();
        }


        if (Input.GetKeyDown(KeyCode.I))
        {
            slider.value = slider.value + 1f;

        }

        if (Input.GetKeyDown(KeyCode.U))
        {
            slider.value = slider.value - 1f;

        }
    }

    void TogglePauseMenu()
    {
        if (slider != null)  // Om du har ett gameObject i pausepanel sloten gör detta (if-sats för att jag inte ska få error) 
        {

            slider.gameObject.SetActive(!slider.gameObject.activeSelf);    // sätt gameObject till sin motsats-state
            pauseText.gameObject.SetActive(!pauseText.gameObject.activeSelf);
            cameraSpeedText.gameObject.SetActive(!cameraSpeedText.gameObject.activeSelf);



            Time.timeScale = (slider.gameObject.activeSelf) ? 0f : 1f;     // Detta är kött och potatis koden för att pausa spelet. 
                                                                    // Time.timescale styr hur snabbt spelet går. 0 = pausat, 1 = fullspeed.
                                                                    // Kedjan i syntaxen: 1. (variabel/bool) 2. ? = vad är boolen 3. Är den false returnera 0, annars 1
                                                                    // Går också att använda t.ex till:  Om input ? > rotera min karaktär - Om inte Input > Rotera inte min karaktär
                                                                    // "?" = samma sak som en if/else sats, men ett smidigare sätt att skriva det på
            
        }
    }

    void ChangeCameraSpeed(float value)
    {
        GameManager.Instance.cameraSpeed = value;
    }
}

