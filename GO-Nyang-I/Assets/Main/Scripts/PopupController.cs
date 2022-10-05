using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopupController : MonoBehaviour
{
    public GameObject _storePopup;
    public GameObject _inventoryPopup;
    public GameObject _makingPopup;

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
    }

    public void LoadSettingPopup()
    {

    }

    public void LoadMapPopup()
    {

    }

    public void LoadStorePopup()
    {
        _storePopup.SetActive(true);
        _inventoryPopup.SetActive(false);
        _makingPopup.SetActive(false);
        _storePopup.GetComponent<Assets.Main.Scripts.StoreController>().Initialize();
    }

    public void LoadInventoryPopup()
    {
        _storePopup.SetActive(false);
        _inventoryPopup.SetActive(true);
        _makingPopup.SetActive(false);
    }

    public void LoadMakingPopup()
    {
        _storePopup.SetActive(false);
        _inventoryPopup.SetActive(false);
        _makingPopup.SetActive(true);
    }
}
