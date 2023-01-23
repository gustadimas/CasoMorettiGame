using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class InterrogatoryScript : MonoBehaviour
{
    private bool colidindo;

    [SerializeField] private GameObject panelQuestion;

    public static bool isActive = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Personagem"))
        {
            colidindo = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Personagem"))
        {
            colidindo = false;
        }
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.E))
        {
            Debug.Log("Entrou(la ele)");

            if (colidindo)
            {
                panelQuestion.SetActive(true);

                isActive = true;
            }
        }
    }
}
