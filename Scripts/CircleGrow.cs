using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class CircleGrow : MonoBehaviour
{

    [SerializeField] private float growSpeed = 1f;
    [SerializeField] private float shrinkSpeed  = 1.2f;

    [SerializeField] private float deathSize = 0.01f;
    [SerializeField] private float winSize = 21f;

    [SerializeField] private TMP_Text score;
    [SerializeField] private TMP_Text timeTXT;

    [SerializeField] private CircleCollider2D col2D;

    [SerializeField] private LayerMask mouseMask;
    [SerializeField] private LayerMask obstacleMask;

    [SerializeField] private GameObject startScreen;
    [SerializeField] private GameObject winScreen;
    [SerializeField] private GameObject loseScreen;
    [SerializeField] private GameObject stats;

    public static CircleGrow instance;

    public bool end = false;

    private bool start = false;

    private float tm = 0f;
    private int seconds = 0;

    private void Awake()
    {
        Time.timeScale = 0f;
        instance = this;
    }


    // Update is called once per frame
    void Update()
    {


        if (Input.GetMouseButtonDown(0) && !start && mouseInsideCircle())
        {
            start = true;
            startScreen.SetActive(false);
            stats.SetActive(true);
            Time.timeScale = 1f;
        }


        if (!end && start)
        {
            tm += Time.deltaTime;

            seconds = (int)tm % 60;

            if (Input.GetMouseButton(0) && mouseInsideCircle())
            {
                transform.localScale += new Vector3(growSpeed, growSpeed, 0) * (Time.deltaTime * 100);
            }
            else
            {
                transform.localScale -= new Vector3(shrinkSpeed, shrinkSpeed, 0) * (Time.deltaTime * 100);
            }

            if (hitByObstacle())
            {
                die();
            }

            score.text = ((int)transform.localScale.x).ToString();
            timeTXT.text = seconds.ToString() + "s";


        }
        if(transform.localScale.x <= deathSize)
        {
            //Debug.Log("Death");
            Time.timeScale = 0f;
            stats.SetActive(false);
            loseScreen.SetActive(true);
            end = true;
        }
        else if (transform.localScale.x >= winSize)
        {
            //Debug.Log("win");
            Time.timeScale = 0f;
            stats.SetActive(false);
            winScreen.SetActive(true);
            end = true;
        }


    }

    public float getSize()
    {
        return transform.localScale.x;
    }
    private bool mouseInsideCircle()
    {
        return Physics2D.OverlapCircle(transform.position, col2D.bounds.extents.x, mouseMask) != null;
    }

    private bool hitByObstacle()
    {
        return Physics2D.OverlapCircle(transform.position, col2D.bounds.extents.x, obstacleMask) != null;
    }

    private void die()
    {
        Time.timeScale = 0f;
        stats.SetActive(false);
        loseScreen.SetActive(true);
    }
}
