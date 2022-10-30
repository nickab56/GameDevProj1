using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRotateNA : MonoBehaviour
{
    public Vector2 direction;
    public Transform target;

    private float angle;
    private float speed = 5f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // * Use this to have something rotate towards a target. Would be good for the boss.
        //direction = target.position - transform.position;

        direction = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, speed);
    }
}
