using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PaginaDiario : MonoBehaviour
{  
    public GameObject paginaImage;
    private GameObject luzBanheiro;
    private GameObject portaBanheiro;
    Collider2D colider = null;

    private bool image;
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
        }
    }

    private void Start()
    {
        paginaImage.SetActive(false);
        
        image = false;

        luzBanheiro = GameObject.Find("LuzBanheiro");
        
        portaBanheiro = GameObject.Find("PortaBanheiro");
    }

    private void OnTriggerStay2D(Collider2D col)
    {
        GameObject collisionGameObject = col.gameObject;
        if (Input.GetKeyDown(KeyCode.E))
        {        
            if (image == false)
            {
                paginaImage.SetActive(true);
                image = true;

                isActive = true;

                if (image == true)
                {
                    Invoke("Pagina", 8f);
                }
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D Colisor)
    {
        if (LixosScript.completou == true)
        {
            luzBanheiro.SetActive(false);
            portaBanheiro.SetActive(false);
        }
    }
    private void OnCollisionExit2D(Collision2D Colisor)
    {

    }

    private void Pagina()
    {
        paginaImage.SetActive(false);

        isActive = false;
    }
}
