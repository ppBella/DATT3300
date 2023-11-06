using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractiveObject : MonoBehaviour
{
    public float interactionRange = 3f;
    public GameObject player;
    public string interactionText;
    public Camera playerCamera;

    private bool isInRange = false;

    private void Update()
    {
        if (isInRange && Input.GetKeyDown(KeyCode.E) && IsFacingObject())
        {
            Debug.Log(interactionText);
            // Add your interaction logic here
        }
    }

    private bool IsFacingObject()
    {
        Vector3 directionToTarget = transform.position - playerCamera.transform.position;
        float angle = Vector3.Angle(playerCamera.transform.forward, directionToTarget);
        return Mathf.Abs(angle) < 90f;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player)
        {
            isInRange = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == player)
        {
            isInRange = false;
        }
    }

    private void OnGUI()
    {
        if (isInRange && IsFacingObject())
        {
            // Display text on the screen when the player is in range and facing the object
            GUI.Label(new Rect(Screen.width / 2 - 50, Screen.height / 2, 200, 50), "Press 'E' to interact");
        }
    }
}