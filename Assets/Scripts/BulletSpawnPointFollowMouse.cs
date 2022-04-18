using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawnPointFollowMouse : MonoBehaviour
{
    Camera camera;
    [SerializeField] Collider2D playerCollider;
    // Start is called before the first frame update
    void Start()
    {
        camera = Camera.main;
    }

    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            var mousePosition = camera.ScreenToWorldPoint(Input.mousePosition);
            mousePosition.z = transform.position.z;
            var direction = mousePosition - playerCollider.bounds.center;
            transform.position = playerCollider.bounds.center + Vector3.ClampMagnitude(direction * 10, 0.2f);
        }
    }
}
