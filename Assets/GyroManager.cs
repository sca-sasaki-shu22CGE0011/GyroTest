using UnityEngine;
using UnityEngine.UI;

public class GyroManager : MonoBehaviour
{
    [SerializeField] private Text text;
    [SerializeField] GameObject Hook;
    private Vector3 angle;
    private Vector3 direction;
    private float gravity;
    private float pitch;
    private float yaw;
    private float roll;
    private Vector3 hookSpeed;

    public enum State { Normal, Throw,}
    private State state;

    // Start is called before the first frame update
    void Start()
    {
        Input.gyro.enabled = true;
        angle = Vector3.zero;
        gravity = 0.5f;
        state = State.Normal;
    }

    // Update is called once per frame
    void Update()
    {
        pitch = (Input.gyro.rotationRate.x * 180) / Mathf.PI;
        yaw = (Input.gyro.rotationRate.y * 180) / Mathf.PI;
        roll = (Input.gyro.rotationRate.z * 180) / Mathf.PI;
        angle.x = Mathf.Asin(Mathf.Clamp(Input.acceleration.x, -1, 1)) * Mathf.Rad2Deg;
        angle.z = Mathf.Asin(Mathf.Clamp(Input.acceleration.z, -1, 1)) * Mathf.Rad2Deg;
        //text.text =
        //    "pitch : " + (int)pitch +
        //    "\nyaw : " + (int)yaw +
        //    "\nroll : " + (int)roll +
        //    "\nangleX : " + angle.x.ToString("f1") +
        //    "\nangleZ : " + angle.z.ToString("f1");

        if (state == State.Throw)
        {
            Hook.transform.position += hookSpeed;
            //Hook.transform.position += gravity * Time.deltaTime;
            hookSpeed.y -= gravity * Time.deltaTime;
        }
    }

    private void UpdateGyroData()
    {
        pitch = (Input.gyro.rotationRate.x * 180) / Mathf.PI;
        yaw = (Input.gyro.rotationRate.y * 180) / Mathf.PI;
        roll = (Input.gyro.rotationRate.z * 180) / Mathf.PI;
    }

    public void GyroReSet()
    {
        if (pitch < 0)
        {
            text.text = "angle.z : " + angle.z.ToString("f1") +
                "\npithc : " + pitch.ToString("f1");
            direction = new Vector3(0, Mathf.Sin(0.8f), Mathf.Cos(0.8f));
            hookSpeed = direction * (-pitch / 15) * Time.deltaTime;
            state = State.Throw;
        }
    }

    public void Reset()
    {
        state = State.Normal;
        Hook.transform.position = new Vector3(0,0,0);
        hookSpeed = Vector3.zero;
    }
}
