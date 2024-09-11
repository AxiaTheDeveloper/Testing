using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayableInteractor : BaseInteractor, INeedFacingInput
{
    public static event EventHandler<OnSelectInteractableEventArgs> OnSelectInteractable;
    public class OnSelectInteractableEventArgs : EventArgs
    {
        public Interactable chosenInteractable;
    }

    private RaycastHit2D hitInteractable;
    [SerializeField]private float interactionDistance;
    [SerializeField]private LayerMask layerInteractable;
    Vector2 faceDir;
    
    private bool wasDiagonal;
    private Vector2 lastFaceDir;
    private float diagonalCountdownChecker;
    [SerializeField]private float diagonalCountdownCheckerMax;


    //------------------------- Unity Function -------------------------//
    private void Update() {
        Debug.DrawRay(transform.position, faceDir, Color.blue);
    }

    //------------------------- Priv Function -------------------------//
    private void HandleSelectInteractable(Vector2 faceDirection)
    {
        faceDir = faceDirection;
        hitInteractable = Physics2D.Raycast(transform.position, faceDirection, interactionDistance, layerInteractable);
        
        if(hitInteractable)
        {
            Interactable selectedInteractable = hitInteractable.collider.GetComponent<Interactable>();
            if(selectedInteractable != chosenInteractable)
            {
                SetSelectedInteractable(selectedInteractable);
            }
        }
        else
        {
            SetSelectedInteractable(null);
        }
    }
    private void SetSelectedInteractable(Interactable selectedInteractable)
    {
        chosenInteractable = selectedInteractable;

        OnSelectInteractable?.Invoke(this, new OnSelectInteractableEventArgs
        {
            chosenInteractable = chosenInteractable
        });
    }

    //------------------------- Public Function -------------------------//
    public override void Interact()
    {
        if(chosenInteractable == null)return;
        base.Interact();
    }
    public void FaceInput(Vector2 keyFacingInput)
    {
        //GetFaceInputFromOutside
        // if(keyFacingInput == Vector2.zero) return;
        if(keyFacingInput.x != 0 && keyFacingInput.y != 0)
        {
            wasDiagonal = true;
            lastFaceDir = keyFacingInput;
            diagonalCountdownChecker = diagonalCountdownCheckerMax;
        }
        else if((keyFacingInput.x != 0 && keyFacingInput.y == 0) || (keyFacingInput.x == 0 && keyFacingInput.y != 0))
        {
            if(wasDiagonal)
            {
                if(keyFacingInput.x == Mathf.Sign(lastFaceDir.x) || keyFacingInput.y == Mathf.Sign(lastFaceDir.y))
                {
                    if(diagonalCountdownChecker > 0)
                    {
                        diagonalCountdownChecker -= Time.deltaTime;
                        keyFacingInput = lastFaceDir;
                    }
                    else
                    {
                        wasDiagonal = false;
                    }
                }
            }
            else
            {
                wasDiagonal = false;
            }
        }
        
        if(keyFacingInput == Vector2.zero)
        {
            if(wasDiagonal)
            {
                wasDiagonal = false;
                keyFacingInput = lastFaceDir;
            }
            else
            {
                return;
            }
        }
        HandleSelectInteractable(keyFacingInput);
    }
}
