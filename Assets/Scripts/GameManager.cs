using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance; // att skapa en instance betyder att vi skapar en version av klassen i v�rlden som alla script kan komma �t utan att g�ra den public osv
    public float cameraSpeed;

    // Start is called before the first frame update
    private void Awake()
    {
        Instance = this; 
        
        DontDestroyOnLoad(gameObject);
    }
}
