using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class QuestGiver : MonoBehaviour
{
    public QuestHandler questHandler;
    public Interaction player;

    public GameObject questUI;
    public TextMeshProUGUI questNameText;
    public TextMeshProUGUI questDescriptionText;
    public TextMeshProUGUI questRewardText;

    //    public Player player;

    public void ActiveQuestUI()
    {
        questUI.SetActive(true);
        questNameText.text = questHandler.questName;
        questDescriptionText.text = questHandler.questDescription;
        questRewardText.text = "Quest Reward: " + questHandler.questReward.ToString() + " Score";

    }

    public void CloseQuestUI()
    {
        questUI.SetActive(false);
    }

    public void AcceptQuest()
    {
        CloseQuestUI();
        questHandler.isActive = true;
        player.quest = questHandler;
        Debug.Log("Quest accepted !");
    }
}
