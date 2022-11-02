using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossShootHB : MonoBehaviour
{
    public GameObject Bullet;
    public GameObject shootPoint;     //Change to bossShootPoint
    public float coolDownTime = 1f;

    private bool inCoolDown = false;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Space) && !inCoolDown)
        {
            inCoolDown = true;

            GameObject go = Instantiate(Bullet);
            //go.transform.SetPositionAndRotation(shootPoint.transform.position, shootPoint.transform.rotation);
            go.transform.position = shootPoint.transform.position;  //Change to bossShootPoint
            go.transform.rotation = shootPoint.transform.rotation;  //Change to bossShootPoint
            BulletHB b = go.GetComponent<BulletHB>();
            b.speed = 10;

            StartCoroutine(CoolDown());
        }
    }

    IEnumerator CoolDown()
    {
        yield return new WaitForSeconds(coolDownTime);
        inCoolDown = false;
    }
}

