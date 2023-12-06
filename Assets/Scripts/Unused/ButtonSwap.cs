/*

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class ButtonSwap : MonoBehaviour
{
    SwapQuads swapper; // skapar variablen swapper att spara ett SwapQuads script /metod i ? 
    Button thisButton; // skapar en variabel att refera till en Button med
    public int row1, col1, row2, col2; // skapar slots på denna Buttonkanppen för 4 ints  = koordinater i vår Multiarray. Vi matar in dessa i Unity och använder nedan 


    // Start is called before the first frame update
    void Start()
    {

        

        thisButton = GetComponent<Button>(); // this Button =  Button på detta Objekt 
        swapper = GameObject.FindObjectOfType<SwapQuads>(); // letar i hela Hierarkin efter ett GameObject som i sin tur innehåller ett " SwapQuads"-objekt" (vårt script)
                                                            // Sätter varibeln swapper = detta script. Flera olika sorters find finns
        thisButton.onClick.AddListener(() => { swapper.Swap(row1, col1, row2, col2); }); // när vi klickar på Button:kör Swap metoden i swapper-variablen
                                                                                         // skicka med public int-värdena i row1, col1, row2, col2


    }


    
}

*/
