using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BossShootHB : MonoBehaviour
{
    public GameObject BulletSplit;     //BossBullet   reflections, split, spread
    public GameObject BossShootPoint;
   
    //public float speed = 5;

    private bool inCoolDown = false;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (inCoolDown == false)
        {

            inCoolDown = false;
            GameObject go = Instantiate(BulletSplit);
            //go.transform.SetPositionAndRotation(shootPoint.transform.position, shootPoint.transform.rotation);
            go.transform.position = BossShootPoint.transform.position;
            go.transform.rotation = BossShootPoint.transform.rotation;
            BossBulletSplit b = go.GetComponent<BossBulletSplit>();
            b.speed = 5;

            StartCoroutine(CoolDown());

            var euler = transform.eulerAngles;
            euler.z = Random.Range(0, 360);
            BossShootPoint.transform.eulerAngles = euler;
        }
    }

    IEnumerator CoolDown()
    {
        yield return new WaitForSeconds(2);
        inCoolDown = false;
    }
}