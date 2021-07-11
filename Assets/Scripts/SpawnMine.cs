using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnMine : MonoBehaviour
{
    public GameObject minePrefab;
    public float respawnTime = 1.0f;
    private Vector2 screenBounds;
    private bool gameStart = true;
 
    void Start()
    {
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        StartCoroutine(mineWave());
    }

    void Update()
    {

    }

    private void spawnMine()
    {
        GameObject mine = Instantiate(minePrefab) as GameObject;
        mine.transform.position = new Vector2(screenBounds.x * 1.1f, Random.Range(screenBounds.y, -screenBounds.y));
    }

    IEnumerator mineWave()
    {
        while(gameStart == true)
        {
            yield return new WaitForSeconds(respawnTime);
            spawnMine();
        }

    }
}
