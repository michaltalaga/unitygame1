using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FireWeapon : MonoBehaviour
{
    new Collider2D collider2D;
    [SerializeField] GameObject bullet;
    
    float lastBulletTime = 0;
    void Start()
    {
        collider2D = GetComponent<Collider2D>();
    }

    void Update()
    {
        
        if (Input.GetMouseButton(0) && (Time.time - lastBulletTime) > 0.1)
        {
            lastBulletTime = Time.time;
            var newBullet = Instantiate(bullet);
            newBullet.transform.position = collider2D.bounds.center;
            var bulletBody = newBullet.GetComponent<Rigidbody2D>();
            var direction = Camera.main.ScreenToWorldPoint(Input.mousePosition) - collider2D.bounds.center;
            direction = direction * 100000;
            direction = Vector2.ClampMagnitude(direction, 10);
            bulletBody.velocity = direction;

        }
    }
}