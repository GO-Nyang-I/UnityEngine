using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : Singleton<GameManager>
{
    protected override void Awake()
    {
        base.Awake();
    }

    private void Start()
    {
        SceneManager.LoadScene("MainScene");
        SceneManager.LoadSceneAsync("PopupScene", LoadSceneMode.Additive);
    }

    public void LoadAddictivePopupScene()
    {
        SceneManager.SetActiveScene(SceneManager.GetSceneByName("PopupScene"));
        Debug.Log("LoadAddictivePopupScene");
        Debug.Log(SceneManager.GetActiveScene());
    }

    public void ExitAddictivePopupScene()
    {
        SceneManager.SetActiveScene(SceneManager.GetSceneByName("MainScene"));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
