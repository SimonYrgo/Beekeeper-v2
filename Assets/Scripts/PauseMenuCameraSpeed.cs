using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    public Slider slider; // Assign your panel in the Inspector // Kan ju lika g�rna vara en slider

    public TMP_Text pauseText;

    public TMP_Text cameraSpeedText;



    void Start()
    {

        DontDestroyOnLoad(gameObject);
       



        if (slider != null) //Om det finns det ett gameobject i pausePanel sloten h�r avaktivera den
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
        if (slider != null)  // Om du har ett gameObject i pausepanel sloten g�r detta (if-sats f�r att jag inte ska f� error) 
        {

            slider.gameObject.SetActive(!slider.gameObject.activeSelf);    // s�tt gameObject till sin motsats-state
            pauseText.gameObject.SetActive(!pauseText.gameObject.activeSelf);
            cameraSpeedText.gameObject.SetActive(!cameraSpeedText.gameObject.activeSelf);



            Time.timeScale = (slider.gameObject.activeSelf) ? 0f : 1f;     // Detta �r k�tt och potatis koden f�r att pausa spelet. 
                                                                    // Time.timescale styr hur snabbt spelet g�r. 0 = pausat, 1 = fullspeed.
                                                                    // Kedjan i syntaxen: 1. (variabel/bool) 2. ? = vad �r boolen 3. �r den false returnera 0, annars 1
                                                                    // G�r ocks� att anv�nda t.ex till:  Om input ? > rotera min karakt�r - Om inte Input > Rotera inte min karakt�r
                                                                    // "?" = samma sak som en if/else sats, men ett smidigare s�tt att skriva det p�
            
        }
    }

    void ChangeCameraSpeed(float value)
    {
        GameManager.Instance.cameraSpeed = value;
    }
}

