using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BanheiroScript : MonoBehaviour
{
    Collider2D colider = null;
    private bool jaFez = false;
    public static bool isActive = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Personagem"))
        {
            colider = collision;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Personagem"))
        {
            colider = null;
            jaFez = false;
        }
    }

    private void Update()
    {
        if (MouseBarForce.completou == false)
        {
            if (Input.GetKey(KeyCode.E))
            {
                Debug.Log("Entrou(la ele)");

                if (colider != null && !jaFez)
                {
                    jaFez = true;

                    isActive = true;

                    if (SceneManager.GetActiveScene().buildIndex == 0)
                    {
                        SceneManager.LoadScene(2);
                    }
                    else
                    {
                        SceneManager.LoadScene(3, LoadSceneMode.Additive);

                        GameObject[] col = GameObject.FindGameObjectsWithTag("Objetos");

                        foreach (GameObject go in col)
                        {
                            go.GetComponent<BoxCollider2D>().enabled = false;
                        }
                    }
                }
            }
        }
    }

    public void GoToMenu()
    {
        SceneManager.LoadScene("MenuScene");
    }
}
