using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BossShootHB : MonoBehaviour
{
    public GameObject BossBulletReflect;     //BossBullet   reflections, split, spread
    public GameObject BossShootPoint;
    public float coolDownTime = 1f;
    //public float speed = 5;

    private bool inCoolDown = false;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (!inCoolDown)   //Input.GetKey(KeyCode.Space) (Input.GetMouseButtonDown(0))
        {
            inCoolDown = true;

            GameObject go = Instantiate(BossBulletReflect);   //BossBullets
            //go.transform.SetPositionAndRotation(shootPoint.transform.position, shootPoint.transform.rotation);
            go.transform.position = BossShootPoint.transform.position;
            go.transform.rotation = BossShootPoint.transform.rotation;
            BossBulletReflect b = go.GetComponent<BossBulletReflect>();  //BossBullets
            b.speed = 7;

            StartCoroutine(CoolDown());
        }
    }

    IEnumerator CoolDown()
    {
        yield return new WaitForSeconds(coolDownTime);
        inCoolDown = false;
    }
}

