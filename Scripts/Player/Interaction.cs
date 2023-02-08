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
                Debug.Log("Quest completed !");
                for (int i = 0; i < quest.questTarget.requiredNumber; i++)
                {
                    inventory.AddToInventory();
                }
                numberText.text = "Score: " + inventory.itemCount;
                isRewarded = true;
            }
        }
        if (Input.GetKeyDown(KeyCode.E) && isCloseItem)
        {
            inventory.AddToInventory();
            numberText.text = "Score: " + inventory.itemCount;
            
            
            Debug.Log("Interacted with a item!");
        }
        if (Input.GetKeyDown(KeyCode.E) && isCloseQuestBoard)
        {
            questGiver.ActiveQuestUI();
            Debug.Log("Interacted with the quest board!");
        }
        else if(Input.GetKeyDown(KeyCode.F) && isCloseQuestBoard)
        {
            questGiver.AcceptQuest();
        }
        //if (Input.GetKeyDown(KeyCode.E))
        //{
        //    NpcCollider.enabled = true;
        //    if (isCloseNPC)
        //    {
        //        dialogueTrigger.TriggerDialogue();
        //        Debug.Log("Interacted with a NPC!");
        //    }
        //}
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
            Debug.Log("Leaving the quest board collision checkbox!");
        }
    }



}
