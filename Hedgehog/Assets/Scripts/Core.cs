using UnityEngine;
using UnityEngine.EventSystems;

namespace Assets.Scripts
{
    public class Core : MonoBehaviour
    {
        public static Core I;
        public GameSettings Settings;
        public float YDeadLine = -10;
        public Transform HedgehogRoot;
        public HedgehogController HedgehogPrefab;
        public Collider2D FloorCollider;
        
        public void Awake()
        {
            I = this;
        }

        private void Update () {
            if (!Input.GetMouseButtonUp(0)) return;

            if (EventSystem.current.IsPointerOverGameObject()) return;

            var position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            position.z = 0;

            var target = Physics2D.OverlapPoint(position);
            if (target != null)
            {
                var hc = target.GetComponent<HedgehogController>();
                if (hc == null) return;
                hc.Touch();
                return;
            }
            
            var hedgehog = Instantiate(HedgehogPrefab, position, Quaternion.identity, HedgehogRoot);
            hedgehog.Init();
        }

        public void Clear()
        {
            while (HedgehogRoot.childCount > 0)
            {
                DestroyImmediate(HedgehogRoot.GetChild(0).gameObject);
            }
        }
    }
}
