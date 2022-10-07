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

        public int Water;
        public int Coldbrew;
        public int Lipton;
        public int Coffee;
        public int Icetea;

        public PlayerData()
        {

        }

        public void ClearAllData()
        {
            PlayerStep = 0;
            PlayerStar = 0;
            PlayerCoin = 0;
            PlayerCan = 0;

            Water = 0;
            Coldbrew = 0;
            Lipton = 0;
            Coffee = 0;
            Icetea = 0;
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
