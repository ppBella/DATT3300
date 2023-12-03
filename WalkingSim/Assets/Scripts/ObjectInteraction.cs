using UnityEngine;

public class ObjectInteraction : MonoBehaviour
{
    private GameObject currentObject;
    private bool isInteracting;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && currentObject != null && isInteracting)
        {
            ReleaseObject();
        }
        else if (Input.GetKeyDown(KeyCode.E) && currentObject == null && isInteracting)
        {
            InteractWithObject();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Interactable"))
        {
            isInteracting = true;
            currentObject = other.gameObject;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Interactable"))
        {
            isInteracting = false;
            currentObject = null;
        }
    }

    private void InteractWithObject()
    {
        currentObject.GetComponent<Rigidbody>().isKinematic = true;
        currentObject.transform.SetParent(this.transform);
    }

    private void ReleaseObject()
    {
        currentObject.GetComponent<Rigidbody>().isKinematic = false;
        currentObject.transform.SetParent(null);
        currentObject = null;
    }
}