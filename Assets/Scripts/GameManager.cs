using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    private GameObject circleSpin;
    private GameObject fireCircle;
    public Animator animator;
    public float gameovertoMainmSec;
    public Text circleSpinLevel;
    public Text one;//1
    public Text two;//2
    public Text three;//3
    public int fireBall;
    public int leveltransitiontime;
    private bool control = true;
    void Start()
    {
        circleSpin = GameObject.FindGameObjectWithTag("Circle");
        fireCircle = GameObject.FindGameObjectWithTag("FireCircle");
        circleSpinLevel.text = SceneManager.GetActiveScene().name;
        Debug.Log(SceneManager.GetActiveScene().name);

        if (fireBall<2)
        {
            one.text = fireBall + "";
        }
        else if (fireBall<3)
        {
            one.text = fireBall + "";
            two.text = fireBall - 1 + "";
        }
        else
        {
            one.text = fireBall + "";
            two.text = fireBall - 1 + "";
            three.text = fireBall - 2 + "";
        }
        
    }

    public void fireBallText()
    {
        fireBall--;
        if (fireBall<2)
        {
            one.text = fireBall + "";
            two.text = "";
            three.text = "";
        }
        else if (fireBall<3)
        {
            one.text = fireBall + "";
            two.text = fireBall - 1 + "";
            three.text = "";
        }
        else
        {
            one.text = fireBall + "";
            two.text = fireBall - 1 + "";
            three.text = fireBall - 2 + "";
        }

        if (fireBall==0)
        {
            StartCoroutine(gameOverThisLevel());
        }

        IEnumerator gameOverThisLevel()
        {
            circleSpin.GetComponent<CircleSpin>().enabled = false;
            fireCircle.GetComponent<FireCircle>().enabled = false;
            yield return new WaitForSeconds(leveltransitiontime);
            if (control)
            {
                SceneManager.LoadScene(int.Parse(SceneManager.GetActiveScene().name) + 1);
            }
        }
        
    }

    public void GameOver()
    {
        StartCoroutine(CallGameOver());
            
    }
    IEnumerator CallGameOver()
    {
        circleSpin.GetComponent<CircleSpin>().enabled = false;
        fireCircle.GetComponent<FireCircle>().enabled = false;
        animator.SetTrigger("GameOver");
        control = false;
        
        yield return new WaitForSeconds(gameovertoMainmSec);
        
        SceneManager.LoadScene("MainMenu");
        

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
