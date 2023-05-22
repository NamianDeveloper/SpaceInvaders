using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoystickMovement : JoystickController
{
    public Vector3 ReturnVectorDirection()
    {
        if (_inputVector.x != 0 || _inputVector.y != 0)
            return new Vector3(_inputVector.x, _inputVector.y, 0);
        else
            return new Vector3();
    }
}
