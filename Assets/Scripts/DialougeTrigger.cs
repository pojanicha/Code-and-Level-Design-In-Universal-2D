using UnityEngine;
using System.Collections.Generic;



    [System.Serializable]
    public class DialogueLine
    {
        
        [TextArea(3, 10)]
        public string line;
    }

    [System.Serializable]
    public class Dialogue
    {
       public List<DialogueLine>  dialogueLines = new List<DialogueLine>();
    }
    
    public class DialougeTrigger : MonoBehaviour
    {
        public Dialogue dialogue;
    

    public void TriggerDialogue()
    {
        DIalougeManager.Instance.StartDialogue(dialogue);
    }


    private bool hasTriggered = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (hasTriggered) return;


        if (other.CompareTag("Player"))
        {
            hasTriggered = true;
            TriggerDialogue();
            gameObject.SetActive(false);
          
        }
    }



}




