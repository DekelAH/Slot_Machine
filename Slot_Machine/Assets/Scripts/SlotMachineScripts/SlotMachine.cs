using Assets.Scripts.SlotMachineScripts;
using System;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Assets.Scripts.SlotMachineScripts
{
    public class SlotMachine : MonoBehaviour
    {
        #region Editor

        [SerializeField]
        private SlotMachineReel[] _reels;

        #endregion

        #region Fields

        private Action<SpinResult> _endSpinCallback;

        private SpinResult _spinResult;

        #endregion

        #region Methods

        public void SpinSlotMachine(Action startSpinCallback, Action<SpinResult> endSpinCallback)
        {
            _endSpinCallback = endSpinCallback;
            startSpinCallback?.Invoke();
            _spinResult = ResultGenerator.GetSpinResult();
            SpinInternal(_spinResult, OnReelStartSpin, OnReelStopSpin);
        }

        private void OnReelStartSpin()
        {

        }

        private void OnReelStopSpin()
        {
            if (IsAnyReelSpinning)
            {
                return;
            }

            _endSpinCallback?.Invoke(_spinResult);
        }

        private bool GetIsAnyReelSpinning()
        {
            var isSpinning = true;
            foreach (var reel in _reels)
            {
                isSpinning &= reel.IsSpinning;
            }

            return isSpinning;
        }

        private void SpinInternal(SpinResult resultToStopOn, Action startSpin, Action stopSpin)
        {
            _reels[0].Spin(resultToStopOn.First, Random.Range(2.5f, 8f), startSpin, stopSpin);
            _reels[1].Spin(resultToStopOn.Second, Random.Range(2.5f, 8f), startSpin, stopSpin);
            _reels[2].Spin(resultToStopOn.Third, Random.Range(2.5f, 8f), startSpin, stopSpin);
        }

        #endregion

        #region Properties

        public bool IsAnyReelSpinning => GetIsAnyReelSpinning();

        #endregion
    }
}
