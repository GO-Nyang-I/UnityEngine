using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// GameKit
using AWS.GameKit.Runtime.Core;
using AWS.GameKit.Runtime.Features.GameKitUserGameplayData;
using AWS.GameKit.Runtime.Utils;

namespace Assets.Main.Scripts
{
    public class MakingController : GameController
    {
        // 커피
        public TMPro.TMP_Text _coffeeCount;
        public TMPro.TMP_Text _coffeeRecipeWater;
        public TMPro.TMP_Text _coffeeRecipeColdbrew;
        public Button _coffeePlusBtn;
        public Button _coffeeMinusBtn;

        // 아이스티
        public TMPro.TMP_Text _iceteaCount;
        public TMPro.TMP_Text _iceteaRecipeWater;
        public TMPro.TMP_Text _iceteaRecipeLipton;
        public Button _iceteaPlusBtn;
        public Button _iceteaMinusBtn;

        // 만들기
        public Button _makingConfirmBtn;

        [SerializeField] private int CoffeeCount = 0;
        [SerializeField] private int IceteaCount = 0;
        [SerializeField] private int TotalPrice  = 0;

        [SerializeField] private const int CoffeePrice = 30;
        [SerializeField] private const int IceteaPrice = 20;

        [SerializeField] private const string RedColorCode = "#FF5733";
        [SerializeField] private const string BlackColorCode = "#5E6164";
        Color RedColor;
        Color BlackColor;

        // Start is called before the first frame update
        void Start()
        {
            _coffeePlusBtn.onClick.AddListener(OnClickedCoffeePlusBtn);
            _coffeeMinusBtn.onClick.AddListener(OnClickedCoffeeMinusBtn);
            _iceteaPlusBtn.onClick.AddListener(OnClickedIceteaPlusBtn);
            _iceteaMinusBtn.onClick.AddListener(OnClickedIceteaMinusBtn);
            _makingConfirmBtn.onClick.AddListener(OnClickedMakingConfirmBtn);
        }

        public void Initialize()
        {
            CoffeeCount = 0;
            IceteaCount = 0;
            TotalPrice = 0;
            _coffeeCount.text = CoffeeCount.ToString();
            _iceteaCount.text = IceteaCount.ToString();
        }

        void OnClickedCoffeePlusBtn()
        {
            if (CoffeeCount < 10)
            {
                CoffeeCount++;
                TotalPrice += CoffeePrice;
                                
                if (_playerData.Coldbrew < CoffeeCount)
                {
                    if (ColorUtility.TryParseHtmlString(RedColorCode, out RedColor))
                    {
                        _coffeeRecipeColdbrew.color = RedColor;
                    }
                }

                if (_playerData.Water < CoffeeCount)
                {
                    if (ColorUtility.TryParseHtmlString(RedColorCode, out RedColor))
                    {
                        _coffeeRecipeWater.color = RedColor;
                    }
                }
            }
            _coffeeCount.text = CoffeeCount.ToString();
        }

        void OnClickedCoffeeMinusBtn()
        {
            if (CoffeeCount > 0)
            {
                CoffeeCount--;
                TotalPrice -= CoffeePrice;

                if (_playerData.Coldbrew >= CoffeeCount)
                {
                    if (ColorUtility.TryParseHtmlString(BlackColorCode, out BlackColor))
                    {
                        _coffeeRecipeColdbrew.color = BlackColor;
                    }
                }

                if (_playerData.Water >= CoffeeCount)
                {
                    if (ColorUtility.TryParseHtmlString(BlackColorCode, out BlackColor))
                    {
                        _coffeeRecipeWater.color = BlackColor;
                    }
                }
            }
            _coffeeCount.text = CoffeeCount.ToString();
        }

        void OnClickedIceteaPlusBtn()
        {
            if (IceteaCount < 10)
            {
                IceteaCount++;
                TotalPrice += IceteaPrice;

                if (_playerData.Lipton < (IceteaCount*2))
                {
                    if (ColorUtility.TryParseHtmlString(RedColorCode, out RedColor))
                    {
                        _iceteaRecipeLipton.color = RedColor;
                    }
                }

                if (_playerData.Water < IceteaCount)
                {
                    if (ColorUtility.TryParseHtmlString(RedColorCode, out RedColor))
                    {
                        _iceteaRecipeWater.color = RedColor;
                    }
                }
            }
            _iceteaCount.text = IceteaCount.ToString();
        }

        void OnClickedIceteaMinusBtn()
        {
            if (IceteaCount > 0)
            {
                IceteaCount--;
                TotalPrice -= IceteaPrice;

                if (_playerData.Lipton >= (IceteaCount*2))
                {
                    if (ColorUtility.TryParseHtmlString(BlackColorCode, out BlackColor))
                    {
                        _iceteaRecipeLipton.color = BlackColor;
                    }
                }

                if (_playerData.Water >= IceteaCount)
                {
                    if (ColorUtility.TryParseHtmlString(BlackColorCode, out BlackColor))
                    {
                        _iceteaRecipeWater.color = BlackColor;
                    }
                }
            }
            _iceteaCount.text = IceteaCount.ToString();
        }

        void OnClickedMakingConfirmBtn()
        {
            _playerData.Coffee += CoffeeCount;
            _playerData.Water -= CoffeeCount;
            _playerData.Coldbrew -= CoffeeCount;

            _playerData.Icetea += IceteaCount;
            _playerData.Water -= IceteaCount;
            _playerData.Lipton -= (IceteaCount*2);

            _playerData.PlayerCan += TotalPrice;
            _playerData.PlayerStar += (_playerData.Coffee * MakingExp + _playerData.Icetea * MakingExp);
        }

    }
}