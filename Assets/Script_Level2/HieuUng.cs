using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class HieuUng : MonoBehaviour
{
    //public ParticleSystem system;
    //private Transform player; //nhan vat

    void Start()
    {
/*        //Tạo particle system
        var go = new GameObject("Particle System ( Create )");
        // Gán Tọa độ cho đối tượng mới tạo
        go.transform.Rotate(-90, 0, 0);
        // Đưa vào đối tượng Particle System
        system = go.AddComponent<ParticleSystem>();
        //Debug.Log("vao day");
        //MyAsyncMethod(system);

        // Gọi hàm thực hiện . Sau 2 giây nó emit  1 lần ( sinh ra 1 lần )
        InvokeRepeating("startPlay", 2.0f, 2.0f);*/

        //Debug.Log("vao day");
        //player = GameObject.Find("Player").transform;
        //Component g = Instantiate(system, player.transform.position, Quaternion.identity);
        //Destroy(system, 0f);
        //Destroy(g, 0.5f);
    }

/*    void startPlay()
    {
        var emitP = new ParticleSystem.EmitParams();
        emitP.position = Vector3.zero; // tọa độ ban đầu = 0
        emitP.startColor = Color.red;
        emitP.startSize = 0.2f;
        system.Emit(emitP, 10);
        system.Play(); // Thực hiện Emissions    
    }*/

/*    public async Task MyAsyncMethod(ParticleSystem particleSystem)
    {
        await Task.Delay(2000);
        Debug.Log("sau 2 giay");
    }*/

    // Update is called once per frame
    void Update()
    {
        
    }
}
