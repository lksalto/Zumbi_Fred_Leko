using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arame : MonoBehaviour
{
    PlayerMovement player;
    
    private void Awake()
    {
        player = GameObject.Find("Player").GetComponent<PlayerMovement>();
        gameObject.active = Random.Range(0, 10) > 3;
    }

    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision.tag);
    
        if (collision.CompareTag("Player"))
        {
            Debug.Log("TEJE PRESO");
            player.trapped = true;
        }

    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            player.trapped = false;
        }
    }
}
