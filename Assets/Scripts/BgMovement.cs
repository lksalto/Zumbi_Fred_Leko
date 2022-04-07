using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BgMovement : MonoBehaviour
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
        velocidade = (gameController.velocidadeParede) * Random.Range(0.3f, 0.6f);
    }

    // Update is called once per frame
    void Update()
    {

        transform.Translate(Vector3.left * velocidade * Time.deltaTime);

    }

}
