using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Place in any object that will trigger dialogue
/// </summary>
public class DialogueTrigger : MonoBehaviour
{
    PlayerManager playerManager;
    [Tooltip("Determines if dialogue starts from a collision or player interaction.")]
    [SerializeField] public bool collisionTrigger;
    [Tooltip("The conversation that starts when triggered.")]
    [SerializeField] public Conversation conversation;
    [SerializeField] public bool ally;
    private void Start()
    {
        playerManager = GameObject.Find("Player").GetComponent<PlayerManager>();
    }
    private void OnTriggerEnter2D(Collider2D collision) 
    {
        if (collision.CompareTag("Player"))
        {
            playerManager.playerInteract.SetInDialogueTrigger(true);
            playerManager.playerInteract.SetDialogueTrigger(this);               
            if(ally)
            {
                gameObject.GetComponentInChildren<Renderer>().sharedMaterial.SetFloat("_OutlineThickness", 1);
            }
            if(collisionTrigger) 
            {
 
                conversation.StartConversation();
                // freezes player until dialogue is finished
                playerManager.playerInteract.SetInConversation(true);
                playerManager.playerRB.velocity = Physics2D.gravity;
            }
        }
            
      
    }
    private void OnTriggerExit2D(Collider2D collision) 
    {
        if (collision.CompareTag("Player"))
        {
            if (ally)
            {
                Debug.Log(gameObject.GetComponentInChildren<Renderer>());
                gameObject.GetComponentInChildren<Renderer>().sharedMaterial.SetFloat("_OutlineThickness", 0);
            }
            playerManager.playerInteract.SetInDialogueTrigger(false);
            playerManager.playerInteract.SetDialogueTrigger(null);
        }
            
    }

}
