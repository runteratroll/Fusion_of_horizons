using System.Collections;
using UnityEngine;

public class ShrinkDoorOnTouch : MonoBehaviour
{
    [SerializeField]
    private Vector3 smallScale =
        new Vector3(1f, 0.2f, 1f);

    [SerializeField] private float shrinkTime = 1f;
    [SerializeField] private float stayTime = 0.5f;
    [SerializeField] private float returnTime = 1f;

    private Vector3 originalScale;
    private bool isPlaying;

    private void Awake()
    {
        originalScale = transform.localScale;
    }

    public void PlayAnimation()
    {
        if (isPlaying) return;

        StartCoroutine(ShrinkRoutine());
    }

    private IEnumerator ShrinkRoutine()
    {
        isPlaying = true;

        yield return Scale(
            originalScale,
            smallScale,
            shrinkTime);

        yield return new WaitForSeconds(stayTime);

        yield return Scale(
            smallScale,
            originalScale,
            returnTime);

        isPlaying = false;
    }

    private IEnumerator Scale(
        Vector3 from,
        Vector3 to,
        float duration)
    {
        float timer = 0;

        while (timer < duration)
        {
            timer += Time.deltaTime;

            float t = timer / duration;
            t = Mathf.SmoothStep(0, 1, t);

            transform.localScale =
                Vector3.Lerp(from, to, t);

            yield return null;
        }

        transform.localScale = to;
    }
}