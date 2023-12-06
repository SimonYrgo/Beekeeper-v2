using TMPro;
using UnityEngine;

public class WaxShaverTakeUncappedFrame : MonoBehaviour
{
    public string targetTagA = "Capped"; // Set your target tag in the Unity Editor
    public string targetTagB = "UnCapped"; // Set your target tag in the Unity Editor


    public TMP_Text messageBoard;

    bool canUncapFrame = false;
    public bool frameUncapped = false;
    public bool insideCollider = false;
    public bool unCappedFrameTaken = false;

    TakeFrameHoneybox takeFrameHoneybox;
   
    public Transform grabbingPointTransform; // ser om jag kan lägga ett gameobjekt här i, som jag kan sno en Transform från sen
    public Transform frame;
    private Rigidbody frameRb; // måste skapa en Rigidbody-variabel för att kunna hänvisa till frames Rigidbody
    private Collider frameCollider;

    

    void Start()
    {

        takeFrameHoneybox = GameObject.FindObjectOfType<TakeFrameHoneybox>();

        
    }
        


    private void OnTriggerEnter(Collider player)
    {

        if (player.tag == "Player")
        {
            insideCollider = true;
        }

    }



    private void OnTriggerExit(Collider player)
    {
        if (player.tag == "Player")
        {
            insideCollider = false;
        }

    }






    private void Update()
    {
        if (insideCollider)
        {

            if (takeFrameHoneybox.framePutOnStand && !frameUncapped)

            {
                canUncapFrame = true;
                messageBoard.text = "Press U to uncap Honeyframe";



                if (canUncapFrame)
                {
                    if (Input.GetKeyDown(KeyCode.U))
                    {
                        DeactivateChildrenByTag();

                        ActivateChildrenByTag();

                        canUncapFrame = false;

                        frameUncapped = true;


                        

                    }
                }

            }

            if (frameUncapped) // Den funkar inte i loopen ovan för loopen hinner gå runt ett varv och booldörren stängas 
            {
                messageBoard.text = "Press F to pick up uncapped frame";

                if (Input.GetKeyDown(KeyCode.F))
                {
                    // Debug.Log("Snart hemma med framen");

                    PickUpFrame();

                    

                    // kör metod så man plockar upp framen till grabbing point transform som vanligt
                }

            }

                   

        }

        if (!insideCollider)
        {
            if (takeFrameHoneybox.framePutOnStand || frameUncapped)

            {
                canUncapFrame = false;

                


            }
        }


        if (unCappedFrameTaken)
        {

            messageBoard.text = "Put uncapped frame in Extractor";
        }



       

    }

    void DeactivateChildrenByTag()
    {
        // Iterate through all child objects of the current GameObject
        for (int i = 0; i < frame.childCount; i++)
        {
            // Get the i-th child object
            Transform child = frame.GetChild(i);

            // Check if the child's tag matches the target tag - samma sak som if (child.tag == "nånting")  fast man bestämmer nånting i variabeln ovan 
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
        for (int i = 0; i < frame.childCount; i++)
        {
            // Get the i-th child object
            Transform child = frame.GetChild(i);

            // Check if the child's tag matches the target tag
            if (child.CompareTag(targetTagB))
            {
                // Activate the child object
                child.gameObject.SetActive(true);
            }
        }
    }


    void PickUpFrame ()
    {

        frameRb = frame.gameObject.GetComponent<Rigidbody>();
        frameCollider = frame.gameObject.GetComponent<Collider>();

        frame.transform.parent = null; // sätt parent till null på ditt child innan du byter parent- detta för att inte skalan på childet ska förändras till att ta relativ skala mot parent.

        frame.transform.position = grabbingPointTransform.position; 
        frame.transform.rotation = grabbingPointTransform.rotation;
        frame.transform.parent = grabbingPointTransform;
        frameRb.isKinematic = true;
        frameCollider.isTrigger = true;

        unCappedFrameTaken = true;


    }
}
    



