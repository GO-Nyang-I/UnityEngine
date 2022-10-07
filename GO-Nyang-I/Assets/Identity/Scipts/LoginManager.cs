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
    public GameObject _signupResultPopup;

    // Popup 화면 TextField
    public TMP_InputField _resisterUserNameInputField;
    public TMP_InputField _resisterPasswordInputField;

    // Popup 내부 버튼
    public Button _registConfirmButton;

    // Popup 텍스트
    public TMPro.TMP_Text _signupResultCode;

    private IIdentityProvider _identity;

    void Start()
    {
        _identity = GameKitFeature<Identity>.Get();

        _popupSet.SetActive(false);
        _signupResultPopup.SetActive(false);
        _signupPopup.SetActive(false);

        // 메인 화면의 Login 버튼을 누를 경우
        _loginButton.onClick.AddListener(OnLogin);
        // 메인 화면의 Signup 버튼을 누를 경우
        _registButton.onClick.AddListener(LoadSignupPopup);
        // SignupPop 의 Confirm 버튼을 누를 경우
        _registConfirmButton.onClick.AddListener(OnRegisterUser);
    }

    // 회원 가입 페이지가 표시되는 팝업 로딩 함수
    public void LoadSignupPopup ()
    {
        _popupSet.SetActive(true);
        _signupPopup.SetActive(true);
        _signupResultPopup.SetActive(false);
        ClearRegisterUser();
    }

    // 회원가입, 로그인 결과 코드 표시
    void LoadResultCode()
    {
        _popupSet.SetActive(true);
        _signupPopup.SetActive(false);
        _signupResultPopup.SetActive(true);
    }

    public void ClearRegisterUser()
    {
        _resisterUserNameInputField.text = "";
        _resisterPasswordInputField.text = "";
    }

    public void ClearLoginUser()
    {
        _loginUserNameInputField.text = "";
        _loginPasswordInputField.text = "";
    }

    // 회원가입 결과 표시
    void DisplayRegisterResult(uint ResultCode)
    {
        if (ResultCode == GameKitErrors.GAMEKIT_SUCCESS)
        {
            Debug.Log("UserRegistration Success");
            _signupResultCode.text = "회원가입에 성공했습니다.";
        }
        else if (ResultCode == GameKitErrors.GAMEKIT_ERROR_MALFORMED_PASSWORD)
        {
            Debug.Log("UserRegistration Fail: GAMEKIT_ERROR_MALFORMED_PASSWORD");
            _signupResultCode.text = "비밀번호를 8자 이상\n입력해주세요.";
        }
        else if (ResultCode == GameKitErrors.GAMEKIT_ERROR_REGISTER_USER_FAILED)
        {
            Debug.Log("UserRegistration Fail: GAMEKIT_ERROR_MALFORMED_USERNAME");
            _signupResultCode.text = "이미 가입된\n사용자입니다.";
        }
        else
        {
            Debug.Log("UserRegistration Fail");
            _signupResultCode.text = "회원가입에 실패했습니다.";
        }
        LoadResultCode();
    }

    // 로그인 결과 표시
    void DisplayLoginResult(uint ResultCode)
    {
        if (ResultCode == GameKitErrors.GAMEKIT_SUCCESS)
        {
            Debug.Log("UserLogin Success");
            LoadingSceneController.LoadScene("UIScene");
        }
        else if (ResultCode == GameKitErrors.GAMEKIT_ERROR_LOGIN_FAILED)
        {
            Debug.Log("UserLogin Fail : GAMEKIT_ERROR_LOGIN_FAILED");
            _signupResultCode.text = "없는 사용자입니다. \n 회원가입을 해주세요.";
            ClearLoginUser();
            LoadResultCode();
        }
        else
        {
            Debug.Log("UserLogin Fail");
            _signupResultCode.text = "회원가입 해주세요.";
            ClearLoginUser();
            LoadResultCode();
        }
    }

    // 회원가입
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

            DisplayRegisterResult(resultCode);

        });
    }

    // 로그인
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

            DisplayLoginResult(resultCode);
        });
    }

}
