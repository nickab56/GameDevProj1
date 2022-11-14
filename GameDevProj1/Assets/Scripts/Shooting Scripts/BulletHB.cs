using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletHB : MonoBehaviour
{
    //public GameObject Asteroid;
    public GameObject bullet;
    public Vector2 direction;
    public float speed = 20f;

    public ParticleSystem ImpactPS;
    public ParticleSystem BossImpactPS;

    private Vector3 BulletPosition;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        Move();
        BulletPosition = this.transform.position;

    }
    private void Move()
    {

        Vector2 currentPosition = Camera.main.WorldToScreenPoint(this.transform.position);

        Vector3 newPosition = new Vector3(speed * transform.up.x * Time.deltaTime, speed * transform.up.y * Time.deltaTime, 0);
        this.transform.position += newPosition;
    }



    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject gameObject = collision.gameObject;

        if (gameObject.tag == "Boundary")
        {
            //ImpactPS.Play();
            //speed = 0f;
            ImpactPS = Instantiate(ImpactPS);
            ImpactPS.transform.position = BulletPosition;
            var euler = transform.eulerAngles;
            euler.z = bullet.transform.rotation.eulerAngles.z;
            ImpactPS.transform.eulerAngles = euler;
            ImpactPS.Play();
            Destroy(this.gameObject);
        }

        if (gameObject.tag == "TutorialBoundary")
        {
            ImpactPS = Instantiate(ImpactPS);
            ImpactPS.transform.position = BulletPosition;
            var euler = transform.eulerAngles;
            euler.z = bullet.transform.rotation.eulerAngles.z;
            ImpactPS.transform.eulerAngles = euler;
            ImpactPS.Play();
            Destroy(this.gameObject);
            Destroy(gameObject);
        }

        if (gameObject.tag == "Boss")
        {
            BossImpactPS = Instantiate(BossImpactPS);
            BossImpactPS.transform.position = BulletPosition;
            var euler = transform.eulerAngles;
            euler.z = bullet.transform.rotation.eulerAngles.z;
            BossImpactPS.transform.eulerAngles= euler;

            BossImpactPS.main.startRotation.Equals(bullet.transform.rotation);

            BossImpactPS.Play();
            Destroy(this.gameObject);
        }
    }
}
