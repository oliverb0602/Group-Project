using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class QuestTarget
{
    public int requiredNumber;
    public int currentNumber;

    public bool isComplete()
    {
        return (currentNumber >= requiredNumber);
    }

    public void enemyDestroyed()
    {
        currentNumber++;
    }
}
