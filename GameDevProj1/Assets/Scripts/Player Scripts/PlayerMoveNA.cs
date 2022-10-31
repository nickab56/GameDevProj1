using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerMoveNA : MonoBehaviour
{
    public float speed = 6f;
        public Vector2 direction;
    public float halfHeight = 64; //this depends on our texture size
    public float halfWidth = 64; // this depends on your texture size
    public float coolDownTime = 0.1f;
    public GameObject Player;

    private float localSpeed = 0;
    private bool inCoolDown = false;

    // stop player at boundary
    public bool blockMovingUp = false;
    public bool blockMovingDown = false;
    public bool blockMovingRight = false;
    public bool blockMovingLeft = false;

    // Start is called before the first frame update
    void Start()
    {
        // direction = new Vector2(1, 0);
    }

    // Update is called once per frame
    void Update()
    {
        move();
        dodge();
    }
    private void move()
    {
        direction = Vector2.zero;

        

        Vector2 currentPosition = Camera.main.WorldToScreenPoint(this.transform.position);

        //if ((currentPosition.x + halfWidth) > Screen.width)
        //{
        //    blockMovingRight = true;
        //}

        //if ((currentPosition.y + halfHeight) > Screen.height)
        //{
        //    blockMovingUp = true;
        //}

        //if ((currentPosition.x - halfWidth) < 0)
        //{
        //    blockMovingLeft = true;
        //}

        //if ((currentPosition.y - halfHeight) < 0)
        //{
        //    blockMovingDown = true;
        //}

        if (Input.GetKey(KeyCode.W) && !blockMovingUp || Input.GetKey(KeyCode.UpArrow))
        {
            direction.y = 1;
            localSpeed += speed;
            blockMovingDown = false;
        }

        if (Input.GetKey(KeyCode.D) && !blockMovingRight || Input.GetKey(KeyCode.RightArrow))
        {
            direction.x = 1;
            localSpeed += speed;
            blockMovingLeft = false;
        }



        if (Input.GetKey(KeyCode.S) && !blockMovingDown || Input.GetKey(KeyCode.DownArrow))
        {
            direction.y = -1;
            localSpeed += speed;
            blockMovingUp = false;
        }

        if (Input.GetKey(KeyCode.A) && !blockMovingLeft || Input.GetKey(KeyCode.LeftArrow))
        {
            direction.x = -1;
            localSpeed += speed;
            blockMovingRight = false;
        }

        if (direction != Vector2.zero)
        {
            direction.Normalize();
        }

        if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.A))
        {
            localSpeed *= .75f;
        }

        if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.D))
        {
            localSpeed *= .75f;
        }

        if (Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.A))
        {
            localSpeed *= .75f;
        }

        if (Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.D))
        {
            localSpeed *= .75f;
        }


        Mathf.Clamp(localSpeed, 0, 4);
        localSpeed = Mathf.Lerp(localSpeed, 0, 0.4f);
        Vector3 newPositiion = new Vector3(localSpeed * direction.x * Time.deltaTime, localSpeed * direction.y * Time.deltaTime, 0); // could also use constructor and set each
        this.transform.position += newPositiion;

        /*blockMovingUp = false;
        blockMovingLeft = false;
        blockMovingDown = false;
        blockMovingRight = false;*/

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject gameObject = collision.gameObject;
        Debug.Log(gameObject.tag);
        if (gameObject.tag == "Boundary")
        {
            if(collision.transform.position.x < this.transform.position.x)
            {
                blockMovingLeft = true;
            }
            if (collision.transform.position.x > this.transform.position.x)
            {
                blockMovingRight = true;
            }
            if (collision.transform.position.y < this.transform.position.y)
            {
                blockMovingDown = true;
            }
            if (collision.transform.position.y > this.transform.position.y)
            {
                blockMovingUp = true;
            }
        }
    }
    
    private void dodge()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            if (Input.GetKey(KeyCode.D))
            Player.transform.position = new Vector3(Player.transform.position.x + 3f, Player.transform.position.y);

            if (Input.GetKey(KeyCode.A))
                Player.transform.position = new Vector3(Player.transform.position.x + -3f, Player.transform.position.y);

            if (Input.GetKey(KeyCode.W))
                Player.transform.position = new Vector3(Player.transform.position.x, Player.transform.position.y + 3f);

            if (Input.GetKey(KeyCode.S))
                Player.transform.position = new Vector3(Player.transform.position.x, Player.transform.position.y + -3f);

        }
        StartCoroutine(CoolDown());
    }

    IEnumerator CoolDown()
    {
        yield return new WaitForSeconds(coolDownTime);
        inCoolDown = false;

    }
    
    IEnumerator DoDodge()
    {
        direction.x += 0.25f;
        yield return new WaitForSeconds(0.5f);
    }

}

