using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerHealthSystemJA : MonoBehaviour
{
    //public int lives = 3;
    public GameObject heart3;
    public GameObject heart2;

    public AudioSource playerhurt;

    private bool inCoolDown = false;

    void Start()
    {
        //playerhurt = GetComponent<AudioSource>();
    }

    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject gameObject = collision.gameObject;
        if ((gameObject.tag == "Boss") || (gameObject.tag == "BossBullet"))
        {
            if (inCoolDown == false)
            {
                StartCoroutine(CoolDown());
                inCoolDown = true;
                Debug.Log("Lives" + Constants.C.lives);

                Constants.C.lives = Constants.C.lives - 1;

                if (Constants.C.lives == 2)
                {
                    if (!playerhurt.isPlaying)
                    {
                        playerhurt.PlayOneShot(playerhurt.clip, 0.5f);
                    }
                    Destroy(heart3);
                }
                if (Constants.C.lives == 1)
                {
                    if (!playerhurt.isPlaying)
                    {
                        playerhurt.PlayOneShot(playerhurt.clip, 0.5f);
                    }
                    Destroy(heart2);
                }
                if (Constants.C.lives == 0)
                {
                    Constants.C.PlayerAlive = false;
                    if (!playerhurt.isPlaying)
                    {
                        playerhurt.PlayOneShot(playerhurt.clip, 0.5f);
                    }
                    Debug.Log("GAME OVER");
                    UnityEngine.SceneManagement.SceneManager.LoadScene("GameOverSceneLose");
                }


            }

        }

    }

    IEnumerator CoolDown()
    {
        yield return new WaitForSeconds(1);
        inCoolDown = false;
    }
}
