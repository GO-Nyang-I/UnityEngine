using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopupController : MonoBehaviour
{
    public GameObject _storePopup;
    public GameObject _inventoryPopup;
    public GameObject _makingPopup;
    public GameObject _mapPopup;

    // Start is called before the first frame update
    void Start()
    {
        ExitAllPopup();
    }

    public void ExitAllPopup()
    {
        _storePopup.SetActive(false);
        _inventoryPopup.SetActive(false);
        _makingPopup.SetActive(false);
        _mapPopup.SetActive(false);
    }

    public void LoadSettingPopup()
    {

    }

    public void LoadMapPopup()
    {
        _storePopup.SetActive(false);
        _inventoryPopup.SetActive(false);
        _makingPopup.SetActive(false);
        _mapPopup.SetActive(true);
    }

    public void LoadStorePopup()
    {
        _storePopup.SetActive(true);
        _inventoryPopup.SetActive(false);
        _makingPopup.SetActive(false);
        _mapPopup.SetActive(false);
        _storePopup.GetComponent<Assets.Main.Scripts.StoreController>().Initialize();
    }

    public void LoadInventoryPopup()
    {
        _storePopup.SetActive(false);
        _inventoryPopup.SetActive(true);
        _makingPopup.SetActive(false);
        _mapPopup.SetActive(false);
        _inventoryPopup.GetComponent<Assets.Main.Scripts.InventoryController>().Initialize();
    }

    public void LoadMakingPopup()
    {
        _storePopup.SetActive(false);
        _inventoryPopup.SetActive(false);
        _makingPopup.SetActive(true);
        _mapPopup.SetActive(false);
        _makingPopup.GetComponent<Assets.Main.Scripts.MakingController>().Initialize();
    }
}
