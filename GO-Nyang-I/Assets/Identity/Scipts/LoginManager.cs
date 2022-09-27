using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

using TMPro;

public class LoginManager : MonoBehaviour
{
    public Button LoginButton;

    public TMP_InputField inputId;
    public TMP_InputField inputPw;

    private string id = "id";
    private string pw = "pw";

    void Start()
    {
        LoginButton.onClick.AddListener(LoginButtonClicked);
    }

    void LoginButtonClicked()
    {
        if (inputId.text == id && inputPw.text == pw)
        {
            Debug.Log("�α��� ����");
            LoadingSceneController.LoadScene("UIScene");
        }
        else
        {
            Debug.Log("�α��� ����");
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
