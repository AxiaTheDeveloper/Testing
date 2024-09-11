using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxInteractable : Interactable
{
    public override void DoInteraction()
    {
        base.DoInteraction();
        Debug.Log("hi");
    }
}
