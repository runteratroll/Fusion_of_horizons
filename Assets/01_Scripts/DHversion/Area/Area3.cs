using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class Area3 : Area
{
    public List<Costumes> costumes = new();

    public void SelectCostume(Costumes costume)
    {
        costumes.Add(costume);

        if (costumes.Count >= 3)
        {
            if (CheckClear())
            {
                costume.gameObject.SetActive(false);
                Goal.gameObject.SetActive(true);
            }
            else
            {
                ResetCostume();
            }
        }
        else
        {
            costume.gameObject.SetActive(false);
        }
    }

    public void ResetCostume()
    {
        foreach (var costume in costumes)
        {
            costume.gameObject.SetActive(true);
        }

        costumes.Clear();
    }

    private bool CheckClear()
    {
        for (int i = 0; i < costumes.Count; i++)
        {
            if (costumes[i].Order != i)
            {
                return false;
            }
        }

        return true;
    }
}
