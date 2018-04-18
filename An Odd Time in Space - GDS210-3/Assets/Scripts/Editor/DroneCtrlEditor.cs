using UnityEngine;
using UnityEditor;

public class DroneCtrlEditor : Editor
{
	private Editor _editor;
	private DroneController _droneCtrl;
	private bool _shootingMechConnected;

	public void OnEnable()
	{
		_editor = null; // Resets the cached editor. (Our little addition)
	}

	public override void OnInspectorGUI()
	{
		serializedObject.Update(); // Updates all of serialized variables in inspector.

		_droneCtrl = (DroneController)target; // Assigns _droneCtrl to the in use DroneController.

		if(_droneCtrl._shootingMechanism == null)
		{
			base.OnInspectorGUI(); // Applies original inspector GUI.
			if(_shootingMechConnected)
			{
				_shootingMechConnected = false;
				Debug.LogWarning ("Assign ShootingMechanism to " + _droneCtrl + "!");
			}
			return;
		}
		else
		{
			_shootingMechConnected = true;
		}

		if(_editor == null)
		{
			/* Creates the cached editor for the _shootinMechanism variable.
			 * (Makes the scriptable object "ShootingMechanism" editable in the same component as the DroneController script.
			 */
			_editor = Editor.CreateEditor(_droneCtrl._shootingMechanism);
		}

		if(_droneCtrl._shootingMechanism._projectileSpawnPoint == null)
		{
			GUILayout.Label ("This button will create a prefab instance of this object. \n" +
			"It will also create a projectile spawn point and assign it to the appropriate fields");
			if(GUILayout.Button("Setup Prefab"))
			{
				SetupProjectileSP ();
			}
		}
		else
		{
			GUILayout.Label("Projectile SP has been setup.");
		}

		serializedObject.ApplyModifiedProperties(); // Applies properties to scriptable object.

		base.OnInspectorGUI(); // Applies original inspector GUI.

		_editor.DrawDefaultInspector(); // Applies our addition.
	}

	void SetupProjectileSP()
	{
		// Creates a new empty gameobject.
		GameObject gObj = new GameObject ("TRSF_Projectile SP");
		gObj.transform.parent = Selection.activeTransform;
		gObj.transform.localPosition = Vector3.zero;
		gObj.transform.localRotation = Quaternion.Euler(Vector3.zero);
		Debug.Log(gObj.name + "added as child of " + _droneCtrl);

		// Assigns to prefab.
		GameObject currentObj = Selection.activeGameObject;
		Object prefab = PrefabUtility.CreatePrefab("Assets/Custom Assets/GameObject_Prefabs/Enemies/" + currentObj.name + ".prefab", currentObj);
		prefab = PrefabUtility.ReplacePrefab (currentObj, prefab, ReplacePrefabOptions.ConnectToPrefab);

		// Attach transform.
		GameObject test = (GameObject)prefab;
		_droneCtrl._shootingMechanism._projectileSpawnPoint = test;
		Debug.Log (_droneCtrl.name + "now has a default projectile SP.\n" +
			"Transform: " + gObj.transform + "\n" +
			"Location: " + gObj.transform.position);
	}
}
