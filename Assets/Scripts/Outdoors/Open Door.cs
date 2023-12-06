using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoor : MonoBehaviour
{
    public bool autoClose = false; // tror inte att denna anv�nds

    private bool canOpen = false;
    private Transform parent;
    private Quaternion startRotation;
    private Quaternion openRotation;


    
    public void OnInteraction(RaycastHit hitInfo)
    {
        CancelInvoke(nameof(OpenTime)); // Om d�rren �r p�v�g att st�ngas, avbryt den.

        // Jag kollar i vilken riktning fr�n d�rren min Raycast tr�ffar, och avg�r sedan vilket h�ll den ska �ppnas �t.
        Vector3 direction = (transform.position - hitInfo.point) / Vector3.Distance(transform.position, hitInfo.point);
        float angle = Vector3.Angle(direction, transform.right);

        if (angle < 90)
        {
            openRotation = startRotation;
            openRotation.eulerAngles += new Vector3(0, -90, 0);
        }
        else
        {
            openRotation = startRotation;
            openRotation.eulerAngles += new Vector3(0, 90, 0);
        }

        canOpen = !canOpen;

        // Om vi vill att d�rren ska st�ngas automatiskt s� kallar vi p� den metoden efter 2,5 sekunder.
        if (autoClose)
            Invoke(nameof(OpenTime), 2.5f);
    }

    
    private void Start()
    {
        parent = transform.parent.GetComponent<Transform>();

        startRotation = parent.transform.rotation;
    }

    private void Update()
    {
        if (canOpen)
        {
            Open();
        }
        else
        {
            Close();
        }
    }

    private void OpenTime()
    {
        canOpen = false;
    }

    public void Open()
    {
        parent.transform.rotation = Quaternion.Lerp(parent.transform.rotation, openRotation, 10 * Time.deltaTime);
    }

    public void Close()
    {
        parent.transform.rotation = Quaternion.Lerp(parent.transform.rotation, startRotation, 10 * Time.deltaTime);
    }

}