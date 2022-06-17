using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireCircle : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject fireCircle;
    private GameObject gameManager;
    void Start()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameManager");

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            fireCircleCreate();
            
        }
    }

    
    void fireCircleCreate()
    {
        Instantiate(fireCircle, transform.position, transform.rotation);
        gameManager.GetComponent<GameManager>().fireBallText();
    }
}
