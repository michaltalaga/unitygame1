using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;
using System.Linq;
public class CameraFollow : MonoBehaviour
{
    [SerializeField] Transform target;

    private void FixedUpdate()
    {
        if (target == null)
        {
            target = GameObject.FindGameObjectsWithTag("Player").SingleOrDefault(p => p.GetComponent<PlayerMovement>().IsLocalPlayer)?.transform;
            if (target == null) return;
        }
        var transform = this.transform;
        var desiredPosition = target.position;
        desiredPosition.z = transform.position.z;
        var smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, 0.1f);
        transform.position = smoothedPosition;
    }
}