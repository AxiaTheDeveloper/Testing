using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IMovementChara
{
    void MoveCharacter(Vector2 movementKeyInput);
    void ForceStopCharacter();
} 
