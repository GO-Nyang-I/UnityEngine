using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Main.Scripts
{
    public class StoreController : GameController
    {
        // 생수
        public TMPro.TMP_Text _waterCount;
        public Button _waterPlusBtn;
        public Button _waterMinusBtn;

        // 커피 원액
        public TMPro.TMP_Text _coldbrewCount;
        public Button _coldbrewPlusBtn;
        public Button _coldbrewMinusBtn;

        // 냥톤
        public TMPro.TMP_Text _liptonCount;
        public Button _liptonPlusBtn;
        public Button _liptonMinusBtn;

        // 구입
        public TMPro.TMP_Text _coinTotal;    // 합계 금액
        public Button _buyBtn;               // 구입

        [SerializeField] private int WaterCount = 0;
        [SerializeField] private int ColdbrewCount = 0;
        [SerializeField] private int LiptonCount = 0;
        [SerializeField] private int TotalCoin = 0;

        [SerializeField] private const int WaterPrice = 10;
        [SerializeField] private const int ColdbrewPrice = 10;
        [SerializeField] private const int LiptonPrice = 5;

        void Start()
        {
            _waterPlusBtn.onClick.AddListener(OnPlusWaterCount);
            _waterMinusBtn.onClick.AddListener(OnMinusWaterCount);
            _coldbrewPlusBtn.onClick.AddListener(OnPlusColdbrewCount);
            _coldbrewMinusBtn.onClick.AddListener(OnMinusColdbrewCount);
            _liptonPlusBtn.onClick.AddListener(OnPlusLiptonCount);
            _liptonMinusBtn.onClick.AddListener(OnMinusLiptonCount);
            _buyBtn.onClick.AddListener(OnBuyIngredients);
        }

        public void Initialize()
        {
            WaterCount = 0;
            ColdbrewCount = 0;
            LiptonCount = 0;
            TotalCoin = 0;
            _waterCount.text = WaterCount.ToString();
            _coldbrewCount.text = ColdbrewCount.ToString();
            _liptonCount.text = LiptonCount.ToString();
            _coinTotal.text = TotalCoin.ToString();
        }

        void OnPlusWaterCount()
        {
            if (WaterCount < 10)
            {
                WaterCount++;
                TotalCoin += WaterPrice;
            }
            _waterCount.text = WaterCount.ToString();
            _coinTotal.text = TotalCoin.ToString();
        }

        void OnMinusWaterCount()
        {
            if (WaterCount > 0)
            {
                WaterCount--;
                TotalCoin -= WaterPrice;
            }
            _waterCount.text = WaterCount.ToString();
            _coinTotal.text = TotalCoin.ToString();
        }

        void OnPlusColdbrewCount()
        {
            if (ColdbrewCount < 10)
            {
                ColdbrewCount++;
                TotalCoin += ColdbrewPrice;
            }
            _coldbrewCount.text = ColdbrewCount.ToString();
            _coinTotal.text = TotalCoin.ToString();
        }

        void OnMinusColdbrewCount()
        {
            if (ColdbrewCount > 0)
            {
                ColdbrewCount--;
                TotalCoin -= ColdbrewPrice;
            }
            _coldbrewCount.text = ColdbrewCount.ToString();
            _coinTotal.text = TotalCoin.ToString();
        }

        void OnPlusLiptonCount()
        {
            if (LiptonCount < 10)
            {
                LiptonCount++;
                TotalCoin += LiptonPrice;
            }
            _liptonCount.text = LiptonCount.ToString();
            _coinTotal.text = TotalCoin.ToString();
        }

        void OnMinusLiptonCount()
        {
            if (LiptonCount > 0)
            {
                LiptonCount--;
                TotalCoin -= LiptonPrice;
            }
            _liptonCount.text = LiptonCount.ToString();
            _coinTotal.text = TotalCoin.ToString();
        }

        void OnBuyIngredients()
        {
            _playerData.PlayerCoin -= TotalCoin;
            _playerData.Water += WaterCount;
            _playerData.Coldbrew += ColdbrewCount;
            _playerData.Lipton += LiptonCount;
        }

    }
}
