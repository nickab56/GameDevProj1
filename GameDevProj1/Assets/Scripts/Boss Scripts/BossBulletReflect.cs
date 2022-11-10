using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBulletReflect : MonoBehaviour
{
    //public GameObject Asteroid;
    public GameObject bullet;
    public Vector2 direction;
    public float speed = 20f;

    public Transform originalObject;
    public Transform reflectedObject;

    void Start()
    {
        //Destroy(this.gameObject, 5);
    }

    // Update is called once per frame
    void Update()
    {

        Move();

    }
    private void Move()
    {
        //float halfHeight = 60.5f;
        //float halfWidth = 60.5f;
        Vector2 currentPosition = Camera.main.WorldToScreenPoint(this.transform.position);


        Vector3 newPosition = new Vector3(5 * transform.up.x * Time.deltaTime, 5 * transform.up.y * Time.deltaTime, 0);
        this.transform.position += newPosition;
    }



    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject gameObject = collision.gameObject;
        if (gameObject.tag == "Boundary")
        {
        }
        if (gameObject.tag == "BottomWall")
        {
            direction *= new Vector2(1, -1);//-1, 1
        }
        if (gameObject.tag == "RightWall")
        {
            direction *= new Vector2(-1, 1);//1, -1
        }
        if (gameObject.tag == "LeftWall")
        {
            direction *= new Vector2(1, -1);// -1, 1
        }
       // Destroy(this.gameObject);
    }
}
