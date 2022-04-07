using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BgSpawner : MonoBehaviour
{
    GameController gameController;
    [SerializeField] Transform position;
    [SerializeField] GameObject bgPrefab;
    [SerializeField] float spawnRate;
    [SerializeField] float velocidade;
    [SerializeField] float velAcumulada;

    private void Awake()
    {
        gameController = GameObject.Find("GameController").GetComponent<GameController>();
    }
    void Update()
    {


    }



    IEnumerator Start()
    {
        while (true)
        {
            yield return new WaitForSeconds(spawnRate * Random.Range(2,4));
            GameObject bg = Instantiate(bgPrefab, position);
            velocidade = (gameController.velocidadeParede - 4) * Random.Range(0.2f, 0.5f);
            spawnRate = Random.Range(2, 5);
            bg.transform.localScale = new Vector3(Random.Range(1, 4), Random.Range(1, 2), bg.transform.localScale.z);
            bg.transform.position = new Vector3(bg.transform.position.x, Random.Range(2, 4f), bg.transform.position.z);
            Destroy(bg, 20);
        }
    }
}
