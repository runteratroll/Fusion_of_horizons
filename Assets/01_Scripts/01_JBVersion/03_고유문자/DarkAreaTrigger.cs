using UnityEngine;
using UnityEngine.Rendering.Universal;

public class DarkAreaTrigger : MonoBehaviour
{
    [Header("Lights")]
    [SerializeField] private Light2D globalLight;

    [Header("Brightness")]
    [SerializeField] private float normalIntensity = 1f;
    [SerializeField] private float darkIntensity = 0.08f;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            globalLight.intensity = darkIntensity;
        }
    }

  
}