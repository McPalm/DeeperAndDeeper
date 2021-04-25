using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DynamicWater : MonoBehaviour
{
    float WaterLevel;
    public Transform water;

    public void SetDepth(float depth)
    {
        StopAllCoroutines();
        StartCoroutine(LerpDepth(depth));
    }

    IEnumerator LerpDepth(float depth)
    {
        float start = water.localPosition.y;
        for (float f = 0f; f < 1f; f += Time.deltaTime * .035f)
        {
            water.localPosition = new Vector3(0f, Mathf.Lerp(start, depth, 1f - (1f-f) * (1f-f)), 0f);
            yield return null;
        }
        water.localPosition = new Vector3(0f, depth, 0f);
    }
}
