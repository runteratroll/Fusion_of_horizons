using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;


public class MineCell : MonoBehaviour, IPointerClickHandler
{
    public int x;
    public int y;

    public bool isMine;
    public bool isOpened;
    public bool isFlagged;

    public int nearbyMineCount;

    [SerializeField] private Button button;
    [SerializeField] private Image numberImage;
    [SerializeField] private GameObject flagImage;
    [SerializeField] private GameObject mineImage;

    [SerializeField] private Sprite[] numberSprites;


    private MineSweeperManager manager;

    public void Init(int x, int y, MineSweeperManager manager)
    {
        this.x = x;
        this.y = y;
        this.manager = manager;

        isMine = false;
        isOpened = false;
        isFlagged = false;

        flagImage.SetActive(false);
        mineImage.SetActive(false);
        numberImage.gameObject.SetActive(false);
    }



    private void OnLeftClick()
    {
        manager.OpenCell(x, y);
    }

    public void ToggleFlag()
    {
        if (isOpened) return;

        isFlagged = !isFlagged;

        flagImage.SetActive(isFlagged);
    }

    public void Open()
    {
        if (isOpened || isFlagged)
            return;

        isOpened = true;

        button.interactable = false;

        if (isMine)
        {
            mineImage.SetActive(true);
            return;
        }

        if (nearbyMineCount > 0)
        {
            numberImage.gameObject.SetActive(true);

            numberImage.sprite =
                numberSprites[nearbyMineCount - 1];
        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Right)
        {
            ToggleFlag();
        }
        else if (eventData.button == PointerEventData.InputButton.Left)
        {
            manager.OpenCell(x, y);
        }
    }

}