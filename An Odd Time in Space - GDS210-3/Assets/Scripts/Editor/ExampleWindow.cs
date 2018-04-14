using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(LaserDrone))]
public class ExampleWindow : Editor
{
	
	#region "Blog"
	private string[] _availibleShootingMechanisms = new[] 
	{ 
		"BaseShoot", // 0.
		"BaseReloadShoot", // 1.
		"SimpleAutoShoot" // 2.
	};
	int _choiceIndex;
	#endregion

	private Editor _editor;

	public void OnEnable()
	{
		_editor = null;
	}

	public override void OnInspectorGUI()
	{
		serializedObject.Update();

		DroneController droneCtrl = (DroneController)target;

		if(droneCtrl.GetType() == typeof(SimpleAutoShoot))
		{
			Debug.Log("test");
		}

		if(_editor == null)
		{
			_editor = Editor.CreateEditor(droneCtrl._shootingMechanism);
		}

		serializedObject.ApplyModifiedProperties();

		base.OnInspectorGUI();

		_editor.DrawDefaultInspector();
//		serializedObject.Update();
//
//		var currentShootingMechanism = serializedObject.FindProperty("_shootingMechanism");
//		CreateCachedEditor(currentShootingMechanism.objectReferenceValue, null, ref _editor);
//		_editor.OnInspectorGUI();
//
//		serializedObject.ApplyModifiedProperties();
	}


//	void PopupForBlog()
//	{
//		DrawDefaultInspector();
//		_choiceIndex = EditorGUILayout.Popup(_choiceIndex, _availibleShootingMechanisms);
//		DroneController droneCtrl = (DroneController)target;
//
//		switch(_availibleShootingMechanisms[_choiceIndex])
//		{
//		case "BaseShoot":
//			droneCtrl._shootingMechanism = new BaseShoot();
//			break;
//		case "BaseReloadShoot":
//			droneCtrl._shootingMechanism = new BaseReloadShoot();
//			break;
//		}
//
//		EditorUtility.SetDirty(target);
//	}
}
