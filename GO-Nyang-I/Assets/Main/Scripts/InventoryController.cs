using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Main.Scripts
{
    public class InventoryController : GameController
    {
        public TMPro.TMP_Text _waterCount;
        public TMPro.TMP_Text _coldBrewCount;
        public TMPro.TMP_Text _coffeeCount;
        public TMPro.TMP_Text _iceteaCount;

        public void Initialize()
        {
            _waterCount.text = _playerData.Water.ToString();
            _coldBrewCount.text = _playerData.Coldbrew.ToString();
            _coffeeCount.text = _playerData.Coffee.ToString();
            _iceteaCount.text = _playerData.Icetea.ToString();
        }
    }

}

