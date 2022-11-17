using System.Collections;
using System.Collections.Generic;
using TMPro.Examples;
using UnityEngine;

public class TimerNA : MonoBehaviour
{
    float time = 0;
    float pastTime = 9999;
    public string playerPrefHighScoreKey = "playerBestTime";

    private const string highScoreKey = "best_time";

    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.HasKey(highScoreKey))   // key exists
        {
            pastTime = PlayerPrefs.GetFloat(highScoreKey);
            Debug.Log("Found Score " + pastTime);

        }
        else
        {
            PlayerPrefs.SetFloat(highScoreKey, time);
            Debug.Log("Setting high score");
        }
    }

    // Update is called once per frame
    void Update()
    {
        //Constants.C.timeCount += Time.deltaTime;
        time += Time.deltaTime;
    }

    private void OnDisable()
    {

        if (Constants.C.PlayerAlive == true)
        {
            if (time < pastTime && pastTime != 0)
            {
                PlayerPrefs.SetFloat(highScoreKey, time);
            }
            Constants.C.timeCount = time;
            Constants.C.HighTime = PlayerPrefs.GetFloat(highScoreKey);
        }

    }

}
