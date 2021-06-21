using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DieuKhien : MonoBehaviour
{

    public GameObject pauseText;

    public void Exit()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
            Application.Quit();
#endif
    }

    public void ReloadScene()
    {

            Time.timeScale = 1;


            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

    }

    public void pause()
    {
        pauseText.SetActive(true);

        Time.timeScale = 0;
    }

    public void replay()
    {
        pauseText.SetActive(false);

        Time.timeScale = 1;
    }

    public void intro_Welecome()
    {
        SceneManager.LoadScene("IntroScene");
    }
}
