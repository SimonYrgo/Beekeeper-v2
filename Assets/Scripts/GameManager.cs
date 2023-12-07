using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance; // att skapa en instance betyder att vi skapar en version av klassen i världen som alla script kan komma åt utan att göra den public osv
    public float cameraSpeed;

    // Start is called before the first frame update
    private void Awake()
    {
        Instance = this; 
        
        DontDestroyOnLoad(gameObject);
    }
}
