using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Main.Scripts
{
    public class MainController : GameController
    {
        public TMPro.TMP_Text _step;
        public TMPro.TMP_Text _star;
        public TMPro.TMP_Text _coin;
        public TMPro.TMP_Text _can;

        [SerializeField] private int StepCount = 0;
        [SerializeField] private int StarCount = 0;
        [SerializeField] private int CoinCount = 0;
        [SerializeField] private int CanCount = 0;

        private void Start()
        {
            _step.text = _playerData.PlayerStep.ToString();
            _star.text = _playerData.PlayerStar.ToString();
            _coin.text = _playerData.PlayerCoin.ToString();
            _can.text = _playerData.PlayerCan.ToString();
        }

        void Update()
        {
            if (StepCount != _playerData.PlayerStep)
            {
                StepCount = _playerData.PlayerStep;
                _step.text = _playerData.PlayerStep.ToString();
            }

            if (StarCount != _playerData.PlayerStar)
            {
                StarCount = _playerData.PlayerStar;
                _star.text = _playerData.PlayerStar.ToString();
            }
            
            if (CoinCount != _playerData.PlayerCoin)
            {
                CoinCount = _playerData.PlayerCoin;
                _coin.text = _playerData.PlayerCoin.ToString();
            }

            if (CanCount != _playerData.PlayerCan)
            {
                CanCount = _playerData.PlayerCan;
                _can.text = _playerData.PlayerCan.ToString();
            }
        }

    }

}
