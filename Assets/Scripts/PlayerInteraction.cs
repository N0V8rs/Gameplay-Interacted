using UnityEngine;

public class PlyerInteractions : MonoBehaviour
{
    public GameObject currentInterObj = null;
    public InteractionObject currentInterObjScript = null;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && currentInterObj == true)
        {
            if (currentInterObjScript.info == true)
            {
                currentInterObjScript.Info();
            }
            
            if (currentInterObjScript.pickup == true)
            {
                currentInterObjScript.Pickup();
            }
        }
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Interactable") == true)
        {
            currentInterObj = other.gameObject;
            currentInterObjScript = currentInterObj.GetComponent<InteractionObject>();
            Debug.Log(other.name);
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Interactable") == true)
        {
            currentInterObj = null;
            Debug.Log("Player exited");
        }
    }
}
