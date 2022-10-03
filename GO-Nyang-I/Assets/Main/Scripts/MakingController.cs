using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MakingController : MonoBehaviour
{
    public Button _coffeePlusBtn;
    public Button _coffeeMinusBtn;
    public TMPro.TMP_Text _coffeeCount;

    public Button _makingConfirmBtn;

    // Start is called before the first frame update
    void Start()
    {
        _coffeePlusBtn.onClick.AddListener(OnClickedCoffeePlusBtn);
        _coffeeMinusBtn.onClick.AddListener(OnClickedCoffeeMinusBtn);
        _coffeeCount.text = "0";

        _makingConfirmBtn.onClick.AddListener(OnClickedMakingConfirmBtn);
    }

    void OnClickedCoffeePlusBtn()
    {

    }

    void OnClickedCoffeeMinusBtn()
    {

    }
    
    void OnClickedMakingConfirmBtn()
    {

    }
}
