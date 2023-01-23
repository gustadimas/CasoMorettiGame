using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomizeChildren : MonoBehaviour
{
    private void Awake()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            int novaPosicao = Random.Range(0, transform.childCount);
            Vector3 temp = transform.GetChild(i).position;
            transform.GetChild(i).position = transform.GetChild(novaPosicao).position;
            transform.GetChild(novaPosicao).position = temp;
        }
    }
}
