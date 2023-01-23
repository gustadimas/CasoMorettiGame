using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VerificadorBarman : MonoBehaviour
{
    [SerializeField] GameObject barman;
    [SerializeField] GameObject barmanClone;

    void Start() 
    {
        if(PlayerPrefs.HasKey("conversou_com_barman") == false)
        {
            PlayerPrefs.SetInt("conversou_com_barman", 0);
        }    

        VerificarEstadoBarman();
    }

    public void VerificarEstadoBarman() 
    {
        if(PlayerPrefs.GetInt("conversou_com_barman") == 1)
        {
            PlayerPrefs.SetInt("portaDelegacia", 1);
            barman.SetActive(false);
            barmanClone.SetActive(true);
        }
        else
        {
            barman.SetActive(true);
            barmanClone.SetActive(false);
        }
    }
}
