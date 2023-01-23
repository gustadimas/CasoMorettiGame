using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class WinScript : MonoBehaviour
{
    private int pointsToWin;
    private int currentPoints;
    public GameObject garrafas;

    void Start()
    {
        pointsToWin = garrafas.transform.childCount;
    }
   
    void Update()
    {
        if (currentPoints >= pointsToWin)
        {
            // Win
            transform.GetChild(0).gameObject.SetActive(true);
        }
    }

    public void AddPoints()
    {
        currentPoints++;
    }
}
