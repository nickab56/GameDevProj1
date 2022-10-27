using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerMove : MonoBehaviour
{
    public float speed = 10f;
    public Vector2 direction;
    public float halfHeight = 64; //this depends on our texture size
    public float halfWidth = 64; // this depends on your texture size

    private float localSpeed = 0;


    // Start is called before the first frame update
    void Start()
    {
        // direction = new Vector2(1, 0);
    }

    // Update is called once per frame
    void Update()
    {
        move();
    }
    private void move()
    {
        direction = Vector2.zero;

        // stop player at boundary
        bool blockMovingUp = false;
        bool blockMovingDown = false;
        bool blockMovingRight = false;
        bool blockMovingLeft = false;


        Vector2 currentPosition = Camera.main.WorldToScreenPoint(this.transform.position);

        if ((currentPosition.x + halfWidth) > Screen.width)
        {
            blockMovingRight = true;
        }

        if ((currentPosition.y + halfHeight) > Screen.height)
        {
            blockMovingUp = true;
        }

        if ((currentPosition.x - halfWidth) < 0)
        {
            blockMovingLeft = true;
        }

        if ((currentPosition.y - halfHeight) < 0)
        {
            blockMovingDown = true;
        }

        if (Input.GetKey(KeyCode.W) && !blockMovingUp || Input.GetKey(KeyCode.UpArrow))
        {
            direction.y = 1;
            localSpeed += speed;
        }

        if (Input.GetKey(KeyCode.D) && !blockMovingRight || Input.GetKey(KeyCode.LeftArrow))
        {
            direction.x = 1;
            localSpeed += speed;
        }



        if (Input.GetKey(KeyCode.S) && !blockMovingDown || Input.GetKey(KeyCode.DownArrow))
        {
            direction.y = -1;
            localSpeed += speed;
        }

        if (Input.GetKey(KeyCode.A) && !blockMovingLeft || Input.GetKey(KeyCode.RightArrow))
        {
            direction.x = -1;
            localSpeed += speed;
        }

        if (direction != Vector2.zero)
        {
            direction.Normalize();
        }


        Mathf.Clamp(localSpeed, 0, 4);
        localSpeed = Mathf.Lerp(localSpeed, 0, 0.4f);
        Vector3 newPositiion = new Vector3(localSpeed * direction.x * Time.deltaTime, localSpeed * direction.y * Time.deltaTime, 0); // could also use constructor and set each
        this.transform.position += newPositiion;

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject gameObject = collision.gameObject;
        Debug.Log(gameObject.tag);
    }
}

