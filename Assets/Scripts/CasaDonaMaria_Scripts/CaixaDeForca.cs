using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CaixaDeForca : MonoBehaviour
{
    Collider2D colider = null;
    bool jaFoi = false;
    public static bool isActive = false;

    [SerializeField] private GameObject fiosWin;

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
            jaFoi = false;

            if (TaskMechanic.completou == true)
            {
                fiosWin.SetActive(false);
            }
        }
    }

    private void Update()
    {
        if (TaskMechanic.completou == false)
        {
            if (Input.GetKey(KeyCode.E))
            {
                if (colider != null && !jaFoi)
                {
                    jaFoi = true;

                    isActive = true;

                    if (SceneManager.GetActiveScene().buildIndex == 0)
                    {
                        SceneManager.LoadScene(5);
                    }
                    else
                    {
                        GameObject[] col = GameObject.FindGameObjectsWithTag("Parede");

                        foreach (GameObject go in col)
                        {
                            go.GetComponent<BoxCollider2D>().enabled = false;
                
                        }

                        SceneManager.LoadScene(6, LoadSceneMode.Additive);
                    }
                }    
            }
        }
    }
}
