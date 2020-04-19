using UnityEngine;

public class GlassesShelf : MonoBehaviour
{
    [SerializeField] GameObject glasses;

    GameManager gameManager;
    SpriteRenderer spriteRenderer;

    [SerializeField] Sprite noGlassesCloset;

    [SerializeField] GameObject interactPopup;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        gameManager = FindObjectOfType<GameManager>();
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && gameManager.retrievedSunglasses == false)
        {
            interactPopup.SetActive(true);
        }
    }

    void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && gameManager.retrievedSunglasses == false && Input.GetKeyDown(KeyCode.F))
        {
            glasses.SetActive(true);
            spriteRenderer.sprite = noGlassesCloset;
            gameManager.retrievedSunglasses = true;
            interactPopup.SetActive(false);
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        interactPopup.SetActive(false);
    }
}
