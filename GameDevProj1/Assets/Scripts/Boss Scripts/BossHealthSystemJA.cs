using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class BossHealthSystemJA : MonoBehaviour
{
    public float health = 10;

    public RectTransform bossHealthBarTransform;


    // Start is called before the first frame update
    void Start()
    {
        
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
            health -= .4f;
            //healthText.text = "Health: " + health.ToString();
            ScaleHealthBar();
            if (health == 0)
            {
                Constants.C.BossAlive = false;
                Destroy(this.gameObject);
            }
            Destroy(gameObject);

        }

    }

    public void ScaleHealthBar()
    {
        //health -= amount;
        if (health < 0)
            health = 0;
        bossHealthBarTransform.sizeDelta = new Vector2(health, bossHealthBarTransform.sizeDelta.y);
    }

}
