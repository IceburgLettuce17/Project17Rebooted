using UnityEditor;
using UnityEngine;

namespace Project17.Custom
{
	public class Project17SettingsWindow : EditorWindow
	{
		[SerializeField]
		public static Project17Settings settings;
		
        [MenuItem("Project17/Settings")]
        private static void Init()
        {     
			Project17SettingsWindow window = (Project17SettingsWindow)GetWindow(typeof(Project17SettingsWindow), false, "Settings");
			Vector2 minSize = window.minSize;
			minSize.x = 230;
			window.minSize = minSize;
        }
		
		private void OnGUI()
        {
		}
	}
}