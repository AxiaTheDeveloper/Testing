using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CharacterIdentity : MonoBehaviour, ISpeakChara
{
    public abstract CharacterType charaType { get;} 
    public virtual void Speak()
    {
        Debug.Log("I speak");
    }
}
