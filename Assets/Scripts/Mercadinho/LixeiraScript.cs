using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LixeiraScript : MonoBehaviour
{
    Collider2D colider = null;
    private bool jaFez = false;
    public static bool isActive = false;

    [SerializeField] private GameObject LixeiraWin;

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

            if (colider == null)
            {
                LixeiraWin.SetActive(false);
            }
        }
    }

    private void Update()
    {
        if (LixosScript.completou == false)
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
                        SceneManager.LoadScene(11);
                    }
                    else
                    {
                        SceneManager.LoadScene(12, LoadSceneMode.Additive);

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
}
