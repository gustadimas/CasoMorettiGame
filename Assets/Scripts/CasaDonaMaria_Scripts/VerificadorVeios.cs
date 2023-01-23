using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VerificadorVeios : MonoBehaviour
{
    [SerializeField] GameObject velho;
    [SerializeField] GameObject velha;
    [SerializeField] GameObject colisorvelhos;


    void Start() 
    {
        if(PlayerPrefs.HasKey("conversou_com_os_velhos") == false)
        {
            PlayerPrefs.SetInt("conversou_com_os_velhos", 0);
        }    

        if(PlayerPrefs.GetInt("conversou_com_os_velhos") == 1)
        {
            velho.SetActive(false);
            velha.SetActive(false);
            colisorvelhos.SetActive(false);
        }


    }
}
