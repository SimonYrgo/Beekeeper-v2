using TMPro;
using UnityEngine;

public class DeactivateChildrenWithTag : MonoBehaviour
{
    public string targetTagA = "Capped"; // Set your target tag in the Unity Editor

    public string targetTagB = "UnCapped"; // Set your target tag in the Unity Editor

    public TMP_Text messageBoard;

    bool canUncapFrame = false;


    TakeFrameHoneybox takeFrameHoneybox;





    void Start()
    {
        
        takeFrameHoneybox = GameObject.FindObjectOfType<TakeFrameHoneybox>();

    }




    private void Update()
    {

        if (canUncapFrame)
        {
            if (Input.GetKeyUp(KeyCode.U))
            {
                DeactivateChildrenByTag();

                ActivateChildrenByTag();

            }

            canUncapFrame = false;
        }



       
    }

    private void OnTriggerEnter(Collider player)
    {

        
        
        if (player.tag == "Player")// && takeFrameHoneybox.framePutOnStand) 
        
        {
            canUncapFrame = true;
            messageBoard.text = "Press U to uncap Honeyframe";

        }
    }

    private void OnTriggerExit(Collider player)
    {

        

        if (player.tag == "Player")//  && takeFrameHoneybox.framePutOnStand)

        {
            canUncapFrame = false;
            messageBoard.text = "";

        }
    }






    void DeactivateChildrenByTag()
    {
        // Iterate through all child objects of the current GameObject
        for (int i = 0; i < transform.childCount; i++)
        {
            // Get the i-th child object
            Transform child = transform.GetChild(i);

            // Check if the child's tag matches the target tag
            if (child.CompareTag(targetTagA))
            {
                // Deactivate the child object
                child.gameObject.SetActive(false);
            }
        }
    }

    void ActivateChildrenByTag()
    {
        // Iterate through all child objects of the current GameObject
        for (int i = 0; i < transform.childCount; i++)
        {
            // Get the i-th child object
            Transform child = transform.GetChild(i);

            // Check if the child's tag matches the target tag
            if (child.CompareTag(targetTagB))
            {
                // Activate the child object
                child.gameObject.SetActive(true);
            }
        }
    }
}

