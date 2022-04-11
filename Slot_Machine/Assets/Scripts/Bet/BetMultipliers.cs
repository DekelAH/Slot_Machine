using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Bet
{
    public class BetMultipliers : MonoBehaviour
    {
        #region Editor

        [SerializeField]
        private int _betPrice;

        [SerializeField]
        private Text _betPriceText;

        [SerializeField]
        private Text _betMultiplierText;

        [SerializeField]
        private int[] _multipliers;

        #endregion

        #region Fields

        private int _multiplierIndex = 0;

        #endregion

        #region Methods

        private void Start()
        {
            SetupBet();
        }

        public void OnIncreaseBetClicked()
        {
            if (_multipliers == null || _multipliers.Length <= 0)
            {
                return;
            }

            _multiplierIndex++;
            if (_multiplierIndex >= _multipliers.Length)
            {
                _multiplierIndex = 0;
                _betMultiplierText.text = _multipliers[_multiplierIndex].ToString();
            }
            else
            {
                _betMultiplierText.text = _multipliers[_multiplierIndex].ToString();
            }

            SetBetMultiplierPrice();
        }

        public void OnDecreaseBetClicked()
        {
            if (_multipliers == null || _multipliers.Length <= 0)
            {
                return;
            }

            _multiplierIndex--;

            if (_multiplierIndex < 0)
            {
                _multiplierIndex = _multipliers.Length;
                _betMultiplierText.text = _multipliers[_multiplierIndex - 1].ToString();
            }
            else
            {
                _betMultiplierText.text = _multipliers[_multiplierIndex].ToString();
            }

            SetBetMultiplierPrice();
        }

        private void SetBetMultiplierPrice()
        {
            if (_multiplierIndex >= _multipliers.Length)
            {
                _multiplierIndex--;
            }
            _betPriceText.text = (_betPrice * _multipliers[_multiplierIndex]).ToString();
            _betPrice = int.Parse(_betPriceText.text);
        }

        private void SetupBet()
        {
            _betPriceText.text = _betPrice.ToString();
            _betMultiplierText.text = _multipliers[0].ToString();
        }

        #endregion

        #region Properties

        public int BetPrice => _betPrice;

        #endregion
    }
}
