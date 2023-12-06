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
        // Kan läsa av Musen 
        float newRotationX = transform.localEulerAngles.y + Input.GetAxis("Mouse X") * cameraSpeed;
        // local = bara i förhållande till sig själv, bara rotation på y-axeln, dvs rotation runt uppåt-snöret i Unity, 
        // detta ger oss ett nytt rotationsvärde för y axeln på objektet. 

        

        float newRotationY = transform.localEulerAngles.x - Input.GetAxis("Mouse Y") * cameraSpeed; // Samma sak fast upp/ner med musen. Kommenterade ut, för tyckte det var lite rörigt med upp/ner funktionen. 
                                                                                                    // detta ger oss ett nytt rotationsvärde för x-axeln på objektet. 

        if (newRotationY > 280 && newRotationY < 300) // Begränsa möjlighet för kamerans Y-rörelse när du tittar neråt
        {
            newRotationY = Mathf.Clamp(newRotationY, 300f, 360f);        
        }

        if (newRotationY > 80 && newRotationY < 90)  // samma sak fast när du tiiatr uppåt
        {
            newRotationY = Mathf.Clamp(newRotationY, 0f, 80f);
        }



        Vector3 desiredRotation = new Vector3(newRotationY, newRotationX, 0);
        transform.localEulerAngles = desiredRotation;
        //// ta floaterna ovan och bygg ny vektor array av. Jag kommenterade ut newRotationY ovan för tyckte det var lite rörigt med upp/ner funktionen. 




        // Om du bara vill styra i en riktning så aktivera dessa rader nedan och avaktivera rad  19, 21,  22 .. (eg. 17-25) eller tvärtom om du vill kunna styra upp/ner också
        // Vector3 desiredRotation = new Vector3(0, newRotationX, 0); 
        // transform.localEulerAngles = desiredRotation;



        Vector3 desiredPosition = target.position - transform.forward * followDistance; // vet ej vad denna gör exakt .position är väl samma som objektet man drar till target-slotens position.
                                                                                        // transform.forward är nog också en position som är lite längre fram än .position
        transform.position = desiredPosition; // kameran ska följa spelaren. Tror transform med litet t syftar på detta gameObjectet och stort T parent objektet.  

        



    }
}
