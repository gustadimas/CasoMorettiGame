using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MouseBarForce : MonoBehaviour
{
    //GameObject congratulationButton, barraConfianca, posBarra, buttonGameOver;
    public GameObject ContBar;
    public GameObject indicador;
    private Collider2D coll;

    private Animator anim;

    [SerializeField] private float quantBar;
    private float quantBarMax = 2.15f;
    private float deltaDist = 0.003f;

    private bool lockDistance = true;

    public static bool finalizou = false;
    public static bool completou = false;
    public static bool podesair = true;

    void Start()
    {
        anim = GetComponent<Animator>();

        quantBar = Random.Range(0.25f, 2.15f);
        //quantBar = 2.15f;
        indicador.transform.position = new Vector2(indicador.transform.position.x, indicador.transform.position.y - (quantBar * 3));
        coll = gameObject.GetComponent<Collider2D>();
        coll.enabled = true;
    }

    void Update()
    {
        if (lockDistance)
        {
            ContBar.transform.localScale = new Vector2(ContBar.transform.localScale.x, 0f);    
        }
    }

    private void OnMouseDown()
    {
        lockDistance = false;

        anim.SetBool("Pressed", true);
    }

    private void OnMouseUp()
    {
        if((ContBar.transform.localScale.y < quantBar + 0.03f) && (ContBar.transform.localScale.y > quantBar - 0.03f))
        {
            anim.SetBool("Pressed", false);

            finalizou = true;
            
            if (finalizou == true)
            {
                //AudioManager.instance.Play("Win");

                //Invoke("Sair", 1.5f);

                GameObject.FindObjectOfType<MaozinhaScript>().mao_pode_sair = true;

                completou = true;

                podesair = true;

                coll.enabled = false;
            }
            //congratulationButton.SetActive(true);
        } 
        else
        {
            lockDistance = true;
        }        
    }
 
    private void OnMouseDrag()
    {
        if (Input.GetMouseButton(0))
        {
            if(ContBar.transform.localScale.y < quantBarMax)
            {
                //transform.position = new Vector2(transform.position.x + deltaDist, transform.position.y - deltaDist);
                ContBar.transform.localScale = new Vector2(ContBar.transform.localScale.x, ContBar.transform.localScale.y + deltaDist);
            }

        }
    }

    //void Sair()
    //{
    //    GameObject[] col = GameObject.FindGameObjectsWithTag("Objetos");

    //    foreach (GameObject go in col)
    //    {
    //        go.GetComponent<BoxCollider2D>().enabled = true;
    //    }

    //    SceneManager.UnloadSceneAsync(9);

    //    BanheiroScript.isActive = false;

    //    completou = true;

    //    podesair = true;
    //}

}
