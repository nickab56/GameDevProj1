using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstPersonMoveNA : MonoBehaviour
{
    // Start is called before the first frame update
    public float walkSpeed = 0.01f;
    public float lookSpeed = 50f;

    // Private Vars
    private float actualSpeed = 0;


    //For Asteroids
    private Vector2 direction;
    public float lerpConstant = 0.1f;


    void Start()
    {
        direction = Vector2.zero;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 inputVelocity = GetInput();
        direction += inputVelocity;
        Vector2.ClampMagnitude(direction, 2);
        direction = Vector2.Lerp(direction, Vector2.zero, lerpConstant); // friciton and motion smoothing
        transform.position += new Vector3(direction.x, direction.y, 0);
    }

    private Vector2 GetInput()
    {
        direction = Vector2.zero;
        actualSpeed = 0;
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            actualSpeed += walkSpeed;
            direction.y = 1;
        }
        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            actualSpeed -= walkSpeed;
            direction.y = -1;
        }
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            direction.x = -1;
        }
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            direction.x = 1;
        }

        actualSpeed = Mathf.Clamp(actualSpeed, -2, 2);
        actualSpeed = Mathf.Lerp(actualSpeed, 0, 0.001f);

        Vector2 tempVelocity = actualSpeed * transform.up * Time.deltaTime;
        return tempVelocity;
    }

}
