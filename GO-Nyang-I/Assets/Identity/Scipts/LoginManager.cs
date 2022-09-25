using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoginManager : MonoBehaviour
{
    public Button LoginButton;

    void Start()
    {
        LoginButton.onClick.AddListener(LoginButtonClicked);
    }

    void LoginButtonClicked()
    {
        LoadingSceneController.LoadScene("UIScene");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
