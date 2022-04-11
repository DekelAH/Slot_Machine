using Assets.Models;
using System;
using UnityEngine;
using UnityEngine.UI;

namespace DefaultNamespace.Gameplay.UI
{
    public class CoinsBalanceView : MonoBehaviour
    {
        #region Editor

        [SerializeField]
        private Text _coinsText;

        [SerializeField]
        private PlayerModel _playerModel;

        #endregion

        #region Methods

        private void Start()
        {
            UpdateView();
            _playerModel.CoinsBalanceChanged += OnCoinsBalanceChanged;
        }

        private void Update()
        {
            UpdateView();
        }

        private void OnDestroy()
        {
            _playerModel.CoinsBalanceChanged -= OnCoinsBalanceChanged;
        }

        private void UpdateView()
        {
            _coinsText.text = _playerModel.CoinsBalance.ToString();
        }

        private void OnCoinsBalanceChanged(int arg1, int arg2)
        {
            
        }

        #endregion
    }
}