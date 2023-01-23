using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LastPosition : MonoBehaviour
{
    string cenaAtual;

    private void Start()
    {
        cenaAtual = SceneManager.GetActiveScene().name;

        //if (PlayerPrefs.HasKey(cenaAtual + "X") && PlayerPrefs.HasKey(cenaAtual + "Y") & PlayerPrefs.HasKey(cenaAtual + "Z"))
        //{
        //    transform.position = new Vector3(PlayerPrefs.GetFloat(cenaAtual + "X"), PlayerPrefs.GetFloat(cenaAtual + "Y"), PlayerPrefs.GetFloat(cenaAtual + "Z"));
        //}

        transform.position = new Vector3(PlayerPrefs.GetFloat(cenaAtual + "X", 0), PlayerPrefs.GetFloat(cenaAtual + "Y", 0), PlayerPrefs.GetFloat(cenaAtual + "Z", 0));

    }

    private void Update()
    {
        SalvarLocalizacao();
    }

    private void SalvarLocalizacao()
    {
        PlayerPrefs.SetFloat(cenaAtual + "X", transform.position.x);
        PlayerPrefs.SetFloat(cenaAtual + "Y", transform.position.y);
        PlayerPrefs.SetFloat(cenaAtual + "Z", transform.position.z);
    }
}
