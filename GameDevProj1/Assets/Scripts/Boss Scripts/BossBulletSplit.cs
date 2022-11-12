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

        Bullet.transform.position = this.transform.position;
        var euler = transform.eulerAngles;
        euler.z = Bullet.transform.localEulerAngles.z + 25;
        Bullet.transform.eulerAngles = euler;

        var euler2 = transform.eulerAngles;
        euler2.z = this.transform.localEulerAngles.z - 25;
        this.transform.eulerAngles = euler2;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject gameObject = collision.gameObject;

        if (gameObject.tag == "Boundary")
        {
            //ImpactPS.Play();
            //speed = 0f;
            Destroy(this.gameObject);
        }

        if (gameObject.tag == "Player")
        {
            //BossImpactPS = Instantiate(BossImpactPS);
            //BossImpactPS.transform.position = BulletPosition;
            //var euler = transform.eulerAngles;
            //euler.z = bullet.transform.rotation.eulerAngles.z;
            //BossImpactPS.transform.eulerAngles = euler;

            //BossImpactPS.main.startRotation.Equals(bullet.transform.rotation);

            //BossImpactPS.Play();
            Destroy(this.gameObject);
            
        }
    }


}
