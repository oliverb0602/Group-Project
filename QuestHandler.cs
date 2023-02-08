using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class QuestHandler
{
    public QuestTarget questTarget;

    public bool isActive;

    public string questName;
    [TextArea(3, 10)]
    public string questDescription;
    public int questReward;

    public void Completed()
    {
        isActive = false;

        Debug.Log("Quest Completed!");
    }
}
