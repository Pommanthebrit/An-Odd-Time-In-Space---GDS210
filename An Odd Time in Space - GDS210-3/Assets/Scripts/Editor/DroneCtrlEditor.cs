using UnityEngine;
using UnityEditor;

public class DroneCtrlEditor : Editor
{
	private Editor _editor;

	public void OnEnable()
	{
		_editor = null; // Resets the cached editor. (Our little addition)
	}

	public override void OnInspectorGUI()
	{
		serializedObject.Update(); // Updates all of serialized variables in inspector.

		DroneController droneCtrl = (DroneController)target; // Assigns droneCtrl to the in use DroneController.

		if(_editor == null)
		{
			/* Creates the cached editor for the _shootinMechanism variable.
			 * (Makes the scriptable object "ShootingMechanism" editable in the same component as the DroneController script.
			 */
			_editor = Editor.CreateEditor(droneCtrl._shootingMechanism);
		}

		base.OnInspectorGUI(); // Applies original inspector GUI.

		_editor.DrawDefaultInspector(); // Applies our addition.

		serializedObject.ApplyModifiedProperties(); // Applies properties to scriptable object.
	}
}
