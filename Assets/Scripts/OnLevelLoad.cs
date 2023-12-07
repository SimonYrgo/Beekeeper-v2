using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OnLevelLoad : MonoBehaviour
{
    private void OnLevelWasLoaded(int level)
    {
        if(level == 2)
        {
            gameObject.SetActive(false);
        }
    }
}
