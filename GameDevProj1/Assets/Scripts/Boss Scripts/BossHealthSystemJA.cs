using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class BossHealthSystemJA : MonoBehaviour
{
    public int health = 10;
    public TMP_Text healthText;
    // Start is called before the first frame update
    void Start()
    {
        healthText.text = "Health: 10";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject gameObject = collision.gameObject;
        if (gameObject.tag == "Bullet")
        {
            health--;
            healthText.text = "Health: " + health.ToString();
            if (health == 0)
            {
                Constants.C.BossAlive = false;
                Destroy(this.gameObject);
            }
            Destroy(gameObject);

        }

    }

}
