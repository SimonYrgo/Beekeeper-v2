using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseManager : MonoBehaviour
{

    void Start()
    {
        Cursor.lockState = CursorLockMode.None; //  Eftersom vi säger i de tidigare scenerna att musen ska va låst och osynlig, så hänger det med till slutet och gör så att man inte kan trycka på knappen.
        Cursor.visible = true;                  // Dessa 2 rader löser detta                
    }

}   
