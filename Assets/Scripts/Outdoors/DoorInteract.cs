using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DoorInteract : MonoBehaviour
{

    public bool doorCanOpen = false;

    public TMP_Text messageBoard;

    TakeHoneyBox takeHoneyBox;

    private void Start()
    {
        takeHoneyBox = GameObject.FindObjectOfType<TakeHoneyBox>();

    }


    // Update is called once per frame
    void Update()
    {

        // gör en bool huruvida dörren går att öppna 

        if (Input.GetKeyDown(KeyCode.Q) && doorCanOpen)
        {
            RaycastHit hitInfo = new RaycastHit();
            bool hit = Physics.Raycast(transform.position, transform.forward, out hitInfo, 2f);
            //bool hit = Physics.SphereCast(transform.position, 1f, transform.forward, out hitInfo, 1f, layerMask);

            if (hit)
            {
                OpenDoor openDoor;

                hitInfo.transform.TryGetComponent<OpenDoor>(out openDoor);

                if (openDoor != null)
                {
                    
                    openDoor.OnInteraction(hitInfo);

                    messageBoard.text = "Get HoneyBox and bring inside shed";

                    

                    takeHoneyBox.canGetHoneyBox = true;

                    
                }
                else
                {
                    Debug.Log("Doesnt have an an Open Door Component");
                }
            }
        }
    }

}