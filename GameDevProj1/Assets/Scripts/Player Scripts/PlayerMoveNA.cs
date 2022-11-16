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
    public float coolDownTime = 6f;
    public GameObject Player;

    private float localSpeed = 0;
    public bool inCoolDown = false;
    public bool walkInCoolDown = false;

    public ParticleSystem walkPS;
    public ParticleSystem dodgePS;


    // Start is called before the first frame update
    void Start()
    {
        //walkPS = GetComponent<ParticleSystem>();
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


        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            direction.y = 1;
            localSpeed += speed;
            WalkEffect();
            //WalkTrail();
        }


        if (Input.GetKey(KeyCode.D)  || Input.GetKey(KeyCode.RightArrow))
        {
            direction.x = 1;
            localSpeed += speed;
            WalkEffect();
            //WalkTrail();
        }



        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            direction.y = -1;
            localSpeed += speed;
            WalkEffect();
            //WalkTrail();
        }

        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            direction.x = -1;
            localSpeed += speed;
            WalkEffect();
           // WalkTrail();
        }

        if (direction != Vector2.zero)
        {
            direction.Normalize();
        }

        if ((Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.A)) || (Input.GetKey(KeyCode.UpArrow) && Input.GetKey(KeyCode.RightArrow)))
        {
            localSpeed *= .75f;
        }

        if ((Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.D)) || (Input.GetKey(KeyCode.UpArrow) && Input.GetKey(KeyCode.LeftArrow)))
        {
            localSpeed *= .75f;
        }

        if ((Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.A)) || (Input.GetKey(KeyCode.DownArrow) && Input.GetKey(KeyCode.LeftArrow)))
        {
            localSpeed *= .75f;
        }

        if ((Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.D)) || (Input.GetKey(KeyCode.DownArrow) && Input.GetKey(KeyCode.RightArrow)))
        {
            localSpeed *= .75f;
        }

        if ((Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.S)) || (Input.GetKey(KeyCode.UpArrow) && Input.GetKey(KeyCode.DownArrow)))
        {
            localSpeed *= .75f;
        }

        if ((Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.D)) || (Input.GetKey(KeyCode.LeftArrow) && Input.GetKey(KeyCode.RightArrow)))
        {
            localSpeed *= .75f;
        }


        Mathf.Clamp(localSpeed, 0, 4);
        localSpeed = Mathf.Lerp(localSpeed, 0, 0.4f);
        Vector3 newPositiion = new Vector3(localSpeed * direction.x * Time.deltaTime, localSpeed * direction.y * Time.deltaTime, 0); // could also use constructor and set each
        this.transform.position += newPositiion;

    }

    
    private void dodge()
    {
        if ((Input.GetKeyDown(KeyCode.LeftShift) || Input.GetKeyDown(KeyCode.RightShift)) && !inCoolDown)
        {
            if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
            {
                inCoolDown = true;
                StartCoroutine(DoDodge());
            }
               

            if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
            {
                inCoolDown = true;
                StartCoroutine(DoDodge());
            }
                

            if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
            {
                inCoolDown = true;
                StartCoroutine(DoDodge());
            }


            if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
            {
                inCoolDown = true;
                StartCoroutine(DoDodge());
            }

        }
    }

    IEnumerator CoolDown()
    {
        yield return new WaitForSeconds(1.5f);
        inCoolDown = false;

    }
    
    IEnumerator DoDodge()
    {
        StartCoroutine(CoolDown());
        speed += 8f;
        dodgePS.Play();
        yield return new WaitForSeconds(0.5f);
        speed -= 8f;
        //dodgePS.Stop();
    }

    void WalkTrail()
    {
        walkPS.Play();
    }

    IEnumerator WalkCoolDown()
    {
        yield return new WaitForSeconds(0.75f);
        walkInCoolDown = false;

    }


    void WalkEffect()
    {
        if (!walkInCoolDown)
        {
            walkInCoolDown = true;
            walkPS.Play();
            StartCoroutine(WalkCoolDown());
        }

    }

}

