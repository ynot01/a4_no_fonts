using BepInEx;
using BepInEx.Logging;
using BepInEx.Unity.IL2CPP;
using TMPro;
using UnityEngine;
using HarmonyLib;

namespace no_fonts
{
	class NoFonts_Component : MonoBehaviour
	{
		void Awake() {
			Harmony.CreateAndPatchAll(typeof(NoFonts_Component));
		}

		[HarmonyPostfix]
		[HarmonyPatch(typeof(TextMeshProUGUI), nameof(TextMeshProUGUI.Awake))]
		static void OverrideAwake(TextMeshProUGUI __instance) {
			__instance.font = null;
		}
	}

	[BepInPlugin("no_fonts", "No Fonts", "0.0.5")]
	public class NoFonts : BasePlugin
	{
		internal static new ManualLogSource Log;

		public override void Load()
		{
			Log = base.Log;

			AddComponent<NoFonts_Component>();

			Log.LogInfo($"Plugin no_fonts loaded successfully.");
		}
	}
}