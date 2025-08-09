using BepInEx;
using HarmonyLib;
using UnityEngine;

namespace LH_SVCustomWeapons
{
    [BepInPlugin(pluginGuid, pluginName, pluginVersion)]
    public class LH_SVCustomWeapons : BaseUnityPlugin
    {
        public const string pluginGuid = "LH_SVCustomWeapons";
        public const string pluginName = "LH_SVCustomWeapons";
        public const string pluginVersion = "0.0.2";

        public void Awake()
        {
            Harmony.CreateAndPatchAll(typeof(LH_SVCustomWeapons));
        }

        [HarmonyPatch(typeof(WeaponCrafting), "AddComponent")]
        [HarmonyPrefix]

        public static bool Booster(int ___selectedCompID)
        {
            WeaponComponent weaponComponent = Crafting.GetWeaponComponent(___selectedCompID);
            if (weaponComponent.isBooster > 0)
                weaponComponent.isBooster = 255;
            return true;
        }

        [HarmonyPatch(typeof(WeaponCrafting), "AddModifier")]
        [HarmonyPrefix]

        public static bool Modifier(int ___selectedMod)
        {
            if (___selectedMod > 0)
            {
                WeaponModifier weaponModifier = Crafting.GetWeaponModifier(___selectedMod);
                if (weaponModifier.id == 1 || weaponModifier.id == 4 || weaponModifier.id == 6 || weaponModifier.id == 9 || weaponModifier.id == 11 || weaponModifier.id == 12 || weaponModifier.id == 13 || weaponModifier.id == 15)
                    return true;
                else
                    weaponModifier.allowedInstances = 255;
                //Debug.Log(weaponModifier.id + " this is the ID of the last added modifier/booster");
            }
            return true;
        }
    }
}