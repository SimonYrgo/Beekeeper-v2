using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance; // att skapa en Instance betyder att vi skapar en version av klassen i världen. Alla script kan komma åt den, utan att referera till via slot eller script. Den är "public-public" 
    public float cameraSpeed; // Syftet med detta script är att vi vill spara denna variabels värde, så den inte förstörs vid scenbyte? 
    public GameObject canvas;
    
    private void Awake() // Detta händer innan Start-metoden. Kanske bra försäkran för att DontDestroyOnLoad ska hinna köras? 
    {
        if (Instance == null)
        {
            
            Instance = this; // när vi skapar en GameManager Instance skapar vi en slot för GameManager Instance. Instance = this fyller den sloten med gameobjektet detta script sitter på? 
            DontDestroyOnLoad(gameObject); // Förstör inte detta objekt vid scenbyte

        }

        else
        {
            Destroy(gameObject);
        }
        
    }
}
