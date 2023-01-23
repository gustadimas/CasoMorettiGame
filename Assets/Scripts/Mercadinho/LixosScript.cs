using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LixosScript : MonoBehaviour
{
    private GameObject alvo = null;

    public static bool finish;
    public static bool completou = false;
    public static bool podesair = true;

    private void Update()
    {
        if (finish == false)
        {
            if (Input.GetMouseButtonDown(0))
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

                RaycastHit[] hit = Physics.RaycastAll(ray);

                alvo = null;

                foreach (RaycastHit _hit in hit)
                {
                    if (_hit.collider.tag == "Lixo")
                    {
                        if (alvo == null)
                        {
                            alvo = _hit.collider.gameObject;
                        }
                        else
                        {
                            if (alvo.GetComponent<MoveDrag>().trashUp < _hit.collider.gameObject.GetComponent<MoveDrag>().trashUp)
                            {
                                alvo = _hit.collider.gameObject;
                            }
                        }
                    }

                    if (_hit.collider.gameObject.tag == "Item")
                    {
                        if (alvo == null)
                        {
                            Destroy(_hit.collider.gameObject);

                            finish = true;

                            if (finish == true)
                            {
                                //AudioManager.instance.Play("Win");
                                Invoke("Sair", 1.5f);
                            }
                        }
                    }
                }

                if (alvo != null)
                {
                    alvo.GetComponent<MoveDrag>().moving = true;
                }
            }

            if (Input.GetMouseButtonUp(0))
            {
                if (alvo != null)
                {
                    alvo.GetComponent<MoveDrag>().moving = false;
                }

                alvo = null;
            }
        }
    }

    void Sair()
    {
        GameObject[] col = GameObject.FindGameObjectsWithTag("Objetos");

        foreach (GameObject go in col)
        {
            go.GetComponent<BoxCollider2D>().enabled = true;
        }

        SceneManager.UnloadSceneAsync(12);

        LixeiraScript.isActive = false;

        completou = true;

        podesair = true;
    }
}
