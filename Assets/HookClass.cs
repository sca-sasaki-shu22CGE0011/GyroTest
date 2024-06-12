using UnityEngine;
using UnityEngine.UI;
using Sasaki;
using System.Runtime.CompilerServices;

namespace Sasaki
{
    public class HookClass : MonoBehaviour
    {
        [SerializeField] private Text text;
        public Vector3 HookSpeed;
        private float gravity;
        private FishingRodClass fishingRodClass;

        void Start()
        {
            fishingRodClass = FindObjectOfType<FishingRodClass>();
            gravity = 9.8f;
        }

        void Update()
        {
            // �����Ă���Ƃ�
            if (fishingRodClass.rodState == FishingRodClass.RodState.Throwing)
            {
                //�j�̓���
                transform.position += HookSpeed * Time.deltaTime;

                //�j�ɏd�͂𓭂�����
                HookSpeed.y -= gravity * Time.deltaTime;
            }
        }

        private void OnCollisionEnter(Collision collision)
        {
            //�C�ɐG�ꂽ�Ƃ�
            if (collision.gameObject.name == "Ocean")
            {
                //������Ԃɂ���
                fishingRodClass.rodState = FishingRodClass.RodState.LandedOnWater;

                //���x��������
                HookSpeed = new Vector3(0, 0, 0);
            }
        }
    }
}