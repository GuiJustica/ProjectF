using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class InteracaoDector : MonoBehaviour
{
    
    private IInteractable interactableRange = null;
    public GameObject interactionIcon;
    // Start is called before the first frame update
    void Start()
    {
        interactionIcon.SetActive(false);
    }
    
    void Update() 
    {
        OnInteract();
    }

    public void OnInteract()
    {
        if (Input.GetKeyDown(KeyCode.E) && interactableRange != null)
        {
            Debug.Log("essse");
            interactableRange.Interact();
        }
    }

    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out IInteractable interactable) && interactable.PodeInteract())
        {
            Debug.Log("ee");
            interactableRange = interactable;
            interactionIcon.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out IInteractable interactable) && interactable == interactableRange)
        {
            interactableRange = null;
            interactionIcon.SetActive(false);
        }
    }
}
