using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakableSpawner : MonoBehaviour
{
    [SerializeField] private Transform p1;
    [SerializeField] private Transform p2;

    [SerializeField] private GameObject obs;

    [SerializeField] private Vector2 waitRange = new Vector2(3f,5f);

    [SerializeField] private float throwPower;

    [SerializeField] private Color obtsacleColor;

    private bool spawned = false;

    private void Awake()
    {
        StartCoroutine(waitToThrow());
    }

    private void Update()
    {
        if (!spawned)
        {
            int a = Random.Range(0, 2);

            if (a == 1)
            {
                GameObject o = Instantiate(obs, p1.position, Quaternion.Euler(0,0,90));
                o.GetComponent<obstacle>().setPandD(throwPower, Vector2.down);
                o.GetComponent<obstacle>().breakable = true;
                o.GetComponent<SpriteRenderer>().color = obtsacleColor;
            }
            else if (a == 0)
            {
                GameObject o = Instantiate(obs, p2.position, Quaternion.Euler(0, 0, 90));
                o.GetComponent<obstacle>().setPandD(throwPower, Vector2.up);
                o.GetComponent<obstacle>().breakable = true;
                o.GetComponent<SpriteRenderer>().color = obtsacleColor;
            }

            StartCoroutine(waitToThrow());
        }
    }

    IEnumerator waitToThrow()
    {
        spawned = true;
        yield return new WaitForSeconds(Random.Range(waitRange.x,waitRange.y));
        spawned = false;
    }

}
