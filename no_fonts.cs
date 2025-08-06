using BepInEx;
using BepInEx.Logging;
using BepInEx.Unity.IL2CPP;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace no_fonts
{

	public class NoFonts_Component : MonoBehaviour 
	{
		private float nextScan = 0.0f;
		void Update()
		{
			if (Time.time <= nextScan) { return; }
			nextScan += 0.5f;

			Scene uiScene = SceneManager.GetSceneByName("UserInterface");
			if (uiScene.loadingState == Scene.LoadingState.Loaded)
			{
				GameObject[] uiObjs = uiScene.GetRootGameObjects();
				foreach (GameObject obj in uiObjs)
				{
					TMP_Text[] texts = obj.GetComponentsInChildren<TMP_Text>(false);
					foreach (TMP_Text txt in texts)
					{
						if (txt.font != null) {
							txt.font = null;
						}
					}
				}
			}
		}

	}

	[BepInPlugin("no_fonts", "No Fonts", "0.0.2")]
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