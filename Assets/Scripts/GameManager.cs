using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance; // att skapa en Instance betyder att vi skapar en version av klassen i v�rlden. Alla script kan komma �t den, utan att referera till via slot eller script. Den �r "public-public" 
    public float cameraSpeed; // Syftet med detta script �r att vi vill spara denna variabels v�rde, s� den inte f�rst�rs vid scenbyte? 
    public GameObject canvas;
    
    private void Awake() // Detta h�nder innan Start-metoden. Kanske bra f�rs�kran f�r att DontDestroyOnLoad ska hinna k�ras? 
    {
        if (Instance == null)
        {
            
            Instance = this; // n�r vi skapar en GameManager Instance skapar vi en slot f�r GameManager Instance. Instance = this fyller den sloten med gameobjektet detta script sitter p�? 
            DontDestroyOnLoad(gameObject); // F�rst�r inte detta objekt vid scenbyte

        }

        else
        {
            Destroy(gameObject);
        }
        
    }
}
