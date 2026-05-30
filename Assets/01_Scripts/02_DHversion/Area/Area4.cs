using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class Area4 : Area
{
    public Player Player;

    public List<Area4Word> area4Words = new List<Area4Word>();

    private List<Area4Word> wordList = new();

    private readonly string[] answer = new[] { "S", "P", "A", "C", "E", "D" };

    public override void OnAreaExit(Collider2D other)
    {
        base.OnAreaExit(other);

        // TODO : 움직임 바뀌게 변경

        Player.SetIsVelocityMove(false);
    }

    public override void OnAreEnter(Collider2D other)
    {
        base.OnAreEnter(other);

        // TODO : 움직임 원복
        Player.SetIsVelocityMove(true);
    }

    public void AddWord(Area4Word word)
    {


        wordList.Add(word);

        if (wordList.Count >= 6)
        {
            if (CheckAnswer())
            {
                Goal.gameObject.SetActive(true);
                foreach(var w in area4Words)
                {
                    w.gameObject.SetActive(false);
                }
            }
            else
            {
                foreach (var w in wordList)
                {
                    w.gameObject.SetActive(true);
                }
                wordList.Clear();
            }
        }
        else
        {
            word.gameObject.SetActive(false);
        }
    }

    private bool CheckAnswer()
    {
        if (wordList.Count != answer.Length) return false;

        for (int i = 0; i < wordList.Count; i++)
        {
            if (wordList[i].Word != answer[i])
            {
                return false;
            }
        }

        return true;
    }
}
