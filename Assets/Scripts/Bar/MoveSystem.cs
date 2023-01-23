using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MoveSystem : MonoBehaviour
{
    public GameObject correctForm;

    private bool moving;
    private bool finish;
    public static bool completou = false;
    public static bool podesair = true;

    private float startPosX;
    private float startPosY;

    private static int contGarrafas = 0;
    private int contGarrafasWin = 0;

    private Vector3 resetPosition;

    private void Start()
    {
        resetPosition = transform.localPosition;

        contGarrafasWin = PlayerPrefs.GetInt("contGanhou", 0);

        //PlayerPrefs.SetInt("contGanhou", 0);
    }

    private void Update()
    {
        if (finish == false)
        {
            if (moving)
            {
                Vector3 mousePos;
                mousePos = Input.mousePosition;
                mousePos = Camera.main.ScreenToWorldPoint(mousePos);

                gameObject.transform.position = new Vector3(mousePos.x - startPosX, mousePos.y - startPosY, this.gameObject.transform.position.z);
                gameObject.transform.position = new Vector3(mousePos.x, mousePos.y, gameObject.transform.position.z);
            }
        }
    }

    private void OnMouseDown()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            startPosX = mousePos.x - this.transform.localPosition.x;
            startPosY = mousePos.y - this.transform.localPosition.y;         
            
            startPosX = mousePos.x;
            startPosY = mousePos.y;

            moving = true;
        }
    }

    private void OnMouseUp()
    {
        moving = false;

        if (Mathf.Abs(this.transform.localPosition.x - correctForm.transform.localPosition.x) <= 0.5f && 
            Mathf.Abs(this.transform.localPosition.y - correctForm.transform.localPosition.y) <= 0.5f)
        {
            this.transform.position = new Vector3(correctForm.transform.position.x, correctForm.transform.position.y, correctForm.transform.position.z);

            contGarrafas++;

            finish = true;

            if (contGarrafas == 6)
            {
                PlayerPrefs.SetInt("conversou_com_barman", 1);

                GameObject.FindObjectOfType<VerificadorBarman>().VerificarEstadoBarman();

                //AudioManager.instance.Play("Win");

                PlayerPrefs.SetInt("portaDelegacia", 1);

                Invoke("Sair", 1.5f);
            }
        }
        else
        {
            this.transform.localPosition = new Vector3(resetPosition.x, resetPosition.y, resetPosition.z);
        }
    }

    void Sair()
    {
        GameObject[] col = GameObject.FindGameObjectsWithTag("Objetos");

        foreach (GameObject go in col)
        {
            go.GetComponent<BoxCollider2D>().enabled = true;
        }

        GarrafasScript.isActive = false;

        SceneManager.UnloadSceneAsync(9);

        completou = true;

        podesair = true;
    }
}
