using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OnLevelLoad : MonoBehaviour  // Detta verkar vara en f�rdig Unity-metod som k�rs vid scenbyte?  
{
    private void OnLevelWasLoaded(int level) // vet inte riktigt var den h�mtar int level ifr�n, men kanske kollar i Scenebuild? 
    {
        if(level == 2) // Om level 2 laddas:
        {
            gameObject.SetActive(false); // S�tt detta Gameobjektet inaktivt
        }
    }
}
