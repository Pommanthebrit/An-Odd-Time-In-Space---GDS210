using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;


public class WazerStartup : MonoBehaviour
{
    [SerializeField] private GameObject[] _objectsToInsantiate;
    [SerializeField] private LightEditor[] _lightsToFadeIn;

    public void StartWazeGame()
    {
        foreach(LightEditor light in _lightsToFadeIn)
        {
            if(light._lerpIntensity)
            {
                StartCoroutine(light.LerpIntensity());
            }

            if(light._lerpRange)
            {
                StartCoroutine(light.LerpRange());
            }
        }

        foreach(GameObject obj in _objectsToInsantiate)
        {
            Instantiate(obj, transform.parent.transform);
        }
    }
}


[CustomEditor(typeof(WazerStartup))]
class TestButton : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        if (GUILayout.Button("Test StartWazeGame"))
        {
            WazerStartup testClass = (WazerStartup)target;

            testClass.StartWazeGame();
        }
    }
}