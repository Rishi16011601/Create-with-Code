using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject prefabSphere;
    private float spawnRate = 1.5f;
    private bool isGameActive=true;
    public GameObject titleScreen;
    public int chances = 3;
    //public BoxCollider itemChecker;
    // Start is called before the first frame update
    void Start()
    {
        //isGameActive = true;
        //Instantiate(prefabSphere,RandomPos(),prefabSphere.transform.rotation);
        //transform.position = RandomPos();
        //StartCoroutine(SpawnObj());
    }
    IEnumerator SpawnObj()
    {
        while (isGameActive)
        {
            yield return new WaitForSeconds(spawnRate);

            //Instantiate(prefabSphere, RandomPos(), prefabSphere.transform.rotation);
            GameObject clone = (GameObject)Instantiate(prefabSphere, RandomPos(), prefabSphere.transform.rotation);
            Destroy(clone, 2.4f);
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    Vector3 RandomPos()
    {
        return new Vector3(0,30, Random.Range(-20, 20));
    }
    public void StartGame(int difficulty)
    {
        spawnRate /= difficulty;
        isGameActive = true;
        StartCoroutine(SpawnObj());
        titleScreen.gameObject.SetActive(false);
    }

    /*private void OnCollisionEnter(Collision collision)
    {
        if (gameObject.CompareTag("Item"))
        {
            chances -= 1;
            Destroy(collision.gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (gameObject.CompareTag("Item"))
        {
            chances -= 1;
            Destroy(other.gameObject);
        }
    }*/

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
