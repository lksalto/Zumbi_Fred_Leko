using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallSpawner : MonoBehaviour
{
    // Start is called before the first frame update
    EnemyMovement gameManager;
    [SerializeField] GameObject gm;
    [SerializeField] float spawnCoolDown = 2.5f;
    [SerializeField] float xMin;
    [SerializeField] float xMax;
    [SerializeField] float yMin;
    [SerializeField] float yMax;
    [SerializeField] Transform posY;
    [SerializeField] Transform pos;
    [SerializeField] GameObject wallPrefab;
    float velMudaDif;
    float velAcumulada = 4;
    float spawnCoolDownCounter;

    private void Awake()
    {
        gameManager = gm.GetComponent<EnemyMovement>();
        velMudaDif = velAcumulada;
    }
    // Update is called once per frame
    void Update()
    {
        velAcumulada += Time.deltaTime/50;
        spawnCoolDownCounter -= Time.deltaTime;
        if ((velAcumulada > velMudaDif + 2) && (velAcumulada < 21f) && (spawnCoolDown > 0.5f))
        {
            velMudaDif = velAcumulada;
            spawnCoolDown -= 0.5f;
            Debug.Log(velMudaDif);
            Debug.Log(spawnCoolDown);

        }
        if (spawnCoolDownCounter < 0)
        {
            
            spawnCoolDownCounter = spawnCoolDown;
            wallPrefab.transform.localScale = new Vector3(Random.Range(xMin, xMax), Random.Range(yMin, yMax), wallPrefab.transform.localScale.z);
            wallPrefab.transform.position = new Vector3(pos.transform.position.x, (posY.transform.position.y), pos.transform.position.z);
            
            Instantiate(wallPrefab, pos);
            
        }
        
    }
}
