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
    public Button LoginButton;
    public Button RegistrationButton;

    private IIdentityProvider _identity;

    public TMP_InputField _userNameInputField;
    public TMP_InputField _passwordInputField;
    
    void Start()
    {
        _identity = GameKitFeature<Identity>.Get();

        LoginButton.onClick.AddListener(OnLogin);
        RegistrationButton.onClick.AddListener(OnRegisterUser);
    }

    public void OnRegisterUser()
    {
        UserRegistration userRegistration = new UserRegistration
        {
            UserName = _userNameInputField.text,    
            Password = _passwordInputField.text,
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
            UserName = _userNameInputField.text,
            Password = _passwordInputField.text
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
