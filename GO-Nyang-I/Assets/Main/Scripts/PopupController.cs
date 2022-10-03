using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopupController : MonoBehaviour
{
    public GameObject _storePopup;
    public GameObject _InventoryPopup;

    // Start is called before the first frame update
    void Start()
    {
        _storePopup.SetActive(false);
        _InventoryPopup.SetActive(false);
    }

    public void ExitAllPopup()
    {
        _storePopup.SetActive(false);
        _InventoryPopup.SetActive(false);
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
        _InventoryPopup.SetActive(false);
    }

    public void LoadInventoryPopup()
    {
        _storePopup.SetActive(false);
        _InventoryPopup.SetActive(true);
    }

    public void LoadMakingPopup()
    {

    }
}
