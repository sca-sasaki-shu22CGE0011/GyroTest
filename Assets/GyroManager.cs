using UnityEngine;

namespace Sasaki
{
    public class GyroManager : MonoBehaviour
    {
        public float Pitch;
        public float Yaw;
        public float Roll;
        public Vector3 Angle;

        private void Start()
        {
            Input.gyro.enabled = true;
        }

        private void Update()
        {
            UpdataGyroData();
            UpdataAccelerometer();
        }

        // ジャイロスコープの値取得
        private void UpdataGyroData()
        {
            Pitch = (Input.gyro.rotationRate.x * 180) / Mathf.PI;
            Yaw = (Input.gyro.rotationRate.y * 180) / Mathf.PI;
            Roll = (Input.gyro.rotationRate.z * 180) / Mathf.PI;
        }

        // 加速度センサーの値取得
        private void UpdataAccelerometer()
        {
            Angle.x = Mathf.Asin(Mathf.Clamp(Input.acceleration.x, -1, 1)) * Mathf.Rad2Deg;
            Angle.y = Mathf.Asin(Mathf.Clamp(Input.acceleration.y, -1, 1)) * Mathf.Rad2Deg;
            Angle.z = Mathf.Asin(Mathf.Clamp(Input.acceleration.z, -1, 1)) * Mathf.Rad2Deg;
        }
    }
}
