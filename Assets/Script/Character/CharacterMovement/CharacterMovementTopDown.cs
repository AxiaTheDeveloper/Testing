using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovementTopDown : CharacterMovementBase
{
    //------------------------- Unity Function -------------------------//
    protected override void Awake() 
    {
        base.Awake();
        _charaMoveType = CharaMoveType.TopDown;
    }
    public override void MoveCharacter(Vector2 movementKeyInput)
    {
        rb.MovePosition(rb.position + movementKeyInput * charaSpeed * Time.fixedDeltaTime);
    }
    //------------------------- Priv Function -------------------------//

    //------------------------- Public Function -------------------------//
}
