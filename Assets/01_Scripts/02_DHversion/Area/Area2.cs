using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine;
using UnityEngine.Networking;

public class Area2 : Area
{
    private List<AudioSource> loadedSources = new();

    public AudioSource MainAudioSource;

    public List<AudioClip> AudioClips = new();

    public TextMeshPro Text;

    private void Start()
    {
        StartCoroutine(CoLoadAllWavFiles());
    }

    public override void OnAreEnter(Collider2D other)
    {
        base.OnAreEnter(other);

        MainAudioSource.Pause();

        PlayAll();

        CheckAudio();
    }

    public override void OnAreaExit(Collider2D other)
    {
        base.OnAreaExit(other);

        StopAll();

        MainAudioSource.UnPause();
    }

    private IEnumerator CoLoadAllWavFiles()
    {
        string folderPath =
            Path.Combine(Application.streamingAssetsPath, "Sounds");

        if (!Directory.Exists(folderPath))
        {
            Debug.LogError($"폴더 없음 : {folderPath}");
            yield break;
        }

        string[] wavFiles = Directory.GetFiles(folderPath, "*.wav");

        Debug.Log($"찾은 wav 파일 개수 : {wavFiles.Length}");

        foreach (string filePath in wavFiles)
        {
            yield return StartCoroutine(LoadWavFile(filePath));
        }

        SetText(wavFiles.Length);
    }

    private void SetText(int fileCount)
    {
        if (fileCount >= 4)
        {
            Text.SetText("너무 시끄러...\r\n내가 좋아하는 곡 하나만 남겨줘");
        }
        else if (fileCount >= 2)
        {
            Text.SetText("이게 아냐...\n다른거!");
        }
        else if (fileCount == 1)
        {
            if (IsAnswer())
            {
                Text.SetText("그래.. 이거야..");
            }
            else
            {
                Text.SetText("이게 아냐...\n다른거!");
            }
        }
    }

    private IEnumerator LoadWavFile(string filePath)
    {
        if (!File.Exists(filePath))
        {
            Debug.LogError($"파일 없음: {filePath}");
            yield break;
        }

        FileInfo info = new FileInfo(filePath);

        if (info.Length <= 0)
        {
            Debug.LogError($"빈 파일: {filePath}");
            yield break;
        }

        string url = new System.Uri(filePath).AbsoluteUri;

        Debug.Log($"로드 시도: {url}");

        using UnityWebRequest request =
            UnityWebRequestMultimedia.GetAudioClip(url, AudioType.WAV);

        yield return request.SendWebRequest();

        if (request.result != UnityWebRequest.Result.Success)
        {
            Debug.LogError($"로드 실패: {filePath}");
            Debug.LogError(request.error);
            yield break;
        }

        AudioClip clip = null;

        try
        {
            clip = DownloadHandlerAudioClip.GetContent(request);
        }
        catch (System.Exception e)
        {
            Debug.LogError($"AudioClip 변환 실패: {filePath}");
            Debug.LogError(e);
            yield break;
        }

        if (clip == null)
        {
            Debug.LogError($"클립 null: {filePath}");
            yield break;
        }

        GameObject go = new GameObject($"Audio_{Path.GetFileNameWithoutExtension(filePath)}");
        go.transform.SetParent(transform);

        AudioSource source = go.AddComponent<AudioSource>();
        source.clip = clip;

        loadedSources.Add(source);

        Debug.Log($"로드 성공: {clip.name}");
    }

    public void PlayAll()
    {
        foreach (AudioSource source in loadedSources)
        {
            source.Play();
        }
    }

    public void StopAll()
    {
        foreach (AudioSource source in loadedSources)
        {
            source.Stop();
        }
    }

    private void CheckAudio()
    {
        if (IsAnswer())
        {
            Goal.gameObject.SetActive(true);
        }
    }

    private bool IsAnswer()
    {
        return loadedSources.Count == 1 && loadedSources[0].name == "Audio_마음이여 원시로 돌아가라";
    }
}
