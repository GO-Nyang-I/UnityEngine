using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PopupController : MonoBehaviour
{
    public GameObject _stepPopup;
    public GameObject _storePopup;
    public GameObject _inventoryPopup;
    public GameObject _makingPopup;
    public GameObject _mapPopup;

    public Button _stepPopupExitBtn;

    // Start is called before the first frame update
    void Start()
    {
        _stepPopupExitBtn.onClick.AddListener(OnExchange);
        LoadStepPopup();
    }

    public void ExitAllPopup()
    {
        _stepPopup.SetActive(false);
        _storePopup.SetActive(false);
        _inventoryPopup.SetActive(false);
        _makingPopup.SetActive(false);
        _mapPopup.SetActive(false);
    }

    public void LoadSettingPopup()
    {

    }

    public void LoadStepPopup()
    {
        _stepPopup.SetActive(true);
        _storePopup.SetActive(false);
        _inventoryPopup.SetActive(false);
        _makingPopup.SetActive(false);
        _mapPopup.SetActive(false);
    }

    public void LoadMapPopup()
    {
        _stepPopup.SetActive(false);
        _storePopup.SetActive(false);
        _inventoryPopup.SetActive(false);
        _makingPopup.SetActive(false);
        _mapPopup.SetActive(true);
    }

    public void LoadStorePopup()
    {
        _stepPopup.SetActive(false);
        _storePopup.SetActive(true);
        _inventoryPopup.SetActive(false);
        _makingPopup.SetActive(false);
        _mapPopup.SetActive(false);
        _storePopup.GetComponent<Assets.Main.Scripts.StoreController>().Initialize();
    }

    public void LoadInventoryPopup()
    {
        _stepPopup.SetActive(false);
        _storePopup.SetActive(false);
        _inventoryPopup.SetActive(true);
        _makingPopup.SetActive(false);
        _mapPopup.SetActive(false);
        _inventoryPopup.GetComponent<Assets.Main.Scripts.InventoryController>().Initialize();
    }

    public void LoadMakingPopup()
    {
        _stepPopup.SetActive(false);
        _storePopup.SetActive(false);
        _inventoryPopup.SetActive(false);
        _makingPopup.SetActive(true);
        _mapPopup.SetActive(false);
        _makingPopup.GetComponent<Assets.Main.Scripts.MakingController>().Initialize();
    }

    public void OnExchange()
    {
        _makingPopup.GetComponent<Assets.Main.Scripts.GameController>().Exchange();
    }
}
