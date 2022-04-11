using System;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Assets.Scripts.SlotMachineScripts
{
    public static class ResultGenerator
    {
        #region Methods

        public static SpinResult GetSpinResult()
        {
            var slotIndexLength = Enum.GetNames(typeof(SlotIndex)).Length;

            return new SpinResult
            {
                First = (SlotIndex)Random.Range(0, slotIndexLength),
                Second = (SlotIndex)Random.Range(0, slotIndexLength),
                Third = (SlotIndex)Random.Range(0, slotIndexLength)
            };
        }

        #endregion
    }
}
