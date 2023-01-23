using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Audio;

public class Menu : MonoBehaviour
{
    public Slider volumeSlider;
    public AudioMixer mixer;
    //private float value;

    private void Start()
    {
        //mixer.GetFloat("volume", out value);
        //volumeSlider.value = value;
    }

    public void StartGame()
    {
        ResetPlayerPrefs();

        SceneManager.LoadScene("CutsceneInicial");
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void SetVolume()
    {
        mixer.SetFloat("volume", volumeSlider.value);
    }

    private void ResetPlayerPrefs()
    {
        PlayerPrefs.SetInt("conversou_com_os_velhos", 0);

        PlayerPrefs.SetInt("conversou_com_atendente", 0);

        PlayerPrefs.SetInt("conversou_com_barman", 0);

        PlayerPrefs.SetInt("portaDelegacia", 0);

        PlayerPrefs.SetInt("portaDelegacia", 0);

        ResetPositionsScenes();
    }

    private void ResetPositionsScenes()
    {
        // Cena Apartamento Sofia
        PlayerPrefs.SetFloat("ApartamentoSofia 1" + "X", 4.4f);
        PlayerPrefs.SetFloat("ApartamentoSofia 1" + "Y", -3.95f);
        PlayerPrefs.SetFloat("ApartamentoSofia 1" + "Z", 0);

        // Cena Apartamento Veios
        PlayerPrefs.SetFloat("CasaDonaMaria" + "X", -4.99f);
        PlayerPrefs.SetFloat("CasaDonaMaria" + "Y", -3.95f);
        PlayerPrefs.SetFloat("CasaDonaMaria" + "Z", 0);           

        // Cena Predio Apartamentos
        PlayerPrefs.SetFloat("PredioApartamentos" + "X", -2.57f);
        PlayerPrefs.SetFloat("PredioApartamentos" + "Y", -3.29f);
        PlayerPrefs.SetFloat("PredioApartamentos" + "Z", 0);           

        // Cena Mercadinho
        PlayerPrefs.SetFloat("Mercadinho" + "X", -0.27f);
        PlayerPrefs.SetFloat("Mercadinho" + "Y", -3.96f);
        PlayerPrefs.SetFloat("Mercadinho" + "Z", 0);           

        // Cena Mercadinho Fundos
        PlayerPrefs.SetFloat("MercadinhoFundos" + "X", -7.46f);
        PlayerPrefs.SetFloat("MercadinhoFundos" + "Y", -0.99f);
        PlayerPrefs.SetFloat("MercadinhoFundos" + "Z", 0);           

        // Cena Bar
        PlayerPrefs.SetFloat("Bar" + "X", 1.92f);
        PlayerPrefs.SetFloat("Bar" + "Y", -4.2375f);
        PlayerPrefs.SetFloat("Bar" + "Z", 0);           

        // Cena Delegacia
        PlayerPrefs.SetFloat("Delegacia" + "X", 4.7f);
        PlayerPrefs.SetFloat("Delegacia" + "Y", -3.1f);
        PlayerPrefs.SetFloat("Delegacia" + "Z", 0);           

        // Cena Cidade
        PlayerPrefs.SetFloat("Cidade" + "X", 19.95f);
        PlayerPrefs.SetFloat("Cidade" + "Y", -4.38f);
        PlayerPrefs.SetFloat("Cidade" + "Z", 0);                
    }
}
