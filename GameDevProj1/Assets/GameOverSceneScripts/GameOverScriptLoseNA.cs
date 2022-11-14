using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameOverScriptLoseNA : MonoBehaviour
{
    public TMP_Text GameOverTxt;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        WaitResponse();
    }

    void WaitResponse()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene("SplashScene");
        }

    }
}
