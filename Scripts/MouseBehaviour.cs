using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseBehaviour : MonoBehaviour
{

    [SerializeField] private SpriteRenderer spr;
    [SerializeField] private Color holdColor;
    [SerializeField] private Color freeColor;

    public static MouseBehaviour instance;

    private void Awake()
    {
        instance = this;

        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Confined;
    }


    public bool isHolding = false;

    private void Update()
    {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        transform.position = mousePos;


        if (Input.GetMouseButton(0))
        {
            isHolding = true;
            spr.color = holdColor;
        }
        else
        {
            isHolding = false;
            spr.color = freeColor;
        }

    }

}
