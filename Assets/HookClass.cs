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
            // “Š‚°‚Ä‚¢‚é‚Æ‚«
            if (fishingRodClass.rodState == FishingRodClass.RodState.Throwing)
            {
                //j‚Ì“®‚«
                transform.position += HookSpeed * Time.deltaTime;

                //j‚Éd—Í‚ğ“­‚©‚¹‚é
                HookSpeed.y -= gravity * Time.deltaTime;
            }
        }

        private void OnCollisionEnter(Collision collision)
        {
            //ŠC‚ÉG‚ê‚½‚Æ‚«
            if (collision.gameObject.name == "Ocean")
            {
                //’……ó‘Ô‚É‚·‚é
                fishingRodClass.rodState = FishingRodClass.RodState.LandedOnWater;

                //‘¬“x‚ğ‰Šú‰»
                HookSpeed = new Vector3(0, 0, 0);
            }
        }
    }
}