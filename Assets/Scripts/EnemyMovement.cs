using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{

    
    GameController gameController;
    float velocidade;
    // Start is called before the first frame update
    private void Awake()
    {
        gameController = GameObject.Find("GameController").GetComponent<GameController>();
    }
    void Start()
    {
        
        
    }

    // Update is called once per frame
    void Update()
    {
        velocidade = gameController.velocidadeParede;
        transform.Translate(Vector3.left * velocidade * Time.deltaTime);

    }
}
