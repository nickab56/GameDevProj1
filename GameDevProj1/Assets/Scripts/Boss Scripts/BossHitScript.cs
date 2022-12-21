using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHitScript : MonoBehaviour
{
    public Manager Manager;
    public BossHealthSystemJA HealthScript;

    public AudioSource BossHurt;

    // Start is called before the first frame update
    void Start()
    {
        Manager = GetComponent<Manager>();
        HealthScript = Manager.GetComponent<BossHealthSystemJA>();
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
            if (!BossHurt.isPlaying)
            {
                BossHurt.PlayOneShot(BossHurt.clip, 0.5f);
            }
            HealthScript.health -= .4f;
            //healthText.text = "Health: " + health.ToString();
            HealthScript.ScaleHealthBar();
            if (HealthScript.health == 0)
            {

                Constants.C.BossAlive = false;
                Destroy(this.gameObject);
            }
            Destroy(gameObject);

        }

    }
}

