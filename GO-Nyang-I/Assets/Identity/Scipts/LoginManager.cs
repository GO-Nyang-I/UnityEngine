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
    // Main ȭ�� ��ư
    public Button _loginButton;
    public Button _registButton;

    // Main ȭ�� TextField
    public TMP_InputField _loginUserNameInputField;
    public TMP_InputField _loginPasswordInputField;

    // Popup â
    public GameObject _popupSet;
    public GameObject _signupPopup;
    public GameObject _signupResultPopup;

    // Popup ȭ�� TextField
    public TMP_InputField _resisterUserNameInputField;
    public TMP_InputField _resisterPasswordInputField;

    // Popup ���� ��ư
    public Button _registConfirmButton;

    // Popup �ؽ�Ʈ
    public TMPro.TMP_Text _signupResultCode;

    private IIdentityProvider _identity;

    void Start()
    {
        _identity = GameKitFeature<Identity>.Get();

        _popupSet.SetActive(false);
        _signupResultPopup.SetActive(false);
        _signupPopup.SetActive(false);

        // ���� ȭ���� Login ��ư�� ���� ���
        _loginButton.onClick.AddListener(OnLogin);
        // ���� ȭ���� Signup ��ư�� ���� ���
        _registButton.onClick.AddListener(LoadSignupPopup);
        // SignupPop �� Confirm ��ư�� ���� ���
        _registConfirmButton.onClick.AddListener(OnRegisterUser);
    }

    // ȸ�� ���� �������� ǥ�õǴ� �˾� �ε� �Լ�
    public void LoadSignupPopup ()
    {
        _popupSet.SetActive(true);
        _signupPopup.SetActive(true);
        _signupResultPopup.SetActive(false);
        ClearRegisterUser();
    }

    // ȸ������, �α��� ��� �ڵ� ǥ��
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

    // ȸ������ ��� ǥ��
    void DisplayRegisterResult(uint ResultCode)
    {
        if (ResultCode == GameKitErrors.GAMEKIT_SUCCESS)
        {
            Debug.Log("UserRegistration Success");
            _signupResultCode.text = "ȸ�����Կ� �����߽��ϴ�.";
        }
        else if (ResultCode == GameKitErrors.GAMEKIT_ERROR_MALFORMED_PASSWORD)
        {
            Debug.Log("UserRegistration Fail: GAMEKIT_ERROR_MALFORMED_PASSWORD");
            _signupResultCode.text = "��й�ȣ�� 8�� �̻�\n�Է����ּ���.";
        }
        else if (ResultCode == GameKitErrors.GAMEKIT_ERROR_REGISTER_USER_FAILED)
        {
            Debug.Log("UserRegistration Fail: GAMEKIT_ERROR_MALFORMED_USERNAME");
            _signupResultCode.text = "�̹� ���Ե�\n������Դϴ�.";
        }
        else
        {
            Debug.Log("UserRegistration Fail");
            _signupResultCode.text = "ȸ�����Կ� �����߽��ϴ�.";
        }
        LoadResultCode();
    }

    // �α��� ��� ǥ��
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
            _signupResultCode.text = "���� ������Դϴ�. \n ȸ�������� ���ּ���.";
            ClearLoginUser();
            LoadResultCode();
        }
        else
        {
            Debug.Log("UserLogin Fail");
            _signupResultCode.text = "ȸ������ ���ּ���.";
            ClearLoginUser();
            LoadResultCode();
        }
    }

    // ȸ������
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

    // �α���
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
