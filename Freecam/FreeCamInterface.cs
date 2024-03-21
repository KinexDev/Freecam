using UnityEngine;

namespace Freecam
{
    class FreeCamInterface : MonoBehaviour
    {
        public bool IsCabin;
        public bool PauseTime;
        public float sensitivity;
        public float speed;
        public float speedBoost;
        public PlayerMove playerMove;
        public Climbing climbing;
        public RopeAnchor RopeAnchor;
        public MicroHolds microHolds;
        public GameObject Camera;
        public GameObject OtherCamera;
        public GameObject Canvas;
        bool IsFreecam;
        Vector2 Rotation;
        public void Update()
        {
            if (Input.GetKeyDown(KeyCode.F8))
            {
                if (!IsFreecam)
                {
                    if (PauseTime)
                    {
                        Time.timeScale = 0;
                    }

                    playerMove.enabled = false;

                    Camera.transform.position = OtherCamera.transform.position;
                    Camera.transform.rotation = OtherCamera.transform.rotation;
                    Camera.GetComponent<Camera>().fieldOfView = OtherCamera.GetComponent<Camera>().fieldOfView;

                    Camera.SetActive(true);
                    OtherCamera.SetActive(false);
                    Canvas.SetActive(false);

                    Rotation = Camera.transform.eulerAngles;

                    if (!IsCabin)
                    {
                        climbing.enabled = false;
                        RopeAnchor.enabled = false;
                        microHolds.enabled = false;
                    }
                    IsFreecam = true;
                } else
                {
                    Time.timeScale = 1;

                    Camera.SetActive(false);
                    OtherCamera.SetActive(true);
                    Canvas.SetActive(true);

                    playerMove.enabled = true;

                    if (!IsCabin)
                    {
                        climbing.enabled = true;
                        RopeAnchor.enabled = true;
                        microHolds.enabled = true;
                    }
                    IsFreecam = false;
                }
            }

            if (IsFreecam)
            {
                if (Input.GetMouseButton(1))
                {
                    float horizontal = Input.GetKey(KeyCode.D) == true ? 1 : Input.GetKey(KeyCode.A) == true ? -1 : 0;
                    float vertical = Input.GetKey(KeyCode.W) == true ? 1 : Input.GetKey(KeyCode.S) == true ? -1 : 0;
                    float upAndDown = Input.GetKey(KeyCode.E) == true ? 1 : Input.GetKey(KeyCode.Q) == true ? -1 : 0;

                    Camera.transform.position += Camera.transform.rotation * new Vector3(horizontal, upAndDown, vertical) * (Input.GetKey(KeyCode.LeftShift) ? speed * speedBoost : speed) * Time.unscaledDeltaTime;

                    Rotation.y += Input.GetAxis("Mouse X") * 10 * sensitivity * Time.unscaledDeltaTime;
                    Rotation.x += -Input.GetAxis("Mouse Y") * 10 * sensitivity * Time.unscaledDeltaTime;
                    Camera.transform.rotation = Quaternion.Euler(Rotation);
                }
            }
        }
    }
}
