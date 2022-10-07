using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadingSceneController : MonoBehaviour
{
    static string nextScene;

    private float time;

    public static void LoadScene(string sceneName)
    {
        nextScene = sceneName;
        SceneManager.LoadScene("LoadingScene");
    }

    private void Update()
    {
        time += Time.deltaTime;

        if(time > 5.0f)
        {
            SceneManager.LoadScene(nextScene);
        }
    }
}
