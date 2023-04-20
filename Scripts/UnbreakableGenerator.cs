using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnbreakableGenerator : MonoBehaviour
{

    [SerializeField] private GameObject unbreakable;
    [SerializeField] private Transform p1;
    [SerializeField] private Transform p2;

    [SerializeField] private Vector2 spawnTimeRange = new Vector2(0.5f,1.5f);

    [SerializeField] private float throwPower = 7f;

    private bool spawned = false;

    private void Awake()
    {
        StartCoroutine(waitForNext());
    }

    private void Update()
    {
        if (!spawned && !CircleGrow.instance.end)
        {
            GameObject a = Instantiate(unbreakable,p1.position, unbreakable.transform.rotation);
            GameObject b = Instantiate(unbreakable, p2.position, unbreakable.transform.rotation);
            a.GetComponent<obstacle>().setPandD(throwPower, Vector2.right);
            b.GetComponent<obstacle>().setPandD(throwPower, Vector2.left);
            StartCoroutine(waitForNext());
        }
    }

    IEnumerator waitForNext()
    {
        spawned = true;
        yield return new WaitForSeconds(Random.Range(spawnTimeRange.x, spawnTimeRange.y));
        spawned = false;
    }

}
