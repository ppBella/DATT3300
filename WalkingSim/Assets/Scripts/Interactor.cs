using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
//using TMPro;


public class Interactor : MonoBehaviour
{
    [SerializeField] public Transform _interactablePoint;
    [SerializeField] private float _interactablePointRadius = 0.5f;
    [SerializeField] private LayerMask _interactableMask;

    private readonly Collider[] _colliders = new Collider[3];
    [SerializeField] private int _numFound;

    private void update(){

        _numFound = Physics.OverlapSphereNonAlloc(_interactablePoint.position, _interactablePointRadius, _colliders,
        _interactableMask);

        if(_numFound > 0)
        {
            var interactable = _colliders[0].GetComponent<IInteractable>();

            if(interactable != null && Keyboard.current.eKey.wasPressedThisFrame)
            {
                interactable.Interact(this);
            }
        }
    }


    private void OnDrawGizmos()
    {
        Gizmos.color = Color. red;
        Gizmos.DrawWireSphere(_interactablePoint.position, _interactablePointRadius);
    }
}