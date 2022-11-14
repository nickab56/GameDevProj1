using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BossShootHB : MonoBehaviour
{
    public GameObject BulletSplit;
    public GameObject BulletBomb;
    public GameObject BossShootPoint;
    

    private bool inCoolDown = false;
    private int temp = 0;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (inCoolDown == false)
        {

            inCoolDown = true;
            temp = Random.Range(0,2);
            if (temp == 0)
            {
                GameObject go = Instantiate(BulletSplit);
                //go.transform.SetPositionAndRotation(shootPoint.transform.position, shootPoint.transform.rotation);
                go.transform.position = BossShootPoint.transform.position;
                go.transform.rotation = BossShootPoint.transform.rotation;
                BossBulletSplit b = go.GetComponent<BossBulletSplit>();
                b.speed = 5;
            }
            if (temp == 1)
            {
                GameObject go = Instantiate(BulletBomb);
                //go.transform.SetPositionAndRotation(shootPoint.transform.position, shootPoint.transform.rotation);
                go.transform.position = BossShootPoint.transform.position;
                go.transform.rotation = BossShootPoint.transform.rotation;
                BossBulletSpread b = go.GetComponent<BossBulletSpread>();
                b.speed = 5;
            }
            StartCoroutine(CoolDown());

            var euler = transform.eulerAngles;
            euler.z = Random.Range(0, 360);
            BossShootPoint.transform.eulerAngles = euler;
        }
    }

    IEnumerator CoolDown()
    {
        yield return new WaitForSeconds(1);
        inCoolDown = false;
    }
}