using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LimiteCamera : MonoBehaviour
{
    private Camera main_camera;
    private Vector2 screenBounds;

    private float playerWidth;
    private float playerHeight;

    private float minimum_x_value;
    private float maximum_x_value;
    private float minimum_y_value;
    private float maximum_y_value;

    private void Start()
    {
        main_camera = Camera.main;
        screenBounds = main_camera.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, main_camera.transform.position.z));
        playerWidth = transform.GetComponent<SpriteRenderer>().bounds.extents.x;
        playerHeight = transform.GetComponent<SpriteRenderer>().bounds.extents.y;
    }

    private void LateUpdate()
    {
        CreateCollisionsAtTheEdgesOfTheScreen();
    }

    private void CreateCollisionsAtTheEdgesOfTheScreen()
    {

        Vector3 viewPosition = transform.position;

        // Multiplica por -1 para deixar o valor positivo.
        minimum_x_value = (screenBounds.x * -1) + playerWidth;
        maximum_x_value = screenBounds.x - playerWidth;

        minimum_y_value = (screenBounds.y * -1) + playerHeight;
        maximum_y_value = screenBounds.y - playerHeight;

        /* Mathf.Clamp(value, min, max) -> Retorna:  
            - min se o valor float fornecido for menor que o mínimo.   
            - max se o valor fornecido for maior que o valor máximo.
            - value, caso o próprio valor fornecido caso esteja no intervalo de min e max.
        */

        viewPosition.x = Mathf.Clamp(viewPosition.x, minimum_x_value, maximum_x_value);
        viewPosition.y = Mathf.Clamp(viewPosition.y, minimum_y_value, maximum_y_value);

        transform.position = viewPosition;
    }
}
