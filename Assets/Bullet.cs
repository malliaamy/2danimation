using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float velX = 5f;
    float velY = 0f;
    Rigidbody2D rb1;
    // Start is called before the first frame update
    void Start()
    {
        rb1 = GetComponent<Rigidbody2D> ();
    }

    // Update is called once per frame
    void Update()
    {
        rb1.velocity = new Vector2 (velX, velY);
        Destroy (gameObject, 5f);
    }

}
