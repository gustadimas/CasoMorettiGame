using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MaozinhaScript : MonoBehaviour
{
    [SerializeField] GameObject anel;

    private bool chegou_no_anel = false;

    public bool mao_pode_sair = false;

    private void Update() 
    {
        if (chegou_no_anel == false && mao_pode_sair)
        {
            SeguirAnel();
        }
    }

    void SeguirAnel()
    {
        transform.position = Vector2.MoveTowards(transform.position, anel.transform.position, 2f * Time.deltaTime);

        if (transform.position == anel.transform.position)
        {
            Debug.Log("Entrou(la ele");

            GetComponent<Animator>().SetBool("Maozinha", true);

            //Invoke("Sair", 1.5f);
        }
    }
}
