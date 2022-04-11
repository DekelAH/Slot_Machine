using Assets.Models;
using Assets.Scripts.Bet;
using Assets.Scripts.SlotMachineScripts;
using UnityEngine;

namespace Assets.Scripts.Gameplay
{
    public class GameManager : MonoBehaviour
    {
        #region Editor

        [SerializeField]
        private SlotMachine _slotMachine;

        [SerializeField]
        private LevelPaytable _paytable;

        [SerializeField]
        private PlayerModel _playerModel;

        [SerializeField]
        private BetMultipliers _betMultiplier;

        #endregion

        #region Methods

        public void OnSpinButtonClick()
        {
            if (_slotMachine.IsAnyReelSpinning)
            {
                return;
            }

            if (_playerModel.CoinsBalance >= _betMultiplier.BetPrice)
            {
                _playerModel.WithdrawCoins(_betMultiplier.BetPrice);
                _slotMachine.SpinSlotMachine(OnStartSpin, OnEndSpin);
            }
            else
            {
                Debug.Log("Not Enough Coins..");
            }
        }

        private void OnEndSpin(SpinResult spinResult)
        {
            var winPrice = _paytable.GetWinBySlotIndex(spinResult.First)
                           + _paytable.GetWinBySlotIndex(spinResult.Second)
                           + _paytable.GetWinBySlotIndex(spinResult.Third);

            _playerModel.AddCoins(winPrice);
        }

        private void OnStartSpin()
        {

        }

        #endregion

    }
}
