using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEditor;



public class DialogueManager : MonoBehaviour
{

    [Header("UI")]
    public GameObject dialogueBox;
    public TextMeshProUGUI dialogueName;
    public TextMeshProUGUI dialogueText;

    [Header("Dialogue")]
    public DialogueAssets dialogueAssets;
    public int dialogueOneIndex = 0;
    public int dialogueTwoIndex = 0;

    public bool isDialogueOne;
    public bool isDialogueTwo;




    // Start is called before the first frame update
    void Start()
    {
        StartDialogueOne();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void NextDialogue()
    {
        if (isDialogueOne)
        {
            if (dialogueOneIndex >= dialogueAssets.dialogueTexts[0].sentences.Length - 1)
            {
                dialogueBox.SetActive(false);
                return;
            }
            dialogueOneIndex++;
            isDialogueOne = false;
            isDialogueTwo = true;
            SetDialogue();
        }
        else if (isDialogueTwo)
        {
            if (dialogueTwoIndex >= dialogueAssets.dialogueTexts[1].sentences.Length - 1)
            {
                dialogueBox.SetActive(false);
                return;
            }
            dialogueTwoIndex++;
            isDialogueTwo = false;
            isDialogueOne = true;
            SetDialogue();
        }
    }

    public void StartDialogueOne()
    {
        dialogueBox.SetActive(true);
        dialogueName.text = dialogueAssets.dialogueTexts[dialogueOneIndex].name;
        dialogueText.text = dialogueAssets.dialogueTexts[dialogueOneIndex].sentences[0];
        isDialogueOne = true;
    }

    private void SetDialogue()
    {
        if(isDialogueOne)
        {
            dialogueName.text = dialogueAssets.dialogueTexts[0].name;
            dialogueText.text = dialogueAssets.dialogueTexts[0].sentences[dialogueOneIndex];
        }
        else if(isDialogueTwo)
        {
            dialogueName.text = dialogueAssets.dialogueTexts[1].name;
            dialogueText.text = dialogueAssets.dialogueTexts[1].sentences[dialogueTwoIndex];
        }
    }





}
