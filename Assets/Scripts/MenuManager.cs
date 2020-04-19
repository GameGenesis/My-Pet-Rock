using UnityEngine.SceneManagement;
using UnityEngine;
using System.Collections;

public class MenuManager : MonoBehaviour
{
    [SerializeField] GameObject mainMenuButton;

    public void GoToScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void GoToScene(int buildIndex)
    {
        SceneManager.LoadScene(buildIndex);
    }

    public void OnQuit()
    {
        Application.Quit();
    }

    public void ContinueStory()
    {
        GetComponent<GameManager>().winScreen.SetActive(false);
        DialogueManager dialogueManager = FindObjectOfType<DialogueManager>();
        dialogueManager.AddDialogue("Good News: Two days later, your neighbor was found gobbled up by a rock.");
        dialogueManager.AddDialogueToQueue("It turns out that Tim was hungry for revenge and decided to eat your neighbor! O Tim!");
        StartCoroutine(MainMenu());
    }

    IEnumerator MainMenu()
    {
        yield return new WaitForSecondsRealtime(5);
        mainMenuButton.SetActive(true);
    }
}
