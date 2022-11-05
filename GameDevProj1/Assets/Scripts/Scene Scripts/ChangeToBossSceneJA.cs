using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeToBossSceneJA : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject gameObject = collision.gameObject;
        if (gameObject.tag == "Player")
            UnityEngine.SceneManagement.SceneManager.LoadScene("BossScene");
    }
}
