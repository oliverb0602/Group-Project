using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Interaction : MonoBehaviour
{
    private DialogueTrigger dialogueTrigger;
    public QuestGiver questGiver;
    public QuestHandler quest;
    public Collider collectable;
    public TextMeshProUGUI numberText;
    public Game game;
    public GameObject questCompleteUI;

    bool isCloseItem;
    bool isCloseNPC;
    bool isCloseQuestBoard;
    bool isRewarded = false;

    //public BoxCollider NpcCollider;

    Inventory inventory = new Inventory();
    private void Update()
    {
        if(quest.isActive)
        {
            if(quest.questTarget.isComplete() && isRewarded == false)
            {
                questCompleteUI.SetActive(true);
                quest.Completed();
                StartCoroutine(Delay());
                for (int i = 0; i < quest.questTarget.requiredNumber; i++)
                {
                    inventory.AddToInventory();
                }
                numberText.text = "Item Name: " + inventory.itemCount;
                isRewarded = true;
            }
        }
        if (Input.GetKeyDown(KeyCode.E) && isCloseItem)
        {
            inventory.AddToInventory();
            numberText.text = "Item Name: " + inventory.itemCount;
            quest.questTarget.ItemCollected();
            
            
            Debug.Log("Interacted with a item!");
        }
        if (Input.GetKeyDown(KeyCode.E) && isCloseQuestBoard)
        {
            questGiver.ActiveQuestUI();
            Debug.Log("Interacted with the quest board!");
        }
        else if(questGiver.questUI.activeInHierarchy)
        {
            if (Input.GetKeyDown(KeyCode.F) && isCloseQuestBoard)
            {
                questGiver.AcceptQuest();
            }
        }
        if (Input.GetKeyDown(KeyCode.E) && isCloseNPC)
        {
            dialogueTrigger.TriggerDialogue();
            Debug.Log("Interacted with a NPC!");
            
        }
        else if (Input.GetKeyDown(KeyCode.F) && isCloseNPC)
        {
            dialogueTrigger.NextDialogue();
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        //interaction with collectables
        if(other.gameObject.tag == "Collectable")
        {
            isCloseItem = true;
            Debug.Log("Collision with item find!");
        }
        //interaction with npc
        if(other.gameObject.tag == "NPC")
        {
            isCloseNPC = true;
            //get the game object of the interacted npc
            dialogueTrigger = other.GetComponent<DialogueTrigger>();
            Debug.Log("Collision with npc find!");
        }
        if(other.gameObject.tag == "QuestBoard")
        {
            isCloseQuestBoard = true;
            Debug.Log("Collision with quest board find!");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Collectable")
        {
            isCloseItem = false;
            Debug.Log("Leaving the item collision checkbox!");
        }
        if (other.gameObject.tag == "NPC")
        {
            isCloseNPC = false;
            //NpcCollider.enabled = false;
            dialogueTrigger.EndDialogue();
            
            Debug.Log("Leaving the NPC collision checkbox!");
        }
        if(other.gameObject.tag == "QuestBoard")
        {
            isCloseQuestBoard = false;
            questGiver.CloseQuestUI();
            game.escPressed++;
            Debug.Log("Leaving the quest board collision checkbox!");
        }
    }

    IEnumerator Delay()
    {
        yield return new WaitForSeconds(3);
        questCompleteUI.SetActive(false);
    }

}
