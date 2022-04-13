using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireWeapon : MonoBehaviour
{
    Collider2D collider2D;
    // Start is called before the first frame update
    [SerializeField] GameObject bullet;
    void Start()
    {
        collider2D = GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            var newBullet = Instantiate(bullet);
            newBullet.transform.position = transform.position;
            var bulletBody = newBullet.GetComponent<Rigidbody2D>();
            var direction = ((Camera.main.ScreenToWorldPoint(Input.mousePosition) - collider2D.bounds.center));
            Debug.Log((direction * 100).normalized);
            bulletBody.velocity = (direction * 100).normalized;
        }
    }
}
