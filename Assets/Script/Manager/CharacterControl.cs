using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class CharacterControl : MonoBehaviour
{
    //------------------------- Manager -------------------------//
    GameInput gameInput;
    private Vector2 movementKeyInput, facingKeyInput; //storing received input
    private PlayableCharacterIdentity chosenChara; //storing the chosenchara from the charalist

    [Tooltip("All character that player can control in the game")]
    [SerializeField]private List<PlayableCharacterIdentity> charaList;
    [Tooltip("if this true, players cant move anything and all character stop")]
    private bool isChangingCharacter;

    //------------------------- Unity Function -------------------------//

    private void Start()
    {
        gameInput = GameInput.Instance;
        gameInput.OnChangeCharacterPerformed += Input_OnChangeCharacterPerformed;
        gameInput.OnCharacterSpeakPerformed += Input_OnCharacterSpeakPerformed;
        gameInput.OnCharacterInteractPerformed += Input_OnCharacterInteractPerformed;

        ChangeChosenChara(0);

    }


    // Update is called once per frame
    private void Update() 
    {
        movementKeyInput = gameInput.GetInputMovement();
        GetFaceInput();
    }
    private void FixedUpdate() {
        MoveCharacter();
    }
    private void OnDestroy() 
    {
        gameInput.OnChangeCharacterPerformed -= Input_OnChangeCharacterPerformed;
        gameInput.OnCharacterSpeakPerformed -= Input_OnCharacterSpeakPerformed;
        gameInput.OnCharacterInteractPerformed -= Input_OnCharacterInteractPerformed;
    }

    //------------------------- Priv Function -------------------------//
    /// <summary>
    /// Send Input and told the character to based on the movement input
    /// </summary>
    private void MoveCharacter()
    {
        if(chosenChara && !isChangingCharacter)
        {
            chosenChara.Movement?.MoveCharacter(movementKeyInput);
        }
    }
    private void GetFaceInput()
    {
        if(chosenChara && !isChangingCharacter)
        {
            chosenChara.FaceInput?.FaceInput(movementKeyInput);
        }
    }

    
    
    #region Event
    /// <summary>
    /// Below this part is event connected with the action input
    /// </summary>
    private void Input_OnChangeCharacterPerformed()
    {
        ChangeCharacter();
    }
    private void Input_OnCharacterSpeakPerformed()
    {
        CharacterSpeak();
    }
    private void Input_OnCharacterInteractPerformed()
    {
        CharacterInteract();
    }
    #endregion

    /// <summary>
    /// For changing characters that you control
    /// </summary>
    private void ChangeCharacter()
    {
        isChangingCharacter = true;
        chosenChara.Movement?.ForceStopCharacter();
        int charaIdxNow = charaList.IndexOf(chosenChara);
        if(charaIdxNow + 1 < charaList.Count)
        {
            ChangeChosenChara(charaIdxNow + 1);
        }
        else
        {
            ChangeChosenChara(0);
        }

    }
    /// <summary>
    /// Change the chara
    /// </summary>
    private void ChangeChosenChara(int idx)
    {
        chosenChara = charaList[idx];
        isChangingCharacter = false;
    }

    /// <summary>
    /// Made the chara speak because everyone can
    /// </summary>
    private void CharacterSpeak()
    {
        if(chosenChara && !isChangingCharacter)chosenChara.SpeakChara?.Speak();
    }

    /// <summary>
    /// Made the chara interact with interactables
    /// </summary>
    private void CharacterInteract()
    {
        if(chosenChara && !isChangingCharacter)chosenChara.Interactor?.Interact();
    }

    //------------------------- Public Function -------------------------//
    
}
