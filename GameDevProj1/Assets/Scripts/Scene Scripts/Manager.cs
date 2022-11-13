using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour
{
    public float pastTime;
    public float time;



    
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
        yield return new WaitForSeconds(4);
        UnityEngine.SceneManagement.SceneManager.LoadScene("GameOverScene");
    }
}
