using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CharacterMovement : MonoBehaviour, IMovementChara
{
    public abstract CharaMoveType charaMoveType {get;}
    protected Rigidbody2D rb;
    public abstract float charaSpeed {get; set;}
    
    public virtual void MoveCharacter(Vector2 movementKeyInput){}
    public virtual void ForceStopCharacter()
    {
        rb.velocity = Vector2.zero;
    }
}
