using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueManager : MonoBehaviour
{/*
    public Text speakerNameText;
    public Text dialogueText;
    public GameObject choicesPanel;
    public Button[] choiceButtons;

    private Dialogue currentDialogue;
    private int currentChoiceIndex;

    public void StartDialogue(Dialogue dialogue)
    {
        currentDialogue = dialogue;
        speakerNameText.text = dialogue.speakerName;
        dialogueText.text = dialogue.dialogueText;
        choicesPanel.SetActive(false);
    }

    public void DisplayChoices()
    {
        if (currentDialogue.choices != null && currentDialogue.choices.Length > 0)
        {
            choicesPanel.SetActive(true);
            for (int i = 0; i < currentDialogue.choices.Length; i++)
            {
                choiceButtons[i].gameObject.SetActive(true);
                choiceButtons[i].GetComponentInChildren<Text>().text = currentDialogue.choices[i].choiceText;
                int index = i;
                choiceButtons[i].onClick.AddListener(() => OnChoiceSelected(index));
            }
        }
        else
        {
            EndDialogue();
        }
    }

    public void OnChoiceSelected(int choiceIndex)
    {
        currentChoiceIndex = choiceIndex;
        currentDialogue.choices[choiceIndex].onSelected.Invoke();
        EndDialogue();
    }

    public void EndDialogue()
    {
        currentDialogue.onDialogueEnd.Invoke();
        currentDialogue = null;
        choicesPanel.SetActive(false);
    }*/
}

