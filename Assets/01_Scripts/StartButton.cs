using UnityEngine;
using UnityEngine.SceneManagement;

public class StartButton : MonoBehaviour
{
    [Header("이동할 씬 이름")]
    public string sceneName;

    // 버튼 OnClick에 연결
    public void StartGame()
    {
        SceneManager.LoadScene(sceneName);
    }
}