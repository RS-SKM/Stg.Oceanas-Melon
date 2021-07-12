using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Mine : MonoBehaviour
{
    public float speed;
    private Rigidbody2D rb;
    private Vector2 screenBounds;
    public GameObject explosion;

    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(-speed, 0);
        //set a boundary according to the vectors around the visable screen
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));   
    }

    void Update()
    {
        //if object move pass the visable x, destroy it
        if(transform.position.x < screenBounds.x * -1.1f)
        {
            Destroy(this.gameObject);
        }
    }

    void OnCollisionEnter2D (Collision2D other)
    {
        Debug.Log("Mine Exploded");
        Instantiate(explosion, transform.position, Quaternion.identity);
        FindObjectOfType<AudioManager>().Play("explosion");
        Destroy(other.gameObject);
        Invoke("ChangeScene", 2); //call this function in x seconds
    }

    void ChangeScene()
    {
        Debug.Log("Gameover");
        SceneManager.LoadScene(3);
    }
}
