using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class QuestTarget
{
    public TargetType targetType;

    public int requiredNumber;
    public int currentNumber;

    public bool isComplete()
    {
        return (currentNumber >= requiredNumber);
    }

    public void enemyDestroyed()
    {
        if (targetType == TargetType.Kill)
        {
            currentNumber++;
        }
    }

    public void ItemCollected()
    {
        if (targetType == TargetType.Collection)
        {
            currentNumber++;
        }
    }
}

public enum TargetType
{
    Kill,
    Collection
}
