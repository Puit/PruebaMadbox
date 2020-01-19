using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PikeController : MonoBehaviour
{
    public Transform target;
    public float speed;
    private Vector3 start, end;
    void Start()
    {
        if (target != null)
        {
            target.parent = null;
            start = transform.position;
            end = target.position;
        }
    }
    void Update()
    {
        if (target != null)
        {
            float fixedSpeed = speed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, target.position, fixedSpeed);
            if (target.position.Equals(transform.position))
            {
                target.position = (target.position.Equals(end)) ? start : end;
            }
        }
    }
}