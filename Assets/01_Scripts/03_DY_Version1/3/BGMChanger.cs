using UnityEngine;

public class BGMChanger : MonoBehaviour
{
    [Header("변경할 브금")]
    public AudioClip newBGM;

    [Header("브금 재생 AudioSource")]
    public AudioSource bgmSource;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Player"))
            return;

        // 이미 같은 브금이면 무시
        if (bgmSource.clip == newBGM)
            return;

        bgmSource.clip = newBGM;
        bgmSource.Play();
    }
}