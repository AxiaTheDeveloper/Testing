using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class GameInput : MonoBehaviour
{
    public static GameInput Instance { get; private set;}
    private GameInputActions gameInputAction;
    //=============== Events
    public Action OnChangeCharacterPerformed, OnCharacterSpeakPerformed, OnCharacterInteractPerformed;

    //------------------------- Unity Function -------------------------//
    private void Awake() 
    {
        Instance = this;

        gameInputAction = new GameInputActions();
        gameInputAction.Player.Enable();

        gameInputAction.Player.ChangeCharacter.performed += ChangeCharacter_performed;
        gameInputAction.Player.CharacterSpeak.performed += CharacterSpeak_performed;
        gameInputAction.Player.CharacterInteract.performed += CharacterInteract_performed;
    }




    #region Player

    //------------------------- Priv Function -------------------------//
    private void CharacterSpeak_performed(InputAction.CallbackContext context)
    {
        OnCharacterSpeakPerformed?.Invoke();
    }
    private void ChangeCharacter_performed(InputAction.CallbackContext context)
    {
        OnChangeCharacterPerformed?.Invoke();
    }
    private void CharacterInteract_performed(InputAction.CallbackContext context)
    {
        OnCharacterInteractPerformed?.Invoke();
    }

    //------------------------- Public Function -------------------------//
    public Vector2 GetInputMovement()
    {
        Vector2 movementInput = gameInputAction.Player.Move.ReadValue<Vector2>();
        movementInput = movementInput.normalized;

        return movementInput;
    }
    
    #endregion

    #region UI
    #endregion
}
