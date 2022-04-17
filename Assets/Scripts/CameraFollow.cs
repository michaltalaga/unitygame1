using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] Vector3 offset;

    private void FixedUpdate()
    {
        var desiredPosition = target.position + offset;
        var smootherdPosition = Vector3.Lerp(transform.position, desiredPosition, 0.1f);
        transform.position = smootherdPosition;
    }
}
