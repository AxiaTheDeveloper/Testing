using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovementPlatform : CharacterMovementBase
{
    protected override void Awake() 
    {
        base.Awake();
        _charaMoveType = CharaMoveType.LeftRight;
    }
    public override void MoveCharacter(Vector2 movementKeyInput)
    {
        rb.AddForce(movementKeyInput.x * charaSpeed * Vector2.right * Time.fixedDeltaTime);
    }
}
