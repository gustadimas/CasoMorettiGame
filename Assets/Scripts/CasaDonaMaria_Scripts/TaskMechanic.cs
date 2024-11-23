using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class TaskMechanic : MonoBehaviour
{
    static public TaskMechanic Instance;
    
    public int connectionCount;

    //public GameObject winText;
    [SerializeField] GameObject luz;
    [SerializeField] GameObject velhos;

    public static bool completou = false;
    public static bool podesair = true;

    private int onCount = 0;
    
    private void Awake()
    {
        Instance = this;
        luz = GameObject.Find("Luz");
        velhos = GameObject.Find("Velhos");
    }

    private void Start() => TaskMechanic.completou = false;

    public void Fios(int points)
    {
        onCount = onCount + points;
        if (onCount == connectionCount)
        {
            //winText.SetActive(true);
            //AudioManager.instance.Play("Win");
            Invoke("Sair",1.5f);
        }
    }

    void Sair()
    {
        GameObject[] col = GameObject.FindGameObjectsWithTag("Parede");

        foreach (GameObject go in col)
        {
            go.GetComponent<BoxCollider2D>().enabled = true;
        }

        luz.SetActive(false);

        velhos.transform.GetChild(0).gameObject.SetActive(true);
        velhos.transform.GetChild(1).gameObject.SetActive(true);
        velhos.transform.GetChild(2).gameObject.SetActive(true);

        SceneManager.UnloadSceneAsync(6);

        CaixaDeForca.isActive = false;

        completou = true;

        podesair = true;
    }
}
