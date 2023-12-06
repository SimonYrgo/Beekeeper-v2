using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class ExtractorOperate : MonoBehaviour
{
    public Transform startPosition; // Set start position from an empty object in the scene
    public Transform endPosition; // Set end position from an empty object in the scene
    public Slider speedSlider; // Reference the slider in the Unity Editor
    public float speedMultiplier = 1f;

    public float lerpDuration = 2f; // representerar ca: 2s // Men säger eg. inget innan man jämför det med Time.deltaTime där nere, det är också bara ett startvärde som vi ändrar nedan
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



        if (Input.GetKeyDown(KeyCode.P) && canMakeHoney) // lägg till && canMakeHoney;
        {
            

            // Toggle the lerping flag
            isLerping = !isLerping; // sätt boolen att det ska börja lerpa till sin motsas

            currentLerpTime = 0f; // If lerping is started, initialize the lerp time and duration

            messageBoard.text = "Extracting Honey"; // samma här - funkar bara en millisekund

            extractorInteract.framesLoaded = 0; // Enda sättet jag kom på just nu att få bort meddellandet- "Press P to Start Extractor"

        }



        float speed = speedSlider.value; // hämta värdet i en float från speedSlider.value

        lerpDuration = (Vector3.Distance(startPosition.position, endPosition.position) + speedMultiplier)/ speed; // här reglerar vi den egentliga hastigheten på hur snabbt en Lerp Loop ska gå. Speedmultiplier = tillagt värde för mer kontroll, speed = slidern


        // Check if lerping is active
        if (isLerping)
        {
            // Increment the lerp time based on the elapsed time since the last frame
            currentLerpTime += Time.deltaTime; // timertid från att loopen börjar

            // Ensure the lerp time doesn't exceed the specified duration
            if (currentLerpTime > lerpDuration) // när looptiden slut: gör detta
            {
                currentLerpTime = 0f; // Reset lerp time for the next loop // börja om från början och byt positionerna
                
                Vector3 tempPosition = startPosition.position;
                startPosition.position = endPosition.position;
                endPosition.position = tempPosition;    

            }

            // Calculate the interpolation factor between 0 and 1
            float t = currentLerpTime / lerpDuration;

            // Lerp the position between the start and end positions
            transform.position = Vector3.Lerp(startPosition.position, endPosition.position, t); // kan kan göra detta med waxremove tray och till ex skriva 3 * Delta time ist. ref dörr öpnnas 10 ggr deltattime 


        }





    }
}