using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InteractableText : MonoBehaviour
{
    public TextMeshProUGUI interactText;
    public float interactionDistance = 3f;
    private GameObject currentObject;

    void Start()
    {
        interactText.text = "";
        interactText.enabled = false;
    }

    void Update()
    {
        if (currentObject != null)
        {
            //currentObject = null;
            interactText.text = "Press E";
            interactText.enabled = true;
        }

        if (currentObject == null)
        {
            interactText.text = "";
            interactText.enabled = false;
        }

        if (currentObject != null)
        {
            interactText.text = "Press E to interact";
            interactText.enabled = true;

            if (Input.GetKeyDown(KeyCode.E))
            {
                // Add your interaction logic here
                // For example: currentObject.GetComponent<YourInteractableScript>().Interact();
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Interactable"))
        {
            currentObject = other.gameObject;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == currentObject)
        {
            currentObject = null;
        }
    }
}