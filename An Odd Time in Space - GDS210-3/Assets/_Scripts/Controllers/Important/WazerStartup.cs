using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEditor;


public class WazerStartup : MonoBehaviour
{
	AudioSource _audioSource;
	[SerializeField] AudioClip defeatJingle;
    [SerializeField] private GameObject[] _objectsToInsantiate;
    [SerializeField] private GameObject _commenceOrb;
    [SerializeField] private LightEditor[] _lightsToFadeIn;
    [SerializeField] private LightEditor[] _lightsToFadeOut;

    private List<GameObject> _instantiatedObjects;

	void Start () {
		_audioSource = GetComponent<AudioSource> ();
	}

    public void StartWazeGame()
    {
        _instantiatedObjects = new List<GameObject>();

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
            _instantiatedObjects.Add(Instantiate(obj, transform.parent.transform));
        }
    }

    public void EndWazeGame()
    {
		_audioSource.PlayOneShot (defeatJingle);

        foreach(LightEditor light in _lightsToFadeOut)
        {
            if (light._lerpIntensity)
            {
                StartCoroutine(light.LerpIntensity());
            }

            if (light._lerpRange)
            {
                StartCoroutine(light.LerpRange());
            }
        }

        foreach(GameObject obj in _instantiatedObjects)
        {
            Destroy(obj);
        }

        _commenceOrb.SetActive(true);
    }
}

/* Unable to build - temp comment out due to errors
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
*/