using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerHealthSystemJA : MonoBehaviour
{

    public int health = 3;
    public int lives = 3;
    public GameObject heart3;
    public GameObject heart2;
    public TMP_Text healthText;

    private bool inCoolDown = false;

    void Start()
    {
        healthText.text = "Health: 3";
    }

    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject gameObject = collision.gameObject;
        if (gameObject.tag == "Boss")
        {
            if (inCoolDown == false)
            {
                StartCoroutine(CoolDown());
                inCoolDown = true;
                health--;
                healthText.text = "Health: " + health.ToString();
                Debug.Log("Health" + health);
                Debug.Log("Lives" + lives);
                if (health == 0)
                {
                    lives = lives - 1;
                    health = 3;
                }
                if (lives == 2)
                {
                    Destroy(heart3);
                }
                if (lives == 1)
                {
                    Destroy(heart3);
                }
                if (lives == 0)
                {
                    Debug.Log("GAME OVER");
                    //UnityEngine.SceneManagement.SceneManager.LoadScene("GameOverScene");
                }
                
            }

        }

    }

    IEnumerator CoolDown()
    {
        yield return new WaitForSeconds(5);
        inCoolDown = false;
    }
}
