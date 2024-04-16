using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Ink.Runtime;
using UnityEngine.EventSystems;

public class DialogueManager : MonoBehaviour
{

    static DialogueManager instance;

    [SerializeField] GameObject dialoguePanel;
    [SerializeField] TextMeshProUGUI dialogueText;

    private Story currentStory;
    public bool dialogueIsPlaying { get; private set; }
    public bool makingChoice { get; private set; }

    [SerializeField] GameObject[] choices;
    private TextMeshProUGUI[] choicesText;

    bool buffer;
    public Door exit;

    void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public static DialogueManager GetInstance()
    {
        return instance;
    }

    // Start is called before the first frame update
    void Start()
    {

        dialoguePanel.SetActive(false);
        dialogueIsPlaying = false;
        makingChoice = false;

        // assigns each choicebox's text to a variable in an array to modify
        choicesText = new TextMeshProUGUI[choices.Length];
        int index = 0;
        foreach (GameObject choice in choices)
        {
            choicesText[index] = choice.GetComponentInChildren<TextMeshProUGUI>();
            index++;
        }

        if (GameObject.Find("Exit") != null) exit = GameObject.Find("Exit").GetComponent<Door>();

    }

    // Update is called once per frame
    void Update()
    {

        if(!dialogueIsPlaying) return;
        //if(Input.GetKeyDown(KeyCode.Space)) return;
   
        if(Input.GetKeyDown(KeyCode.Z) && !makingChoice)
        {
            ContinueStory();
        }

    }

    public void EnterDialogueMode(TextAsset inkJSON, bool cutscene)
    {

        currentStory = new Story(inkJSON.text);
        dialogueIsPlaying = true;
        dialoguePanel.SetActive(true);

        if (cutscene) ContinueStory();

    }

    IEnumerator ExitDialogueMode()
    {
        yield return new WaitForSeconds(0.3f);

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
                makingChoice = true;
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
        makingChoice = false;
        currentStory.ChooseChoiceIndex(choiceIndex);
        ContinueStory();
    }

    void HandleTags(List<string> currentTags)
    {
        foreach (string tag in currentTags)
        {
            if (tag == "ENDING" && exit != null) exit.SwitchDest("GameOverScene");
        }

    }

    void ContinueStory()
    {
        if (currentStory.canContinue)
        {
            dialogueText.text = currentStory.Continue();
            DisplayChoices();
            HandleTags(currentStory.currentTags);
        }
        else 
        {
            StartCoroutine(ExitDialogueMode());
        }
    }
}
