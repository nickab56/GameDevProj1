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
       

        StartCoroutine(wait());

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void Awake()
    {

    }


    IEnumerator wait()
    {
        yield return new WaitForSeconds(5);
        UnityEngine.SceneManagement.SceneManager.LoadScene("GameOverScene");
    }
}
