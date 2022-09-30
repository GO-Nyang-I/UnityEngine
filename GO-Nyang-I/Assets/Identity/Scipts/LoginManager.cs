using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

using TMPro;

// GameKit
#if UNITY_EDITOR
using AWS.GameKit.Editor.Utils;
#endif

using AWS.GameKit.Common;
using AWS.GameKit.Runtime.Core;
using AWS.GameKit.Runtime.Features.GameKitIdentity;
using AWS.GameKit.Runtime.FeatureUtils;
using AWS.GameKit.Runtime.Models;
using AWS.GameKit.Runtime.Utils;

public class LoginManager : MonoBehaviour
{
    // Main 화면 버튼
    public Button _loginButton;
    public Button _registButton;

    // Main 화면 TextField
    public TMP_InputField _loginUserNameInputField;
    public TMP_InputField _loginPasswordInputField;

    // Popup 창
    public GameObject _popupSet;
    public GameObject _signupPopup;
    public GameObject _existUserPopup;

    // Popup 화면 TextField
    public TMP_InputField _resisterUserNameInputField;
    public TMP_InputField _resisterPasswordInputField;

    // Popup 내부 버튼
    public Button _registConfirmButton;

    private IIdentityProvider _identity;

    void Start()
    {
        _identity = GameKitFeature<Identity>.Get();

        _popupSet.SetActive(false);
        _existUserPopup.SetActive(false);
        _signupPopup.SetActive(false);

        // 메인 화면의 로그인 버튼을 누르면 OnLogin() 호출
        _loginButton.onClick.AddListener(OnLogin);

        _registButton.onClick.AddListener(LoadSignupPopup);
        _registConfirmButton.onClick.AddListener(OnRegisterUser);
    }

    // 이미 같은 id의 사용자가 존재할 때 팝업 로딩 함수
    public void LoadExistUserPopup()
    {
        _popupSet.SetActive(true);
        _existUserPopup.SetActive(true);
        _signupPopup.SetActive(false);
    }

    // 회원 가입 페이지가 표시되는 팝업 로딩 함수
    public void LoadSignupPopup ()
    {
        _popupSet.SetActive(true);
        _signupPopup.SetActive(true);
        _existUserPopup.SetActive(false);
    }

    public void OnRegisterUser()
    {
        UserRegistration userRegistration = new UserRegistration
        {
            UserName = _resisterUserNameInputField.text,    
            Password = _resisterPasswordInputField.text,
            Email = ""
        };

        _identity.Register(userRegistration, (uint resultCode) =>
        {
            Debug.Log($"Identity.Register() completed with result code {GameKitErrorConverter.GetErrorName(resultCode)} ({GameKitErrors.ToString(resultCode)}). This result code is explained in the " +
                      $"Register() method's documentation in the file \"{GameKitPaths.Get().PACKAGES_FULL_PATH}/Runtime/Scripts/Features/Identity/IIdentityProvider.cs\"");

            if (resultCode == GameKitErrors.GAMEKIT_SUCCESS)
            {
                Debug.Log("UserRegistration Success");
            }

        });
    }

    public void OnLogin()
    {
        UserLogin userLoginRequest = new UserLogin()
        {
            UserName = _loginUserNameInputField.text,
            Password = _loginPasswordInputField.text
        };

        _identity.Login(userLoginRequest, (uint resultCode) =>
        {
            Debug.Log($"Identity.Login() completed with result code {GameKitErrorConverter.GetErrorName(resultCode)} ({GameKitErrors.ToString(resultCode)}). This result code is explained in the " +
                      $"Login() method's documentation in the file \"{GameKitPaths.Get().PACKAGES_FULL_PATH}/Runtime/Scripts/Features/Identity/IIdentityProvider.cs\"");

            if (resultCode == GameKitErrors.GAMEKIT_SUCCESS)
            {
                LoadingSceneController.LoadScene("UIScene");
            }
        });
    }

}
