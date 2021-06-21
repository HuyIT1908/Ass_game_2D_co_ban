using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookWall : MonoBehaviour
{
    public GameObject obstacle_Object;

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            //Debug.Log("di chuyen");
            obstacle_Object.transform.localScale =
                new Vector3(- obstacle_Object.transform.localScale.x,
                obstacle_Object.transform.localScale.y,
                obstacle_Object.transform.localScale.z);
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
