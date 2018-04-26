using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class WazerStartup : MonoBehaviour
{
    [SerializeField] private Light[] _lightsToFadeIn;
    [SerializeField] private float _fadeTime;
    [SerializeField] private float _maxLightRange;
    [SerializeField] private GameGod[] _objectsToInsantiate;

    public void StartWazeGame()
    {
        foreach(Light light in _lightsToFadeIn)
        {
            StartCoroutine(FadeLight(light));
        }
    }

    IEnumerator FadeLight(Light light)
    {
        float step = 0;

        while(step < 1)
        {
            light.range = Mathf.Lerp(0, _maxLightRange, step);

            step += Time.deltaTime / _fadeTime;

            yield return null;
        }

        yield return null;
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