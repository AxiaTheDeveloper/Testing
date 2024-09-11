using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayableCharacterIdentity : CharacterIdentity
{
    [SerializeField]private CharacterType _charaType = CharacterType.PlayableCharacter;
    public override CharacterType charaType {get{return _charaType;}}
    private IMovementChara _movement;
    private ISpeakChara _speak;
    private IInteractor _interactor;
    private INeedFacingInput _faceInput;

    public IMovementChara Movement {get{return _movement;}}
    public ISpeakChara SpeakChara {get{return _speak;}}
    public IInteractor Interactor {get{return _interactor;}}
    public INeedFacingInput FaceInput {get{return _faceInput;}}

    //------------------------- Unity Function -------------------------//
    private void Awake() 
    {
        _movement = GetComponent<IMovementChara>();
        _speak = GetComponent<ISpeakChara>();
        _interactor = GetComponent<IInteractor>();
        _faceInput = GetComponent<INeedFacingInput>();

    }

    //------------------------- Priv Function -------------------------//

    //------------------------- Public Function -------------------------//


}
