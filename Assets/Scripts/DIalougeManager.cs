using UnityEngine;
using System.Collections.Generic;
using TMPro;
using System.Collections;

public class DIalougeManager : MonoBehaviour
{
    public static DIalougeManager Instance;

    public TextMeshProUGUI dialogueText;
    private Queue<DialogueLine> sentences;

    public bool isDialogueActive;
    public float typingSpeed = 0.2f;
    public GameObject dialoguePanel;
    private PlayerController playerController;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (Instance == null)
        {
            Instance = this;
        }

        sentences = new Queue<DialogueLine>();

        dialoguePanel.SetActive(false);

           playerController = FindObjectOfType<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartDialogue(Dialogue dialogue)
    {
       isDialogueActive = true;
        dialoguePanel.SetActive(true);

        if (playerController != null)
        {
            playerController.enabled = false;
        }


        sentences.Clear();

        foreach (DialogueLine dialogueLine in dialogue.dialogueLines)
        {
            sentences.Enqueue(dialogueLine);
        }
        DisplayNextDialogueLine();
    }

    public void DisplayNextDialogueLine()
    {
        if (sentences.Count == 0)
        {
            EndDialogue();
            return;
        }
        DialogueLine dialogueLine = sentences.Dequeue();
        dialogueText.text = dialogueLine.line;

        StopAllCoroutines();
        StartCoroutine(TypeSentence(dialogueLine));
    }

    IEnumerator TypeSentence(DialogueLine dialogueLine)
    { 
        dialogueText.text = "";
        foreach (char letter in dialogueLine.line.ToCharArray())
        {
            dialogueText.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }



    }


    void EndDialogue()
    {
        isDialogueActive = false;
        dialoguePanel.SetActive(false);
        playerController.enabled = true;
    }

   


}
