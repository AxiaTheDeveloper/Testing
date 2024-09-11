using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Interactable : MonoBehaviour, IInteractable
{
    public virtual void DoInteraction()
    {
        Debug.Log(nameof(gameObject));
    }
}
