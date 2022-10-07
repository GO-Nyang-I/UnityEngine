// Standard Library
using System.Collections.Generic;
using System.Linq;

// GameKit
using AWS.GameKit.Runtime.Core;
using AWS.GameKit.Runtime.Features.GameKitUserGameplayData;
using AWS.GameKit.Runtime.FeatureUtils;
using AWS.GameKit.Runtime.Models;
using AWS.GameKit.Runtime.Utils;

// Unity
using UnityEngine;
using UnityEngine.Events;

namespace Assets.Main.Scripts
{
    public class GameController : MonoBehaviour
    {
        protected const string PLAYER_DATA_BUNDLE_NAME = "PlayerData";
        protected const string ITEM_DATA_JSON_BUNDLE_NAME = "ItemDataJson";

        // Dependencies 
        protected static IUserGameplayDataProvider _userGameplayData;

        protected static GameData.PlayerData _playerData;

        private int QuitEscape = 0;

        [SerializeField] private const int CoffeeExp = 3;
        [SerializeField] private const int IceteaExp = 5;

        void Start()
        {
            _playerData = new GameData.PlayerData();

            _userGameplayData = GameKitFeature<UserGameplayData>.Get();

            _userGameplayData.TryForceSynchronizeAndExecute(
               CreatePlayerDataBundle,
               () =>
               {
                   // Non-recoverable error. Here you should display an error message informing the player that it isn't possible to continue.
                   Debug.LogError("Attempt to sync gameplay data failed.");
               });
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                QuitEscape++;
                if (!IsInvoking("DoubleClick"))
                    Invoke("DoubleClick", 1.0f);
            }
            else if (QuitEscape == 2)
            {
                GameExit();
                CancelInvoke("DoubleClick");
                Application.Quit();
            }
        }

        void DoubleClick()
        {
            QuitEscape = 0;
        }

        private void CreatePlayerDataBundle()
        {
            // List all bundles, create highscore bundle if it doesn't exist
            _userGameplayData.ListBundles((result =>
            {
                if (result.ResultCode != GameKitErrors.GAMEKIT_SUCCESS)
                {
                    Debug.LogError($"Could not retrieve stored user gameplay data bundles: {GameKitErrorConverter.GetErrorName(result.ResultCode)}");
                }
                else
                {
                    if (!result.ResponseValues.Contains(PLAYER_DATA_BUNDLE_NAME))
                    {
                        CreateDefaultPlayerData();
                    }
                    else
                    {
                        RetrievePlayerData();
                    }
                }
            }));
        }

        private void CreateDefaultPlayerData()
        {
            Dictionary<string, string> scoresDictionary = new Dictionary<string, string>()
            {
                { ITEM_DATA_JSON_BUNDLE_NAME, JsonUtility.ToJson(_playerData) }
            };

            AddUserGameplayDataDesc addUserGameplayData = new AddUserGameplayDataDesc
            {
                BundleName = PLAYER_DATA_BUNDLE_NAME,
                BundleItems = scoresDictionary
            };

            _userGameplayData.AddBundle(addUserGameplayData, (AddUserGameplayDataResults result) =>
            {
                if (result.ResultCode == GameKitErrors.GAMEKIT_SUCCESS)
                {
                    Debug.Log("Successfully create default player highscores");
                    return;
                }

                Debug.LogError($"Creating player's highscore bundle failed: {GameKitErrorConverter.GetErrorName(result.ResultCode)}");

                if (result.BundleItems.Count <= 0)
                {
                    return;
                }

                foreach (KeyValuePair<string, string> bundleItem in result.BundleItems)
                {
                    Debug.LogError($"Failed to process highscores - [{ bundleItem.Key}, { bundleItem.Value}]");
                }
            });
        }

        private void RetrievePlayerData()
        {
            UserGameplayDataBundleItem userGameplayDayaBundleItem = new UserGameplayDataBundleItem
            {
                BundleName = PLAYER_DATA_BUNDLE_NAME,
                BundleItemKey = ITEM_DATA_JSON_BUNDLE_NAME
            };

            _userGameplayData.GetBundleItem(userGameplayDayaBundleItem, (StringCallbackResult result) =>
            {
                if (result.ResultCode != GameKitErrors.GAMEKIT_SUCCESS)
                {
                    Debug.LogError($"Could not retrieve player high scores: {GameKitErrorConverter.GetErrorName(result.ResultCode)}.");
                    return;
                }

                _playerData = JsonUtility.FromJson<GameData.PlayerData>(result.ResponseValue);
            });
        }

        public void GameExit()
        {
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

        public void Buy(int DrinkId)
        {
            if (DrinkId == 0)
            {
                if (_playerData.Coffee > 0)
                {
                    _playerData.Coffee--;
                    _playerData.PlayerStar += (_playerData.Coffee * CoffeeExp);
                }
            }
            else if (DrinkId == 1)
            {
                if (_playerData.Icetea > 0)
                {
                    _playerData.Icetea--;
                    _playerData.PlayerStar += (_playerData.Icetea * IceteaExp);
                }
            }
        }

        public void Exchange()
        {
            _playerData.PlayerCoin += (_playerData.PlayerStep / 10);
        }
    }
        
}

