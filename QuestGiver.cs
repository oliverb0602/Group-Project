using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Linq;

public class QuestGiver : MonoBehaviour
{
    public QuestHandler questHandler;
    public Interaction player;

    public GameObject questUI;
    public TextMeshProUGUI questNameText;
    public TextMeshProUGUI questDescriptionText;
    public TextMeshProUGUI questRewardText;

    public void ActiveQuestUI()
    {

        Time.timeScale = 0;
            questNameText.text = questHandler.questName;
            questDescriptionText.text = questHandler.questDescription;
            questRewardText.text = "Quest Reward: " + questHandler.questReward.ToString() + " Score";
 
        questUI.SetActive(true);

    }

    public void CloseQuestUI()
    {
        Time.timeScale = 1;
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
