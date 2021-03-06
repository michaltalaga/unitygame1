using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;
using UnityEngine.UI;

public class FireWeapon : NetworkBehaviour
{
    new Collider2D collider2D;
    [SerializeField] GameObject bullet;
    [SerializeField] Transform bulletSpawnPoint;
    
    float lastBulletTime = 0;
    void Start()
    {
        collider2D = GetComponent<Collider2D>();
    }

    void Update()
    {
        if (!IsLocalPlayer) return;
        if (Input.GetMouseButton(0) && (Time.time - lastBulletTime) > 0.1)
        {
            lastBulletTime = Time.time;
            var newBullet = Instantiate(bullet);
            newBullet.transform.position = bulletSpawnPoint.position;
            var bulletBody = newBullet.GetComponent<Rigidbody2D>();
            var direction = Camera.main.ScreenToWorldPoint(Input.mousePosition) - bulletSpawnPoint.position;
            direction = direction * 100000;
            direction = Vector2.ClampMagnitude(direction, 10);
            bulletBody.velocity = direction;

        }
    }
}