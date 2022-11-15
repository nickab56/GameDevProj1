using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SplashManagerNA : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Constants.C.lives = 3;
    }

    void Update()
    {
        WaitResponse();
    }

    void WaitResponse()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene("TutorialScene");
        }

    }


    //IEnumerator ChangeScene()
    //{
    //    yield return new WaitForSeconds(5);
    //    UnityEngine.SceneManagement.SceneManager.LoadScene("TutorialScene");
    //}
}
