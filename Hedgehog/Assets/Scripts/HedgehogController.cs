using DG.Tweening;
using UnityEngine;

namespace Assets.Scripts
{
    public class HedgehogController: MonoBehaviour
    {
        public Transform MyTransform;
        public Rigidbody2D MyRigid;
        public Transform Eyes;
        
        public void Init()
        {
            var size = Random.Range(Core.I.Settings.HedgehogSizeMin, Core.I.Settings.HedgehogSizeMax);
            MyTransform.localScale = new Vector3(size, size, 1);
        }

        public void Update()
        {
            if (MyTransform.localPosition.y < Core.I.YDeadLine) Destroy(gameObject);

            if (MyRigid.IsTouching(Core.I.FloorCollider)) RotateMe();
        }

        public void Touch()
        {
            PlayTouchAnim();

            var randomForceValue = Random.Range(Core.I.Settings.KickForceMin, Core.I.Settings.KickForceMax);
            var force = new Vector2(Random.Range(-.25f, .25f), Random.Range(.75f, 1f)) * randomForceValue;
            MyRigid.AddForce(force, ForceMode2D.Impulse);
        }

        private void PlayTouchAnim()
        {
            Eyes.DOScale(Vector3.one * Core.I.Settings.HedgehogEyesScaleValue, Core.I.Settings.HedgehogEyesAnimTime).OnComplete(
                () =>
                {
                    Eyes.DOScale(Vector3.one, Core.I.Settings.HedgehogEyesAnimTime);
                });
        }

        public void RotateMe()
        {
            var rot = MyTransform.localEulerAngles;
            rot.z = Mathf.MoveTowardsAngle(rot.z, 0, Time.deltaTime * Core.I.Settings.HedgehogRotationSpeed);
            MyTransform.localEulerAngles = rot;
        }
    }
}