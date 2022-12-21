using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class BossHealthSystemJA : MonoBehaviour
{
    public float health = 20;

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
        
    }

    void BossHit()
    {

    }

    public void ScaleHealthBar()
    {
        //health -= amount;
        if (health < 0)
            health = 0;
        bossHealthBarTransform.sizeDelta = new Vector2(health, bossHealthBarTransform.sizeDelta.y);
    }

}
