using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Dependencies.Sqlite;
using UnityEngine;

public class PlayableCharacterIdentityCustomSpeak : PlayableCharacterIdentity
{
    [SerializeField]private string customSpeak;
    public override void Speak()
    {
        Debug.Log(customSpeak);
    }
}
