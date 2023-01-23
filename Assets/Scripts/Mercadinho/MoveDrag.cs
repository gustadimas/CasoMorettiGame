using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveDrag : MonoBehaviour
{
    private float startPosX;
    private float startPosY;

    public bool moving;

    public int trashUp;

    private void Awake()
    {
        GetComponent<SpriteRenderer>().sortingOrder = trashUp;
    }

    private void Update()
    {
        if (moving)
        {
            transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition) + new Vector3(0, 0, Mathf.Abs(Camera.main.gameObject.transform.position.z));
        }
    }
}
