using UnityEngine;
using TMPro;
using System.IO;

public class MoneyManager : MonoBehaviour
{
    [Header("µ· UI")]
    public GameObject moneyCanvas;

    [Header("µ· ÅØ½ºÆ®")]
    public TextMeshProUGUI moneyText;

    private int moneyCount = 0;
    private string filePath;

    // 213¹øÂ° ÁÙ = ¹è¿­ ÀÎµ¦½º 212
    private const int targetLineIndex = 34;

    private void Start()
    {
        filePath = Path.Combine(Application.streamingAssetsPath, "money.txt");

        LoadMoneyFromLine();
        UpdateMoneyText();

        if (moneyCanvas != null)
            moneyCanvas.SetActive(moneyCount > 0);
    }

    public void AddMoney(int amount)
    {
        moneyCount += amount;

        if (moneyCanvas != null)
            moneyCanvas.SetActive(true);

        UpdateMoneyText();
        SaveMoneyToLine();
    }

    public bool UseMoney(int amount)
    {
        if (moneyCount < amount)
            return false;

        moneyCount -= amount;

        UpdateMoneyText();
        SaveMoneyToLine();

        return true;
    }

    private void LoadMoneyFromLine()
    {
        EnsureFileAndLines();

        string[] lines = File.ReadAllLines(filePath);
        string moneyLine = lines[targetLineIndex].Trim();

        if (int.TryParse(moneyLine, out int value))
            moneyCount = value;
        else
            moneyCount = 0;
    }

    private void SaveMoneyToLine()
    {
        EnsureFileAndLines();

        string[] lines = File.ReadAllLines(filePath);
        lines[targetLineIndex] = moneyCount.ToString();

        File.WriteAllLines(filePath, lines);
    }

    private void EnsureFileAndLines()
    {
        if (!File.Exists(filePath))
        {
            string[] newLines = new string[targetLineIndex + 1];

            for (int i = 0; i < newLines.Length; i++)
                newLines[i] = "0";

            File.WriteAllLines(filePath, newLines);
            return;
        }

        string[] lines = File.ReadAllLines(filePath);

        if (lines.Length <= targetLineIndex)
        {
            string[] newLines = new string[targetLineIndex + 1];

            for (int i = 0; i < newLines.Length; i++)
                newLines[i] = i < lines.Length ? lines[i] : "0";

            File.WriteAllLines(filePath, newLines);
        }
    }

    private void UpdateMoneyText()
    {
        if (moneyText != null)
            moneyText.text = moneyCount.ToString();
    }
}