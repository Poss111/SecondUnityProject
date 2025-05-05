using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.EventSystems;

// Add on click behavior to object to randomly change color
public class GameBoard : MonoBehaviour, IPointerClickHandler
{

    public Sprite xSprite;
    public Sprite oSprite;
    private SpriteRenderer spriteRenderer;
    private Sprite originalSprite;
    public int gridX;
    public int gridY;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        if (spriteRenderer == null)
        {
            originalSprite = spriteRenderer.sprite;
            Debug.LogError("SpriteRenderer component not found on this GameObject.");
            return;
        }
    }

    public void Reset()
    {
        if (spriteRenderer != null)
        {
            // Reset the sprite to the original sprite
            spriteRenderer.sprite = originalSprite;
            // Reset the scale to the original size
            transform.localScale = new Vector3(3f, 3f, 1f);
        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        ChangeColor();
    }

    void ChangeColor()
    {
        if (spriteRenderer != null)
        {
            // Scale the game object to 0.65 times its original size
            transform.localScale = new Vector3(0.5f, 0.5f, 1f);
            int player = 1;
            // Change the sprite to the filled sprite
            if (GameManager.Instance.currentPlayer == PlayerEnum.PlayerX) 
            {
                Debug.Log("Player X clicked on grid: " + gridX + ", " + gridY);
                spriteRenderer.sprite = xSprite;
            }
            else if (GameManager.Instance.currentPlayer == PlayerEnum.PlayerO)
            {
                Debug.Log("Player O clicked on grid: " + gridX + ", " + gridY);
                spriteRenderer.sprite = oSprite;
                player = 2;
            }
            GameManager.Instance.FillBox(gridX, gridY, player);
            // Optionally, you can also change the color
            // spriteRenderer.color = new Color(Random.value, Random.value, Random.value);
        }
        else
        {
            Debug.LogError("SpriteRenderer component not found on this GameObject.");
        }
    }
}
