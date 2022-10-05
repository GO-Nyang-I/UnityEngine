using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Main.Scripts
{
    public class MakingController : GameController
    {
        // 커피
        public TMPro.TMP_Text _coffeeCount;
        public Button _coffeePlusBtn;
        public Button _coffeeMinusBtn;

        // 만들기
        public Button _makingConfirmBtn;

        [SerializeField] private int CoffeeCount = 0;
        [SerializeField] private int TotalPrice  = 0;

        [SerializeField] private const int CoffeePrice = 30;

        // Start is called before the first frame update
        void Start()
        {
            _coffeePlusBtn.onClick.AddListener(OnClickedCoffeePlusBtn);
            _coffeeMinusBtn.onClick.AddListener(OnClickedCoffeeMinusBtn);
            _makingConfirmBtn.onClick.AddListener(OnClickedMakingConfirmBtn);
        }

        void OnClickedCoffeePlusBtn()
        {
            if (CoffeeCount < 10)
            {
                CoffeeCount++;
                TotalPrice += CoffeePrice;
            }
            _coffeeCount.text = CoffeeCount.ToString();
        }

        void OnClickedCoffeeMinusBtn()
        {
            if (CoffeeCount > 0)
            {
                CoffeeCount--;
                TotalPrice -= CoffeePrice;
            }
            _coffeeCount.text = CoffeeCount.ToString();
        }

        void OnClickedMakingConfirmBtn()
        {
            //BuyCoffee(CoffeeCount, CoffeeCount, CoffeeCount);
        }

    }
}