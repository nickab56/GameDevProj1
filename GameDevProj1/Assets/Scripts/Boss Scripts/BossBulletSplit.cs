using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBulletSplit : MonoBehaviour
{
    public GameObject SplitBullet;
    public Vector2 direction;
    public float speed = 5f;

    private GameObject Bullet;


    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SplitTime());
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    private void Move()
    {

        Vector2 currentPosition = Camera.main.WorldToScreenPoint(this.transform.position);

        Vector3 newPosition = new Vector3(speed * transform.up.x * Time.deltaTime, speed * transform.up.y * Time.deltaTime, 0);
        this.transform.position += newPosition;
    }

    IEnumerator SplitTime()
    {
        yield return new WaitForSeconds(2);

        Bullet = Instantiate(SplitBullet);
        //Bullet.GetComponent<BossSplitBulletNA>();

        Bullet.transform.position = this.transform.position;
        var euler = transform.eulerAngles;
        euler.z = Bullet.transform.localEulerAngles.z + 25;
        Bullet.transform.eulerAngles = euler;

        var euler2 = transform.eulerAngles;
        euler2.z = this.transform.localEulerAngles.z - 25;
        this.transform.eulerAngles = euler2;
    }


}
