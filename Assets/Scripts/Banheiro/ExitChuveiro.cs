using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitChuveiro : StateMachineBehaviour
{
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Sair();
    }

    void Sair()
    {
        GameObject[] col = GameObject.FindGameObjectsWithTag("Objetos");

        foreach (GameObject go in col)
        {
            go.GetComponent<BoxCollider2D>().enabled = true;
        }

        SceneManager.UnloadSceneAsync(3);

        BanheiroScript.isActive = false;
    }
}
