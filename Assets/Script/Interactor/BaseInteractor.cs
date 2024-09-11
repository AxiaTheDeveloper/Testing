using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseInteractor : MonoBehaviour, IInteractor
{
    protected Interactable chosenInteractable;
    public virtual void InteractInteractable(IInteractable thisInteractable)
    {
        thisInteractable.DoInteraction();
    }
    public virtual void Interact()
    {
        chosenInteractable.DoInteraction();
    }
    
}
