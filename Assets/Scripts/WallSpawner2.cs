using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallSpawner2 : MonoBehaviour
{
    GameController gameController;
    [SerializeField] Transform position;
    [SerializeField] GameObject[] wallPrefabs;
    [SerializeField] float spawnRate;
    [SerializeField] float velocidade;
    [SerializeField] float velAcumulada;

    float velMudaDif;

    private void Awake()
    {
        velMudaDif = 6;
        gameController = GameObject.Find("GameController").GetComponent<GameController>();
    }
    void Update()
    {
        
        
        if ((velMudaDif < gameController.velocidadeParede) && (gameController.velocidadeParede < 15f && spawnRate > 0.6f))
        {
            velMudaDif = gameController.velocidadeParede + 2;
            spawnRate -= 0.6f;
        }
        

    }



    IEnumerator  Start()
    {
        while (true)
        {
            yield return new WaitForSeconds(spawnRate);
            GameObject wall = Instantiate(wallPrefabs[Random.Range(0, wallPrefabs.Length)], position);
            if (Random.Range(0, 2) > 0)
            {
                wall.transform.localScale = new Vector3(-wall.transform.localScale.x, wall.transform.localScale.y, wall.transform.localScale.z);
            }
            Destroy(wall, 10);
        }
    }
}
