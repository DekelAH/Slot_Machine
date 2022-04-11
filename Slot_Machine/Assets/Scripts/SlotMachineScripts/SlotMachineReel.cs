using System;
using System.Collections;
using UnityEngine;

namespace Assets.Scripts.SlotMachineScripts
{
    public class SlotMachineReel : MonoBehaviour
    {
        #region Editor

        [SerializeField]
        [Range(0, 3)]
        private float _spinSpeed;

        [SerializeField]
        private Transform _reelTransform;

        [SerializeField]
        private AnimationCurve _rotationSpeedCurve;

        #endregion

        #region Methods

        public void Spin(SlotIndex indexToStopOn, float spinDuration, Action startCallback, Action endCallback)
        {
            StartCoroutine(SpinReel(indexToStopOn, _spinSpeed, spinDuration, startCallback, endCallback));
        }

        #endregion

        private IEnumerator SpinReel(SlotIndex indexToStopOn, float rotationSpeed, float spinDuration, Action startCallback, Action endCallback)
        {
            yield return null;
            IsSpinning = true;
            startCallback?.Invoke();

            var spinningTime = 0f;

            while (spinningTime <= spinDuration)
            {
                var evaluateFactor = spinningTime / spinDuration;
                rotationSpeed *= _rotationSpeedCurve.Evaluate(evaluateFactor);
                _reelTransform.RotateAround(_reelTransform.position, Vector3.left, _spinSpeed);
                spinningTime += Time.deltaTime;

                yield return null;
            }

            IsSpinning = false;
            _reelTransform.rotation = Quaternion.Euler(45f * (int)indexToStopOn, 0, 0);

            endCallback?.Invoke();
        }

        #region Properties

        public bool IsSpinning { get; private set; }

        #endregion
    }
}
