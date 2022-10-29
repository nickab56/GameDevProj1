using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameOverScriptNA : MonoBehaviour
{
    public TMP_Text GameOverTxt;
    public TMP_Text PlayerTimeTxt;
    public TMP_Text HighTimeTxt;

    // Start is called before the first frame update
    void Start()
    {
        PlayerTimeTxt.text = "Time: " + Constants.C.timeCount.ToString();
        HighTimeTxt.text = "Best Time: " + Constants.C.HighTime.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
