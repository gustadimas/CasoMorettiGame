using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fios : MonoBehaviour
{
    public SpriteRenderer fimFio;
    public GameObject luzOn;
    Vector3 pontoPartida;
    Vector3 pontoPosicao;
    
    // Start is called before the first frame update
    void Start()
    {
        pontoPartida = transform.parent.position;
        pontoPosicao = transform.position;
    }

    private void OnMouseDrag()
    {
        // posi��o do mouse 
        Vector3 newPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        newPosition.z = 0;
        
        // conex�es proximas
        Collider2D[] colisores = Physics2D.OverlapCircleAll(newPosition, .2f);

        foreach(Collider2D colisor in colisores)
        {
            if (colisor.gameObject != gameObject)
            {
                Atualizafio(colisor.transform.position);
               
                //ve se os fios s�o da mesma cor
                if (transform.parent.name.Equals(colisor.transform.parent.name))
                {
                    TaskMechanic.Instance.Fios(1);
                    colisor.GetComponent<Fios>()?.Feito();
                    Feito();
                }
                return;
            }
        }
        // atualiza o fio
        Atualizafio(newPosition);
    }

    void Feito()
    {
        luzOn.SetActive(true);

        Destroy(this);
    }

    private void OnMouseUp()
    {
        Atualizafio(pontoPosicao);
    }

    void Atualizafio(Vector3 newPosition)
    {
        // Atualiza a posi��o do fio
        transform.position = newPosition;

        // Dire��o do fio
        Vector3 direcao = newPosition - pontoPartida;
        transform.right = direcao * transform.lossyScale.x;

        // Atualiza a escala
        float distancia = Vector2.Distance(pontoPartida, newPosition);
        fimFio.size = new Vector2(distancia, fimFio.size.y);
    }
}
