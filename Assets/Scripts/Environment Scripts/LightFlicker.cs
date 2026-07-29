using System.Collections;
using System.Threading.Tasks;
using UnityEngine;

public class LightFlicker : MonoBehaviour
{
    public Light light;
    private bool inf = true;

    void Start()
    {            
        StartCoroutine(ChangeIntensity());
    }

    private IEnumerator ChangeIntensity()
    {
        while (inf)
        {
            float startIntensity = light.intensity;
            float targetIntensity = Random.Range(4f, 8f);

            float startRange = light.range;
            float targetRange = Random.Range(2, 7);

            float duration = 0.5f;
            float elapsed = 0f;

            while (elapsed < duration)
            {
                elapsed += Time.deltaTime;
                float t = Mathf.SmoothStep(0f, 1f, elapsed / duration);

                light.intensity = Mathf.Lerp(startIntensity, targetIntensity, t);
                light.range = Mathf.Lerp(startRange, targetRange, t);

                yield return null;
            }
        }
    }
}
