using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Luz_Script : MonoBehaviour
{
    public TextMeshProUGUI puzzleTutorial;
    

    private void Start()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D Colisor)
    {
        puzzleTutorial.text = "É preciso ligar a energia para acessar este quarto!";
    }

    private void OnCollisionExit2D(Collision2D Colisor)
    {
        puzzleTutorial.text = " ";
    }
}
