using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class setX : MonoBehaviour
{
    public Transform obj;

    void Update()
    {
        transform.position = new Vector2(transform.position.x, obj.position.y);
    }
}
