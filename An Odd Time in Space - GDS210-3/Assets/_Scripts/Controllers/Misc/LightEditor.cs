using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class LightEditor
{
    [Header("Main")]
    [SerializeField] private Light _lightEditing;

    [Header("Range Lerp")]
    public bool _lerpRange;
    [SerializeField] private float _maxRange;
    [SerializeField] private float _rangeLerpDuration;

    [Header("Intensity Lerp")]
    public bool _lerpIntensity;
    [SerializeField] private float _maxIntensity;
    [SerializeField] private float _intensityLerpDuration;

    [HideInInspector] public float _longestLerp;

    public IEnumerator LerpRange()
    {
        CheckLongestLerp();

        float step = 0;
        float startingRange = _lightEditing.range;

        while(step < 1)
        {
            _lightEditing.range = Mathf.Lerp(startingRange, _maxRange, step);

            step += Time.deltaTime / _rangeLerpDuration;

            yield return null;
        }

        yield return null;
    }

    public IEnumerator LerpIntensity()
    {
        CheckLongestLerp();

        float step = 0;
        float startingIntensity = _lightEditing.intensity;

        while (step < 1)
        {
            _lightEditing.intensity = Mathf.Lerp(startingIntensity, _maxIntensity, step);

            step += Time.deltaTime / _intensityLerpDuration;

            yield return null;
        }

        yield return null;
    }

    private void CheckLongestLerp()
    {
        if (_intensityLerpDuration > _rangeLerpDuration)
            _longestLerp = _intensityLerpDuration;
        else
            _longestLerp = _rangeLerpDuration;
    }
}
