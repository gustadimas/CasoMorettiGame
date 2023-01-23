using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VerificadorAtendente : MonoBehaviour
{
    [SerializeField] GameObject atendente;
    [SerializeField] GameObject atendenteClone;

    void Start() 
    {
        if(PlayerPrefs.HasKey("conversou_com_atendente") == false)
        {
            PlayerPrefs.SetInt("conversou_com_atendente", 0);
        }    

        if(PlayerPrefs.GetInt("conversou_com_atendente") == 1)
        {
            atendente.SetActive(false);
            atendenteClone.SetActive(true);
        }
        else
        {
            atendente.SetActive(true);
            atendenteClone.SetActive(false);
        }
    }
}

