using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    public Slider slider; 

    public TMP_Text pauseText;

    public TMP_Text cameraSpeedText;



    void Start()
    {

        DontDestroyOnLoad(gameObject); // F�rst�r inte detta gameobject n�r en ny scen laddas
       



        if (slider != null) //Om det finns det ett gameobject  i pausePanel-sloten h�r: 
        {
            
            slider.gameObject.SetActive(false);           // avaktivera dessa
            pauseText.gameObject.SetActive(false) ;
            cameraSpeedText.gameObject.SetActive(false);


            slider.onValueChanged.AddListener(ChangeCameraSpeed); // om sliderns v�rde �ndras (onValueChanged = bool) > AddListener kollar till vad v�rdet �ndras > Returnerar v�rde (och kallar metoden) ChangeCameraSpeed?  
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            TogglePauseMenu();
        }

        if (Time.timeScale == 0)
        {
            if (Input.GetKeyDown(KeyCode.K))
            {
                slider.value = slider.value + 1f;

            }

            if (Input.GetKeyDown(KeyCode.J))
            {
                slider.value = slider.value - 1f;

            }

        }

    }



        

    void TogglePauseMenu()
    {
        if (slider != null)  // Om du har ett gameObject i pausepanel sloten g�r detta (if-sats f�r att jag inte ska f� error om jag inte har n�got) 
        {

            slider.gameObject.SetActive(!slider.gameObject.activeSelf);    // s�tt gameObject till sin motsats-state
            pauseText.gameObject.SetActive(!pauseText.gameObject.activeSelf);
            cameraSpeedText.gameObject.SetActive(!cameraSpeedText.gameObject.activeSelf);



            Time.timeScale = (slider.gameObject.activeSelf) ? 0f : 1f; // K�tt och potatis-koden f�r att pausa spelet. 
                                                                    // Time.timescale styr hur snabbt spelet g�r. 0 = pausat, 1 = fullspeed.
                                                                    // Kedjan i syntaxen: 1. (variabel/bool) 2. ? = vad �r boolen 3. �r den false returnera 0, annars 1
                                                                    // G�r ocks� att anv�nda t.ex till:  Om input > rotera min karakt�r - Om inte Input > Rotera inte min karakt�r
                                                                    // "?" = samma sak som en if/else sats, men ett smidigare s�tt att skriva det p�
            
        }
    }

    void ChangeCameraSpeed(float value)
    {
        GameManager.Instance.cameraSpeed = value;
    }
}

