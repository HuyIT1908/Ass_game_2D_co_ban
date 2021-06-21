using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTheoNV : MonoBehaviour
{
    private Transform player; //nhan vat
    void Start()
    {
        // anh xa nhan vat
        player = GameObject.Find("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (player != null) // co tim thay nhan vat
        {
            // vi tri cam
            Vector3 pos = transform.position;
            pos.x = player.position.x;
            //pos.y = player.position.y;
            // cap nhat vi tri cho cam
            transform.position = pos;
        }
    }
}
