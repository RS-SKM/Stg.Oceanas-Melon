using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rock : MonoBehaviour
{
    public float speed = 200.0f;
    private Rigidbody2D rb;
    private Vector2 screenBounds;

    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(-speed, 0);
        //set a boundary according to the vectors around the visable screen *ONLY WORKS WITH PERSECTIVE CAMERA
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
    }

    void Update()
    {
        //if object move pass the visable x, destroy it
        if(transform.position.x < screenBounds.x * 2)
        {
            Destroy(this.gameObject);
        }
    }
}
