using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public Rigidbody2D rb;
    public int Speed;
    public int Jump;
    bool CanJump;
    public GameObject Ground;

    public int Score;
    public Text Text_Score;

    public GameObject LosePage;

    public AudioSource JumpEffect;
    public AudioSource LoseEffect;

    void Start()
    {
        Score = 0;
        Text_Score.text = Score.ToString();
    }

    void FixedUpdate() 
    {
        if(Input.GetKey(KeyCode.A))
        {
            //move left
            rb.AddForce(Vector2.left * Speed);
        }
        if(Input.GetKey(KeyCode.D))
        {
            //move right
            rb.AddForce(Vector2.right * Speed);
        }
    }


    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            if(CanJump == true)
            {
                rb.AddForce(Vector2.up * Jump);
                JumpEffect.Play();
            }
            


            if(Ground.activeInHierarchy == true)
            Ground.SetActive(false);
        }
    }

    private void OnTriggerStay2D(Collider2D other) 
    {
        CanJump = true;
    }

    private void OnTriggerExit2D(Collider2D other) 
    {
        CanJump = false;
    }


    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.gameObject.tag == "Lose")
        {
            //die
            print("You Lose");
            LosePage.SetActive(true);
            LoseEffect.Play();
        }

        if(other.gameObject.tag == "Score")
        {
            Score += 1;
            Text_Score.text = Score.ToString();
            Destroy(other.gameObject);
        }
    }
}
