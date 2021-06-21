using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveForward : MonoBehaviour
{
    public float speed = 5f;
    private bool canMove = false;

    void Update()
    {
        if ( canMove )
        {
            GetComponent<Rigidbody2D>().velocity = 
                new Vector2( transform.localScale.x , 0 ) * speed ;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        //Debug.Log("di chuyen moveForWard");
        canMove = collision.gameObject.tag == "Ground";

    }

}
