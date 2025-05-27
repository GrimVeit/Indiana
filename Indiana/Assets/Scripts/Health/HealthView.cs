using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class HealthView : View
{
    [SerializeField] private GameObject healthDivisionPrefab;
    [SerializeField] private Transform content;

    private readonly List<GameObject> healthList = new();

    public void ChangeHealthCount(int currentHealth)
    {
        int currentCount = healthList.Count;

        if(currentHealth > currentCount)
        {
            for (int i = currentCount; i < currentHealth; i++)
            {
                var health = Instantiate(healthDivisionPrefab, content);
                healthList.Add(health);
            }
        }
        else if(currentHealth < currentCount)
        {
            for (int i = currentCount - 1; i >= currentHealth; i--)
            {
                Destroy(healthList[i]);
                healthList.RemoveAt(i);
            }
        }
    }
}
