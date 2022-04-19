using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArameSpawner : MonoBehaviour
{
    [SerializeField] GameObject aramePrefab;
    Transform t;
    private void Awake()
    {
        t = GetComponent<Transform>();

        Instantiate(aramePrefab, t);
    }
}
