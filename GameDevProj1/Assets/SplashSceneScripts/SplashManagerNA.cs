using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SplashManagerNA : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(ChangeScene());
    }


    IEnumerator ChangeScene()
    {
        yield return new WaitForSeconds(5);
        UnityEngine.SceneManagement.SceneManager.LoadScene("BossScene");
    }
}
