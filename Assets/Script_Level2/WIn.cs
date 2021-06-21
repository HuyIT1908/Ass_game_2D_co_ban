using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WIn : MonoBehaviour
{
    public float delaySecond = 2;
    public string nameScene = "Win";

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(LoadAfterDelay());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //public async Task MyAsyncMethod()
    //{
    //    await Task.Delay(3000);
    //    //SceneManager.LoadScene("IntroScene");
    //}

    IEnumerator LoadAfterDelay()
    {
        yield return new WaitForSeconds(delaySecond);

        SceneManager.LoadScene(nameScene);
    }

}
