using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    public Transform target;
    public float followDistance = 8f;
    public float cameraSpeed = 3f;
    private void LateUpdate() // bra att anv till cameran, motverkar att det hackar  
    {
        // Kan l�sa av Musen 
        float newRotationX = transform.localEulerAngles.y + Input.GetAxis("Mouse X") * cameraSpeed;
        // local = bara i f�rh�llande till sig sj�lv, bara rotation p� y-axeln, dvs rotation runt upp�t-sn�ret i Unity, 
        // detta ger oss ett nytt rotationsv�rde f�r y axeln p� objektet. 

        

        float newRotationY = transform.localEulerAngles.x - Input.GetAxis("Mouse Y") * cameraSpeed; // Samma sak fast upp/ner med musen. Kommenterade ut, f�r tyckte det var lite r�rigt med upp/ner funktionen. 
                                                                                                    // detta ger oss ett nytt rotationsv�rde f�r x-axeln p� objektet. 

        if (newRotationY > 280 && newRotationY < 300) // Begr�nsa m�jlighet f�r kamerans Y-r�relse n�r du tittar ner�t
        {
            newRotationY = Mathf.Clamp(newRotationY, 300f, 360f);        
        }

        if (newRotationY > 80 && newRotationY < 90)  // samma sak fast n�r du tiiatr upp�t
        {
            newRotationY = Mathf.Clamp(newRotationY, 0f, 80f);
        }



        Vector3 desiredRotation = new Vector3(newRotationY, newRotationX, 0);
        transform.localEulerAngles = desiredRotation;
        //// ta floaterna ovan och bygg ny vektor array av. Jag kommenterade ut newRotationY ovan f�r tyckte det var lite r�rigt med upp/ner funktionen. 




        // Om du bara vill styra i en riktning s� aktivera dessa rader nedan och avaktivera rad  19, 21,  22 .. (eg. 17-25) eller tv�rtom om du vill kunna styra upp/ner ocks�
        // Vector3 desiredRotation = new Vector3(0, newRotationX, 0); 
        // transform.localEulerAngles = desiredRotation;



        Vector3 desiredPosition = target.position - transform.forward * followDistance; // vet ej vad denna g�r exakt .position �r v�l samma som objektet man drar till target-slotens position.
                                                                                        // transform.forward �r nog ocks� en position som �r lite l�ngre fram �n .position
        transform.position = desiredPosition; // kameran ska f�lja spelaren. Tror transform med litet t syftar p� detta gameObjectet och stort T parent objektet.  

        



    }
}
