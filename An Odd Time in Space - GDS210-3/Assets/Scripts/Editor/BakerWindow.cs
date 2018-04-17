using UnityEditor;
using UnityEngine;

public class BakerWindow :  EditorWindow 
{
	[MenuItem("Window/Baker")]

	private static void ShowWindow()
	{
		GetWindow<BakerWindow>("Baker");
	}

	private void OnGUI()
	{
		if(GUILayout.Button("Get lighting baked ;)"))
		{
			Lightmapping.Bake();
		}
	}
}
