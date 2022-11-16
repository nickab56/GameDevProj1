using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour        // Worked on by everyone so not given initials
{
    public float pastTime;
    public float time;

    public AudioSource BossDeath;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        BossCheck();
    }

    private void Awake()
    {

    }

    private void BossCheck()
    {
        if (!Constants.C.BossAlive)
            StartCoroutine(ChangeScene());
    }


    IEnumerator ChangeScene()
    {
        BossDeath.PlayOneShot(BossDeath.clip, 0.5f);
        yield return new WaitForSeconds(3);
        UnityEngine.SceneManagement.SceneManager.LoadScene("GameOverScene");
    }
}
