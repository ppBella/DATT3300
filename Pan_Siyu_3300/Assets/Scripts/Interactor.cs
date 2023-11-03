using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

interface IInteractable 
{
    void Interact();
}

public class Interactor : MonoBehaviour
{
    public Transform InteractSource;
    public float InteractRange;

    public TextMeshProUGUI interactionText; // Define the UI text variable

    // Start is called before the first frame update
    void Start()
    {
        HideInteractionText(); // Hide the text initially
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Ray r = new Ray(InteractSource.position, InteractSource.forward);
            if (Physics.Raycast(r, out RaycastHit hitInfo, InteractRange))
            {
                if (hitInfo.collider.gameObject.TryGetComponent(out IInteractable interactObj))
                {
                    interactObj.Interact();
                }
            }
        }
    }

    // Call this function to display the interaction text
    public void ShowInteractionText(string text)
    {
        interactionText.text = text;
        interactionText.gameObject.SetActive(true);
    }

    // Call this function to hide the interaction text
    void HideInteractionText()
    {
        interactionText.gameObject.SetActive(false);
    }
}