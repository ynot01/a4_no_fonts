using BepInEx;
using BepInEx.Logging;
using BepInEx.Unity.IL2CPP;
using TMPro;
using UnityEngine;

namespace no_fonts
{

	public class NoFonts_Component : MonoBehaviour 
	{
		void Update()
		{
			var texts = GameObject.FindObjectsByType<TMP_Text>(UnityEngine.FindObjectsSortMode.None);
			foreach (TMP_Text txt in texts)
			{
				txt.font = null;
			}
		}
	}

	[BepInPlugin("no_fonts", "No Fonts", "0.0.1")]
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