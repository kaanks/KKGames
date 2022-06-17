using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DotCircle : MonoBehaviour
{
    private Rigidbody2D pysic;
    public float dotSpeed;
    private bool movementControl;
    private GameObject gameManager;
    void Start()
    {
        pysic = GetComponent<Rigidbody2D>();
        gameManager = GameObject.FindGameObjectWithTag("GameManager");

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!movementControl)
        {
            pysic.MovePosition(pysic.position + Vector2.up * dotSpeed * Time.deltaTime);

        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag=="Circle")
        {
            transform.SetParent(col.transform);
            movementControl = true;
        }

        if (col.tag=="DotCircle")
        {
            gameManager.GetComponent<GameManager>().GameOver();
        }
    }
}
