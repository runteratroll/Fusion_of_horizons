using UnityEngine;
using UnityEngine.UI;

public class NPCTrade : MonoBehaviour
{
    public Image playerButtonImage; // 동전이 저장되는 버튼 이미지

    public Sprite requiredCoinSprite; // 필요한 동전 이미지

    public GameObject rewardObject;

    public GameObject Canvas2Button;

    private bool playerInside;
    private bool traded;

    private void Update()
    {
        if (!playerInside || traded)
            return;

        if (Input.GetKeyDown(KeyCode.E))
        {
            TryTrade();
        }
    }

    void TryTrade()
    {
        if (playerButtonImage.sprite == requiredCoinSprite)
        {
            rewardObject.SetActive(true);

            // 동전 제거
            playerButtonImage.sprite = null;
            Canvas2Button.SetActive(false);

            traded = true;

            Debug.Log("교환 완료");
        }
        else
        {
            Debug.Log("동전 없음");
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
            playerInside = true;
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
            playerInside = false;
    }
}