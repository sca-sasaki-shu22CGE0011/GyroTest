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
            // 投げているとき
            if (fishingRodClass.rodState == FishingRodClass.RodState.Throwing)
            {
                //針の動き
                transform.position += HookSpeed * Time.deltaTime;

                //針に重力を働かせる
                HookSpeed.y -= gravity * Time.deltaTime;
            }
        }

        private void OnCollisionEnter(Collision collision)
        {
            //海に触れたとき
            if (collision.gameObject.name == "Ocean")
            {
                //着水状態にする
                fishingRodClass.rodState = FishingRodClass.RodState.LandedOnWater;

                //速度を初期化
                HookSpeed = new Vector3(0, 0, 0);
            }
        }
    }
}