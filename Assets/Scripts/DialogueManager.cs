using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    public static bool hasCompleted = false;

    public float typingSpeed = 0.02f;

    [SerializeField] GameObject background;
    [SerializeField] TextMeshProUGUI textDisplay;

    public List<string> sentences = new List<string>();
    int index;

    void Start()
    {
        if (hasCompleted)
        {
            sentences.Clear();
            return;
        }

        if (sentences.Count > 0)
        {
            background.SetActive(true);
            textDisplay.text = "";
            StartCoroutine(Type());
            Time.timeScale = 0;
        }
    }

    public void AddDialogueToQueue(string sentence)
    {
        sentences.Add(sentence);
    }

    public void AddDialogue(string sentence)
    {
        if (index <= sentences.Count)
        {
            background.SetActive(true);
            sentences.Add(sentence);

            if(index != 0)
                index++;

            textDisplay.text = "";
            StartCoroutine(Type());
            Time.timeScale = 0;
        }
    }

    void Update()
    {
        if (sentences.Count > 0)
        {
            if (textDisplay.text == sentences[index])
            {
                if (Input.anyKeyDown)
                {
                    if (index < sentences.Count - 1)
                    {
                        index++;
                        textDisplay.text = "";
                        StartCoroutine(Type());
                    }
                    else
                    {
                        background.SetActive(false);
                        textDisplay.text = "";
                        Time.timeScale = 1;
                        hasCompleted = true;
                    }
                }
            }
        }
    }

    IEnumerator Type()
    {
        foreach (char letter in sentences[index].ToCharArray())
        {
            textDisplay.text += letter;
            yield return new WaitForSecondsRealtime(typingSpeed);
        }
    }
}
