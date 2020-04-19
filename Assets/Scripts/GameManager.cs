using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [HideInInspector] public bool retrievedSunglasses;
    public GameObject winScreen;

    bool hasEnded;

    public void WinGame()
    {
        if (!hasEnded)
        {
            winScreen.SetActive(true);
            hasEnded = true;
        }
    }

    public void EndGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
