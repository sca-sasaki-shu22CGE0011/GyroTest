using UnityEngine;
using Sasaki;
using System.Runtime.CompilerServices;

namespace Sasaki
{
    public class FishingRodClass : MonoBehaviour
    {
        [SerializeField] private GameObject Hook;
        private Vector3 direction; //�j���΂��p�x
        private GyroManager gyroManager;
        private HookClass hookClass;

        public enum RodState { Normal, Threw, Throwing, LandedOnWater, StartPullingUp, PullingUp, FinishPullingUp}
        public RodState rodState;

        void Start()
        {
            gyroManager = FindObjectOfType<GyroManager>();
            hookClass = FindObjectOfType<HookClass>();
            rodState = RodState.Normal;
        }

        void Update()
        {
            if (rodState == RodState.LandedOnWater)
                PullUp();
        }

        // �j�𓊂��鏈��
        public void Throw()
        {
            if (gyroManager.Pitch < 0)
            {
                rodState = RodState.Throwing;
                direction = new Vector3(0, Mathf.Sin(0.8f), Mathf.Cos(0.8f));
                hookClass.HookSpeed = direction * (-gyroManager.Pitch / 15);
            }
        }

        // �������Ɉ����グ�鏈��
        public void PullUp()
        {
            if (gyroManager.Pitch > 0)
            {
                rodState = RodState.StartPullingUp;
            }
        }

        //�f�o�b�O�p
        public void Reset()
        {
            rodState = RodState.Normal;
            hookClass.HookSpeed = new Vector3(0, 0, 0);
            GameObject.Find("Cube").transform.position = new Vector3(0, 0, 0);
        }
    }
}
