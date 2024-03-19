using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Ink.Runtime;
using UnityEngine.EventSystems;

public class DialogueManager : MonoBehaviour
{

    [SerializeField] GameObject dialoguePanel;
    [SerializeField] TextMeshProUGUI dialogueText;

    private Story currentStory;
    public bool dialogueIsPlaying { get; private set; }

    [SerializeField] GameObject[] choices;
    private TextMeshProUGUI[] choicesText;

    bool buffer;

    // Start is called before the first frame update
    void Start()
    {

        dialoguePanel.SetActive(false);
        dialogueIsPlaying = false;

        // assigns each choicebox's text to a variable in an array to modify
        choicesText = new TextMeshProUGUI[choices.Length];
        int index = 0;
        foreach (GameObject choice in choices)
        {
            choicesText[index] = choice.GetComponentInChildren<TextMeshProUGUI>();
            index++;
        }

    }

    // Update is called once per frame
    void Update()
    {

        if(!dialogueIsPlaying) return;
        //if(Input.GetKeyDown(KeyCode.Space)) return;
   
        if(Input.GetKeyDown(KeyCode.Return))
        {
            ContinueStory();
        }

    }

    public void EnterDialogueMode(TextAsset inkJSON)
    {

        currentStory = new Story(inkJSON.text);
        dialogueIsPlaying = true;
        dialoguePanel.SetActive(true);

        ContinueStory();

    }

    IEnumerator ExitDialogueMode()
    {
        yield return new WaitForSeconds(0.2f);

        dialogueIsPlaying = false;
        dialoguePanel.SetActive(false);
        dialogueText.text = "";
    }

    void DisplayChoices()
    {

        List<Choice> currentChoices = currentStory.currentChoices;
        if (currentChoices.Count > choices.Length)
        {
            Debug.LogError("More choices than UI can suppport: " + currentChoices.Count + " > " + choices.Length);
        }

        int i = 0;
        /*foreach (Choice choice in currentChoices)
        {
            choices[index].GameObject.SetActive(true);
            choicesText[index].text = choice.text;
            i++;
        }*/

        foreach (GameObject choice in choices)
        {
            if (System.Array.IndexOf(choices, choice) < currentChoices.Count)
            {
                choices[i].gameObject.SetActive(true);
                choicesText[i].text = currentChoices[i].text;
            }
            else
            {
                choices[i].gameObject.SetActive(false);
            }
            i++;
        }

        StartCoroutine("SelectFirstChoice");

    }

    IEnumerator SelectFirstChoice()
    {
        EventSystem.current.SetSelectedGameObject(null);
        yield return new WaitForEndOfFrame();
        EventSystem.current.SetSelectedGameObject(choices[0].gameObject);
    }

    public void MakeChoice(int choiceIndex)
    {
        currentStory.ChooseChoiceIndex(choiceIndex);
    }

    void ContinueStory()
    {
        if (currentStory.canContinue)
        {
            dialogueText.text = currentStory.Continue();
            DisplayChoices();
        }
        else 
        {
            StartCoroutine(ExitDialogueMode());
        }
    }
}
