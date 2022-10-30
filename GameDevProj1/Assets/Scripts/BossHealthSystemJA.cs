using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHealthSystemJA : MonoBehaviour
{
    public int health = 10;
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
            health--;
            if (health == 0)
                Destroy(this.gameObject);
        }

    }
}
