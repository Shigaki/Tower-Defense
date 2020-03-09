using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMaster : MonoBehaviour {

    public Transform enemyPrefab;

    public float   wavesInterval = 5f;
    public float   countdown = 1f;
    public int     waveIndex = 0;
    
    void Update() {
        if (countdown <= 0f) {
            StartCoroutine(SpawnWave());
            countdown = wavesInterval;
        }

        countdown -= Time.deltaTime;
    }

    IEnumerator SpawnWave() {
        
        if(waveIndex < 5)
            waveIndex++;

        for (int i = 0; i < waveIndex; i++) {
            SpawnEnemy();
            yield return new WaitForSeconds(0.5f);
        }

    }

    void SpawnEnemy() {
        Instantiate(enemyPrefab, this.transform.position, this.transform.rotation);
    }

}
