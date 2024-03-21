using POKModManager;
using UnityEngine.SceneManagement;
using UnityEngine;

namespace Freecam
{
    class Freecam : ModClass
    {
        public bool PauseGame { get; set; } = true;
        [POKRange(0, 50)] public int Speed { get; set; } = 5;
        [POKRange(0, 1000)] public int Sensitivity { get; set; } = 100;
        [POKRange(1, 5)] public float ShiftSpeedBoost { get; set; } = 2f;

        public override void Start()
        {
            if (SceneManager.GetActiveScene().buildIndex > 0)
            {
                GameObject camera = new GameObject("Camera");

                FreeCamInterface _interface = GameObject.Find("Player").AddComponent<FreeCamInterface>();

                Camera _camera = camera.AddComponent<Camera>();

                _interface.Camera = camera;
                _camera.nearClipPlane = 0.01f;

                _interface.PauseTime = PauseGame;
                _interface.speed = Speed;
                _interface.speedBoost = ShiftSpeedBoost;
                _interface.sensitivity = Sensitivity;

                _interface.Camera.SetActive(false);

                _interface.playerMove = GameObject.Find("Player").GetComponent<PlayerMove>();

                _interface.Canvas = GameObject.Find("Canvas");

                if (SceneManager.GetActiveScene().buildIndex > 1)
                {
                    _interface.IsCabin = false;
                    _interface.climbing = GameObject.Find("Player").GetComponent<Climbing>();
                    _interface.RopeAnchor = GameObject.Find("Player").GetComponent<RopeAnchor>();
                    _interface.microHolds = GameObject.Find("Player").GetComponent<MicroHolds>();
                } else
                {
                    _interface.IsCabin = true;
                }

                _interface.OtherCamera = _interface.IsCabin ? GameObject.Find("MainCamera") : GameObject.Find("CamY");
            }
        }
    }
}
