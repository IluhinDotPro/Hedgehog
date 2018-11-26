using UnityEngine;

namespace Assets.Scripts
{
    [CreateAssetMenu(fileName = "Settings", menuName = "Hedgehogs/Settings", order = 0)]
    public class GameSettings : ScriptableObject
    {
        [Header("Hedgehog's Settings")]
        public float HedgehogSizeMin = 0.2f;
        public float HedgehogSizeMax = 2f;
        public float HedgehogRotationSpeed = 180;
        public float HedgehogEyesAnimTime = 0.2f;
        public float HedgehogEyesScaleValue = 1.3f;

        [Header("Kick settings")]
        public float KickForceMin = 1f;
        public float KickForceMax = 5f;
    }
}
