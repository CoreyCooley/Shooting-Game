using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {

    // Make a new enemy every once in a while, like every 3 seconds
    // each enemy should come up at a random location
    // and each enemy should shoot upwards and then go back down
    // y should be -5 at the start
    // x is between -13 and 13
    // z should be 4

    public GameObject enemy;
    public Sprite[] enemyImages;

	// Use this for initialization
	void Start () {
        InvokeRepeating("SpawnEnemy", 0.000001f, 3);
	}
	
    void SpawnEnemy()
    {
        GameObject newEnemy = (GameObject)Instantiate(enemy) as GameObject;
        float x = Random.Range(-13.0f, 13.0f);
        float y = -5;
        float z = 4;

        newEnemy.transform.position = new Vector3(x, y, z);
        newEnemy.GetComponent<SpriteRenderer>().sprite = enemyImages[Random.Range(0, enemyImages.Length)];

        newEnemy.GetComponent<Rigidbody2D>().AddForce(Vector3.up * 460);
    }
}
