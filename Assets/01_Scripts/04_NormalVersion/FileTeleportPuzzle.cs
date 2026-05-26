using UnityEngine;
using System.IO;

public class FileTeleportPuzzle : MonoBehaviour
{
    [Header("찾을 파일 이름")]
    public string targetFileName = "tree.txt";

    [Header("확인할 줄 번호")]
    public int lineNumber = 10;

    [Header("정답 숫자")]
    public int correctNumber = 10;

    [Header("플레이어")]
    public Transform player;

    [Header("이동 위치")]
    public Transform teleportPoint;

    private void Start()
    {
        CheckFile();
    }

    private void CheckFile()
    {
        string folderPath = Application.streamingAssetsPath;

        // 폴더 안 파일 전부 가져오기
        string[] files = Directory.GetFiles(folderPath);

        string foundFile = null;

        foreach (string file in files)
        {
            string fileName = Path.GetFileName(file);

            // 대소문자 무시 비교
            if (string.Equals(
                fileName,
                targetFileName,
                System.StringComparison.OrdinalIgnoreCase))
            {
                foundFile = file;
                break;
            }
        }

        if (string.IsNullOrEmpty(foundFile))
        {
            Debug.Log("파일 없음");
            return;
        }

        string[] lines = File.ReadAllLines(foundFile);

        int index = lineNumber - 1;

        if (lines.Length <= index)
        {
            Debug.Log(lineNumber + "번째 줄 없음");
            return;
        }

        string lineText = lines[index].Trim();

        if (int.TryParse(lineText, out int value))
        {
            if (value == correctNumber)
            {
                player.position = teleportPoint.position;

                Debug.Log("조건 만족. 플레이어 이동.");
            }
        }
    }
}