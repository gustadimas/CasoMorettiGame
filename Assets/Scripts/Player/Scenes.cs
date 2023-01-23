using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scenes : MonoBehaviour
{
    public string sLevelToLoad;

    public bool useIntToLoadLevel = false;
    private bool porta = false;

    private void Update()
    {
        if (porta)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                mudarCena();
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        porta = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        porta = false;
    }

    public void mudarCena()
    {
        if (useIntToLoadLevel)
        {
            SceneManager.LoadScene(sLevelToLoad);
        }
    }
}

