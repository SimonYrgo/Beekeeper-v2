using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseManager : MonoBehaviour
{

    void Start()
    {
        Cursor.lockState = CursorLockMode.None; //  Eftersom vi s�ger i de tidigare scenerna att musen ska va l�st och osynlig, s� h�nger det med till slutet och g�r s� att man inte kan trycka p� knappen.
        Cursor.visible = true;                  // Dessa 2 rader l�ser detta                
    }

}   
