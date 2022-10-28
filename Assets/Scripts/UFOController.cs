using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.IO;
using UnityEngine.UIElements;
using Image = UnityEngine.UI.Image;

public class UFOController : MonoBehaviour
{
    static public bool m_IsGameOver = false;
    public BestController bestController;
    public ScoreTextController scoreTextController;
    public QuestionDialogUI questionDialogUI;
    public Image healthBar;
    public Text bloodText;
    public int initialblood;
    public int blood;
    public float speed = 14f;
    Rigidbody2D rbody2D;

    public Text bestScore;
    public Text Score;
    public Animator animator;
    //public Textcontroller textcontroller;
    // Use this for initialization
    void Start()
    {
        rbody2D = this.GetComponent<Rigidbody2D>();
        blood = 300;
        initialblood = 300;
        bloodText.text = "LIFE POINT: " + blood;
        animator = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.A) && transform.localPosition.x > -50)
        {
            transform.localPosition += new Vector3(-speed, 0, 0) * Time.deltaTime;
            animator.SetInteger("state", 1);
        }
        if (Input.GetKey(KeyCode.D) && transform.localPosition.x < 40)
        {
            transform.localPosition += new Vector3(speed, 0, 0) * Time.deltaTime;
            animator.SetInteger("state", 1);
        }
        if (Input.GetKey(KeyCode.S) && transform.localPosition.y > -25)
        {
            transform.localPosition += new Vector3(0, -speed, 0) * Time.deltaTime;
            animator.SetInteger("state", 1);
        }
        if (Input.GetKey(KeyCode.W) && transform.localPosition.y < 25)
        {
            transform.localPosition += new Vector3(0, speed, 0) * Time.deltaTime;
            animator.SetInteger("state", 1);
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            this.transform.localScale = new Vector3(-1 * this.transform.localScale.x, this.transform.localScale.y, this.transform.localScale.z);
        }
        if (Input.GetKeyUp(KeyCode.A))
        {
            this.transform.localScale = new Vector3(-1 * this.transform.localScale.x, this.transform.localScale.y, this.transform.localScale.z);
            animator.SetInteger("state", 0);
        }
        if (Input.GetKeyUp(KeyCode.D))
        {
            animator.SetInteger("state", 0);
        }
        if (Input.GetKeyUp(KeyCode.W))
        {
            animator.SetInteger("state", 0);
        }
        if (Input.GetKeyUp(KeyCode.S))
        {
            animator.SetInteger("state", 0);
        }
        if (Input.anyKey == false)
        {
            animator.SetInteger("state", 0);
        }
    }
    
    public void Damaged(int n)
    {
        blood -= n;
        healthBar.GetComponent<Image>().fillAmount = (float)blood/(float)initialblood;
        bloodText.text = blood.ToString() + "/" + initialblood.ToString();
        
        if (blood == 0)
        {
            Die();
            string best = bestScore.GetComponent<Text>().text;
            // Debug.Log(best);
            string score = Score.GetComponent<Text>().text;
            string question = "You Died \n"+best+"\n"+""+score+"\n"
                    +"Do you want to restart the game?";

            QuestionDialogUI.Instance.ShowQuestion(question, () => {
                Restart();
                SceneManager.LoadScene(1);
                
            }, () => {
                // Do nothing on No
                Restart();
                SceneManager.LoadScene(0);
            });
        }
    }

    public void Die()
    {
        m_IsGameOver = true;
        Time.timeScale = 0f;
    }

    public void Restart()
    {
        Time.timeScale = 1f;
        m_IsGameOver = false;
    }

    public bool isDie()
    {
        return m_IsGameOver;
    }
}

