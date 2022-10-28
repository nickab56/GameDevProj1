using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthSystemJA : MonoBehaviour
{

    public int health = 3;
    public int lives = 3;

    private bool inCoolDown = false;

    void Start()
    {
        
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
                inCoolDown = true;
                health -= health;
                StartCoroutine(CoolDown());
                if (health == 0)
                {
                    lives -= lives;
                    health = 3;
                }
                if (lives == 0)
                {
                    Debug.Log("GAME OVER");
                    //UnityEngine.SceneManagement.SceneManager.LoadScene("GameOverScene");
                }
                Debug.Log("Health" + health);
                Debug.Log("Lives" + lives);
            }

        }

    }

    IEnumerator CoolDown()
    {
        yield return new WaitForSeconds(3);
        inCoolDown = false;
    }
}
