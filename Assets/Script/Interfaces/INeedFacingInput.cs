using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface INeedFacingInput
{
    //ini buat mereka yg butuh input movement tp bukan movement
    void FaceInput(Vector2 keyFacingInput);
}
