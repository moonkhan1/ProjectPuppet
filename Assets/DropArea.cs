using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropArea : MonoBehaviour
{
    public Transform _dropTransform;
    

    public void TransformMoveOnY()
    {
        _dropTransform.localPosition += Vector3.up * 0.01f;
    }
}
