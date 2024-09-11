using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CharacterMovementBase : CharacterMovement
{
    [SerializeField] protected CharaMoveType _charaMoveType;
    public override CharaMoveType charaMoveType
    {

        
        get{return _charaMoveType;}
    }

    [SerializeField]private float _charaSpeed;
    public override float charaSpeed
    {
        get { return _charaSpeed;}
        set { _charaSpeed = value;}
    }
    //------------------------- Unity Function -------------------------//
    protected virtual void Awake() 
    {
        if(rb == null)rb = GetComponent<Rigidbody2D>();
    }
    //------------------------- Priv Function -------------------------//

    //------------------------- Public Function -------------------------//

}
