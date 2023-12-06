using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class ExtractorOperate : MonoBehaviour
{
    public Transform startPosition; // Set start position from an empty object in the scene
    public Transform endPosition; // Set end position from an empty object in the scene
    public Slider speedSlider; // Reference the slider in the Unity Editor
    public float speedMultiplier = 1f;

    public float lerpDuration = 2f; // representerar ca: 2s // Men s�ger eg. inget innan man j�mf�r det med Time.deltaTime d�r nere, det �r ocks� bara ett startv�rde som vi �ndrar nedan
    private float currentLerpTime = 0f;
    public bool isLerping = false;

    public bool canMakeHoney;

    public TMP_Text messageBoard;


    ExtractorInteract extractorInteract;


    void Start()
    {
            
        extractorInteract = GameObject.FindAnyObjectByType<ExtractorInteract>();

    }


    void Update()
    {

        if ( extractorInteract.framesLoaded == 1 && !isLerping)
        {
            canMakeHoney = true;

            messageBoard.text = "Press P to Start Extractor";

            
        }



        if (Input.GetKeyDown(KeyCode.P) && canMakeHoney) // l�gg till && canMakeHoney;
        {
            

            // Toggle the lerping flag
            isLerping = !isLerping; // s�tt boolen att det ska b�rja lerpa till sin motsas

            currentLerpTime = 0f; // If lerping is started, initialize the lerp time and duration

            messageBoard.text = "Extracting Honey, Time Left:"; // samma h�r - funkar bara en millisekund

            extractorInteract.framesLoaded = 0; // Enda s�ttet jag kom p� just nu att f� bort meddellandet- "Press P to Start Extractor"

        }



        float speed = speedSlider.value; // h�mta v�rdet i en float fr�n speedSlider.value

        lerpDuration = (Vector3.Distance(startPosition.position, endPosition.position) + speedMultiplier)/ speed; // h�r reglerar vi den egentliga hastigheten p� hur snabbt en Lerp Loop ska g�. Speedmultiplier = tillagt v�rde f�r mer kontroll, speed = slidern


        // Check if lerping is active
        if (isLerping)
        {
            // Increment the lerp time based on the elapsed time since the last frame
            currentLerpTime += Time.deltaTime; // timertid fr�n att loopen b�rjar

            // Ensure the lerp time doesn't exceed the specified duration
            if (currentLerpTime > lerpDuration) // n�r looptiden slut: g�r detta
            {
                currentLerpTime = 0f; // Reset lerp time for the next loop // b�rja om fr�n b�rjan och byt positionerna
                
                Vector3 tempPosition = startPosition.position;
                startPosition.position = endPosition.position;
                endPosition.position = tempPosition;    

            }

            // Calculate the interpolation factor between 0 and 1
            float t = currentLerpTime / lerpDuration;

            // Lerp the position between the start and end positions
            transform.position = Vector3.Lerp(startPosition.position, endPosition.position, t); // kan kan g�ra detta med waxremove tray och till ex skriva 3 * Delta time ist. ref d�rr �pnnas 10 ggr deltattime 


        }





    }
}