using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMove : MonoBehaviour
{
    public Transform cameraTransform;
    public float movementSpeed = 5f;
    

    Rigidbody body; // skapa en variabel som hämtar 
    float horizontal;
    float vertical;

    public AudioSource jumpSound;
    
    
    private int lastRandomInt = 0;  // Detta lagrar värdet av int r i Hamburger-scriptet för att jämföra
                                    // så man inte slumpar samma tal 2 ggr i rad. 

    void Start()
    {
        body = GetComponent<Rigidbody>();
        
    }

   
    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal"); // kollar A och D tangenter och gör till -1, 0, 1 värden av input -1 vänster 0 stilla , 1 höger
        vertical = Input.GetAxisRaw("Vertical"); // kollar ws tangenter och ger värde -1, 0, 1 
       
        if (Input.GetKeyDown(KeyCode.Space))
        {
            body.AddForce(Vector3.up * 500);
            jumpSound.Play();
            
        }
    }

    private void FixedUpdate()
    {
        Vector3 forward = cameraTransform.forward;
        Vector3 right = cameraTransform.right; // behöver bara ha right för att jämföra med på horizontalaxeln, 
                                               // om vi går left så är det motsatt right. 

        forward.y = 0; // skippa kamerans rotation på karaktären i dessa riktningar
        right.y = 0;

        Vector3 direction = forward * vertical + right * horizontal; // lagrar dessa siffror i ett array vilket inte var lätt att fatta. Men om det är en Vector3 man skapar så är det en grupp på 3 siffror

        Vector3 movement = transform.position + direction.normalized * Time.fixedDeltaTime * movementSpeed; // använder ovan array

        body.MovePosition(movement);

        if ( direction != Vector3.zero) // rotera inte om ingen kanpp tryckt - ingen förändring på ngn axis i arrayet    
        {
            transform.rotation = Quaternion.LookRotation(direction); // annars gör detta: min forward (objektets forward) vill titta i riktiningen som finns direction arrayet
        }

    }

    public int duplicateSoundChecker(int r, int length ) // r = randomvariabeln i hamburgarscriptet, legnth = längd på hamburgarLjud
        // int kan också användas som funktion att returnera just en int med
    {

        while (r == lastRandomInt)  // kolla lastTandomInt (definerad högst upp).. >
                                    //  > ..om samma som r, slumpa om i så fall. 
        {
            r = Random.Range(0, length); // vi använder length = hamburgarljud-längd för att kunna ändra storlek på array flexibelt
            Debug.Log(r);
        }

        lastRandomInt = r; // sätt till samma som r
        return r; // returnera värdet i r till hamburgar scriptet
    } 

}
