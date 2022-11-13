using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerHealthSystemJA : MonoBehaviour
{
    public int lives = 3;
    public GameObject heart3;
    public GameObject heart2;

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
                StartCoroutine(CoolDown());
                inCoolDown = true;
                Debug.Log("Lives" + lives);
                
                lives = lives - 1;
                if (lives == 2)
                {
                    Destroy(heart3);
                }
                if (lives == 1)
                {
                    Destroy(heart2);
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
        yield return new WaitForSeconds(2);
        inCoolDown = false;
    }
}
