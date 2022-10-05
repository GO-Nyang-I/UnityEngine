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

namespace Assets.GameData
{
    public class PlayerData
    {
        public int PlayerStep;
        public int PlayerStar;
        public int PlayerCoin;
        public int PlayerCan;

        public Dictionary<string, int> ItemList;

        public PlayerData()
        {
            ItemList = new Dictionary<string, int>();
        }

        public void ClearAllData()
        {
            PlayerStep = 0;
            PlayerStar = 0;
            PlayerCoin = 0;
            PlayerCan = 0;

            ItemList = new Dictionary<string, int>();
        }

        public bool UpdatePlayerData(int Step, int Star, int Coin, int Can)
        {
            PlayerStep = Step;
            PlayerStar = Star;
            PlayerCoin = Coin;
            PlayerCan = Can;

            return true;
        }
    }
}
