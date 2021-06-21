using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{


    public void Load_Scene()
    {
        //Application.LoadLevel("Level1");
        SceneManager.LoadScene("Level1");
    }

}
