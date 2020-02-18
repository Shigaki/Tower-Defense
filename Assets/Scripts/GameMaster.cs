using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMaster : MonoBehaviour {

    public Transform enemyPrefab;

    public  float   wavesInterval = 2f;
    public float   countdown = 1f;
    public int     wavesCount = 5;
    
    void Update() {
        if (countdown <= 0f) {
            SpawnWave();
            countdown = wavesInterval;
        }

        if (wavesCount > 0)
        countdown -= Time.deltaTime;
    }

    void SpawnWave() {

        if (wavesCount > 0) {
            SpawnEnemy();
            wavesCount--;
        }

    }

    void SpawnEnemy() {
        Instantiate(enemyPrefab, this.transform.position, this.transform.rotation);
    }

}
