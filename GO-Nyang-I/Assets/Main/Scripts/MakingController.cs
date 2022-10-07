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
        public Button _coffeePlusBtn;
        public Button _coffeeMinusBtn;

        // 아이스티
        public TMPro.TMP_Text _iceteaCount;
        public Button _iceteaPlusBtn;
        public Button _iceteaMinusBtn;

        // 만들기
        public Button _makingConfirmBtn;

        [SerializeField] private int CoffeeCount = 0;
        [SerializeField] private int IceteaCount = 0;
        [SerializeField] private int TotalPrice  = 0;

        [SerializeField] private const int CoffeePrice = 30;
        [SerializeField] private const int IceteaPrice = 20;

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

        void OnClickedIceteaPlusBtn()
        {
            if (IceteaCount < 10)
            {
                IceteaCount++;
                TotalPrice += IceteaPrice;
            }
            _iceteaCount.text = IceteaCount.ToString();
        }

        void OnClickedIceteaMinusBtn()
        {
            if (IceteaCount > 0)
            {
                IceteaCount--;
                TotalPrice -= IceteaPrice;
            }
            _iceteaCount.text = IceteaCount.ToString();
        }

        void OnClickedMakingConfirmBtn()
        {
            _playerData.Coffee += CoffeeCount;
            _playerData.Icetea += IceteaCount;
            _playerData.PlayerCan += TotalPrice;

            UserGameplayDataBundleItemValue itemChange = new UserGameplayDataBundleItemValue
            {
                BundleName = PLAYER_DATA_BUNDLE_NAME,
                BundleItemKey = ITEM_DATA_JSON_BUNDLE_NAME,
                BundleItemValue = JsonUtility.ToJson(_playerData)
            };

            _userGameplayData.UpdateItem(itemChange, result =>
            {
                if (result != GameKitErrors.GAMEKIT_SUCCESS)
                {
                    Debug.LogError(
                        $"Could not update the {PLAYER_DATA_BUNDLE_NAME} bundle with bundle item {ITEM_DATA_JSON_BUNDLE_NAME}: " +
                        $"{GameKitErrorConverter.GetErrorName(result)}.");
                }

                Debug.Log($"Update player highscore bundles.");
            });
        }

    }
}