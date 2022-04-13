using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FireWeapon : MonoBehaviour
{
    new Collider2D collider2D;
    // Start is called before the first frame update
    [SerializeField] GameObject bullet;
    [SerializeField] LayerMask projectilesLayer;
    float lastBulletTime = 0;
    void Start()
    {
        collider2D = GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetMouseButton(0) && (Time.time - lastBulletTime) > 0.1)
        {
            lastBulletTime = Time.time;
            var newBullet = Instantiate(bullet);
            newBullet.transform.position = collider2D.bounds.center;
            newBullet.layer = (int)Mathf.Log(projectilesLayer.value, 2);
            var bulletBody = newBullet.GetComponent<Rigidbody2D>();
            var direction = Camera.main.ScreenToWorldPoint(Input.mousePosition) - collider2D.bounds.center;
            direction = direction * 100000;
            direction = Vector2.ClampMagnitude(direction, 10);
            bulletBody.velocity = direction;

        }
    }
}