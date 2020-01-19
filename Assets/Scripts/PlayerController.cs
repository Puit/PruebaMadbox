using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Animator animator;
    //public bool fingerDown = false;
    Follower follower;
    public GameObject player;
    Vector3 startPosition;

    private void Start()
    {
        follower = GetComponentInParent<Follower>();
        startPosition = transform.position;
    }
    private void Update()
    {
        //If mouse is down
        if (Input.GetMouseButtonDown(0))
        {
            //fingerDown = true;
            follower.move = true;
            animator.SetBool("Run", true);
        }

        //If mouse is up
        if (Input.GetMouseButtonUp(0))
        {
            //fingerDown = false;
            follower.move = false;
            animator.SetBool("Run", false);
        }

    }
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("OnCollisionEnter");
        Debug.Log(collision.transform.name);
        Debug.Log(collision.transform.tag);
        if (collision.transform.tag.Equals("Enemy"))
            StartCoroutine(Death());
    }
    IEnumerator Death()
    {
        animator.SetTrigger("Jump");
        yield return new WaitForSeconds(1);
        player = Instantiate(player, startPosition, Quaternion.identity) as GameObject;
        Destroy(gameObject);
    }
}
