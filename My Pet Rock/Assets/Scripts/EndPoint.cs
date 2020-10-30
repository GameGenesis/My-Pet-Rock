using UnityEngine;

public class EndPoint : MonoBehaviour
{
    GameManager gameManager;
    [SerializeField] GameObject interactPopup;

    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && gameManager.retrievedSunglasses)
        {
            interactPopup.SetActive(true);
        }
    }

    void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && gameManager.retrievedSunglasses)
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                gameManager.WinGame();
            }
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        interactPopup.SetActive(false);
    }
}
