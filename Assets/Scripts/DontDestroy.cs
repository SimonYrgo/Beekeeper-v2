using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroy : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if (GameManager.Instance.canvas == null)
        {
            DontDestroyOnLoad(gameObject); // G�r s� detta gameobjektet �verlever scenbyte. Ska bara finnas p� Canvas Outdoors, level-scenen tror jag? 
            GameManager.Instance.canvas = gameObject;

        }

        else
        {
            Destroy(gameObject);
        }



    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
