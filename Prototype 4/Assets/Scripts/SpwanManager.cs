using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpwanManager : MonoBehaviour
{
    public GameObject enemyPrefab;
    private float spwanRange = 9;
    public int enimiesNumber;
    public int waveNum = 1;
    public GameObject powerPrefab;
    // Start is called before the first frame update
    void Start()
    {
        Instantiate(powerPrefab, GenerateSpwanPos(), powerPrefab.transform.rotation);
        SpwanEnemyWave(waveNum);
        
    }

    // Update is called once per frame
    void Update()
    {
        enimiesNumber = FindObjectsOfType<Enemy>().Length;
        if(enimiesNumber == 0)
        {
            waveNum++;
            Instantiate(powerPrefab, GenerateSpwanPos(), powerPrefab.transform.rotation);
            SpwanEnemyWave(waveNum);
            
        }
    }
    private Vector3 GenerateSpwanPos()
    {
        float spwanPosX = Random.Range(-spwanRange, spwanRange);
        float spwanPosZ = Random.Range(-spwanRange, spwanRange);
        Vector3 randomPos = new Vector3(spwanPosX, 0, spwanPosZ);
        return randomPos;
    }
    void SpwanEnemyWave(int enemiesToSpwan)
    {
        for(int i = 0; i < enemiesToSpwan; i++)
        {
            Instantiate(enemyPrefab, GenerateSpwanPos(), enemyPrefab.transform.rotation);
        }
    }
}
