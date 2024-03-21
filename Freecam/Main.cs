using BepInEx;
using POKModManager;

namespace Freecam
{
    [BepInPlugin("Data.Freecam", "Freecam", "1.0.0")]
    public class Main : BaseUnityPlugin
    {
        public void Start()
        {
            Freecam freecam = new Freecam();
            POKManager.RegisterMod(freecam, "Freecam Mod", "1.0.0", "Mod that allows camera to free, Press F8 to go into freecam.", nameof(freecam.PauseGame), 
                nameof(freecam.Speed), 
                nameof(freecam.Sensitivity),
                nameof(freecam.ShiftSpeedBoost));
        }
    }
}
