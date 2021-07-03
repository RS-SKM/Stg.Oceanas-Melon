using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnRock : MonoBehaviour
{
    public GameObject rockPrefab;
    public float respawnTime = 1.0f;
    private Vector2 screenBounds;
    private bool gameStart = true;
 
    void Start()
    {
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        StartCoroutine(rockWave());
    }

    void Update()
    {

    }

    private void spawnRocks()
    {
        GameObject rock = Instantiate(rockPrefab) as GameObject;
        rock.transform.position = new Vector2(screenBounds.x * -2, Random.Range(-screenBounds.y, screenBounds.y));
    }

    IEnumerator rockWave()
    {
        while(gameStart == true)
        {
            yield return new WaitForSeconds(respawnTime);
            spawnRocks();
        }

    }
}
