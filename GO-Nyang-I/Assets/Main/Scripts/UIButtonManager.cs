using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIButtonManager : MonoBehaviour
{
    public GameManager _gameManager;
    public GameObject _popupManager;

    public Button _profileBtn;
    public Button _mapBtn;
    public Button _storeBtn;
    public Button _invectoryBtn;
    public Button _bankBtn;
    public Button _questBtn;
    public Button _makingBtn;

    // Start is called before the first frame update
    void Start()
    {
        _profileBtn.onClick.AddListener(OnClickedProfileBtn);
        _mapBtn.onClick.AddListener(OnClickedMapBtn);
        _storeBtn.onClick.AddListener(OnClickedStoreBtn);
        _invectoryBtn.onClick.AddListener(OnClickedInventoryBtn);
        _bankBtn.onClick.AddListener(OnClickedBankBtn);
        _questBtn.onClick.AddListener(OnClickedQuestBtn);
        _makingBtn.onClick.AddListener(OnClickedMakingBtn);
    }

    void OnClickedProfileBtn()
    {

    }

    void OnClickedMapBtn()
    {

    }

    void OnClickedStoreBtn()
    {
        _gameManager.LoadAddictivePopupScene();
        _popupManager.GetComponent<PopupController>().LoadStorePopup();
    }

    void OnClickedInventoryBtn()
    {
        _gameManager.LoadAddictivePopupScene();
        _popupManager.GetComponent<PopupController>().LoadInventoryPopup();
    }

    void OnClickedBankBtn()
    {

    }

    void OnClickedQuestBtn()
    {

    }

    void OnClickedMakingBtn()
    {
        _gameManager.LoadAddictivePopupScene();
        _popupManager.GetComponent<PopupController>().LoadMakingPopup();
    }

    // Update is called once per frame
    void Update()
    {
        if (Application.platform == RuntimePlatform.Android)
        {
            if (Input.GetKey(KeyCode.Escape))
            {
                _popupManager.GetComponent<PopupController>().ExitAllPopup();
                _gameManager.ExitAddictivePopupScene();
            }
        }
    }
}
