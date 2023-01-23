using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Ativador : MonoBehaviour
{
    [SerializeField] GameObject[] objetosAfetados;
    [SerializeField] GameObject transitionColidindo;

    [SerializeField] private bool colidindo;
    [SerializeField] private bool colidindoTransition;

    [SerializeField] string varPlayerPrefs;
    [SerializeField] private string[] SceneTransition;

    private bool jaFoi = false;
    private int jaFoiFundos;

    private void Start()
    {
        jaFoiFundos = PlayerPrefs.GetInt("JaFoiFundos", 0);

        if (PlayerPrefs.GetInt(varPlayerPrefs, 1) == 1)
        {
            if (varPlayerPrefs == "portaDelegacia")
            {
                jaFoi = true;
                Afetar();
            }
        }
        else
        {
            if (varPlayerPrefs == "portaFundos")
            {
                jaFoi = true;
                Afetar();
            }

            if (varPlayerPrefs == "portaMercadinho")
            {
                jaFoi = true;
                Afetar();
            }

            if (varPlayerPrefs == "portaVelhinhos")
            {
                jaFoi = true;
                Afetar();
            }
        }
    }

    private void Update()
    {
        if (colidindo && !jaFoi)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                jaFoi = true;
                Afetar();
            }
        }

        if (colidindoTransition)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                if (SceneManager.GetActiveScene().name == "Mercadinho")
                {
                    if (transitionColidindo != null)
                    {
                        if (jaFoiFundos == 0 && transitionColidindo.name == "SceneTransition")
                        {
                            PlayerPrefs.SetInt("conversou_com_atendente", 1);

                            SceneManager.LoadScene(SceneTransition[0]);
                        }

                        if (transitionColidindo.name == "PortaCidade")
                        {
                            SceneManager.LoadScene(SceneTransition[1]);
                        }

                        if (transitionColidindo.name == "PortaCidade1")
                        {
                            SceneManager.LoadScene(SceneTransition[1]);
                        }
                    }
                }
                else if (SceneManager.GetActiveScene().name == "PredioApartamentos")
                {
                    if (transitionColidindo != null)
                    {
                        if (transitionColidindo.name == "CasaDonaMaria")
                        {
                            SceneManager.LoadScene(SceneTransition[0]);
                        }

                        if (transitionColidindo.name == "EntradaSofia")
                        {
                            SceneManager.LoadScene(SceneTransition[1]);
                        }

                        if (transitionColidindo.name == "EntradaCidade")
                        {
                            SceneManager.LoadScene(SceneTransition[2]);
                        }
                    }
                }

                else if (SceneManager.GetActiveScene().name == "Cidade")
                {
                    if (transitionColidindo != null)
                    {
                        if (transitionColidindo.name == "EntrarDelegacia")
                        {
                            SceneManager.LoadScene(SceneTransition[0]);
                        }

                        if (transitionColidindo.name == "EntradaMercadinho")
                        {
                            SceneManager.LoadScene(SceneTransition[1]);
                        }

                        if (transitionColidindo.name ==  "EntradaPredio")
                        {
                            SceneManager.LoadScene(SceneTransition[2]);
                        }

                        if (transitionColidindo.name == "EntradaBar")
                        {
                            SceneManager.LoadScene(SceneTransition[3]);
                        }
                    }
                }

                else if (SceneManager.GetActiveScene().name == "Bar")
                {
                    if (transitionColidindo != null)
                    {
                        if (transitionColidindo.name == "PortaCidade")
                        {
                            SceneManager.LoadScene(SceneTransition[0]);
                        }
                    }
                }

                else if (SceneManager.GetActiveScene().name == "Apartamento Sofia 1")
                {
                    if (transitionColidindo != null)
                    {
                        if (transitionColidindo.name == "PortaCasa")
                        {
                            SceneManager.LoadScene(SceneTransition[0]);
                        }
                    }
                }

                else if (SceneManager.GetActiveScene().name == "CasaDonaMaria")
                {
                    if (transitionColidindo != null)
                    {
                        if (transitionColidindo.name == "SceneTransitionPredio")
                        {
                            PlayerPrefs.SetInt("conversou_com_os_velhos", 1);
                            SceneManager.LoadScene(SceneTransition[0]);
                        }
                    }
                }
                else
                {
                    SceneManager.LoadScene(SceneTransition[0]);
                }
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Ativador"))
        {
            colidindo = true;
        }

        if (collision.CompareTag("Transition"))
        {
            colidindoTransition = true;
            transitionColidindo = collision.gameObject;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Ativador"))
        {
            colidindo = false;
        }

        if (collision.CompareTag("Transition"))
        {
            colidindoTransition = false;
            transitionColidindo = null;
        }
    }

    private void Afetar()
    {
        foreach (GameObject _objetosAfetados in objetosAfetados)
        {
            _objetosAfetados.SetActive(!_objetosAfetados.activeSelf);
        }
    }
}
