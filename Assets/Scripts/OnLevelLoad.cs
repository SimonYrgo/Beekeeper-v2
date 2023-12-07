using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OnLevelLoad : MonoBehaviour  // Detta verkar vara en färdig Unity-metod som körs vid scenbyte?  
{
    private void OnLevelWasLoaded(int level) // vet inte riktigt var den hämtar int level ifrån, men kanske kollar i Scenebuild? 
    {
        if(level == 2) // Om level 2 laddas:
        {
            gameObject.SetActive(false); // Sätt detta Gameobjektet inaktivt
        }
    }
}
