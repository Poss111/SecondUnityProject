using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.EventSystems;

// Add on click behavior to object to randomly change color
public class GameBoard : MonoBehaviour, IPointerClickHandler
{

    public Sprite filledSprite;
    private SpriteRenderer spriteRenderer;
    public int gridX;
    public int gridY;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        if (spriteRenderer == null)
        {
            Debug.LogError("SpriteRenderer component not found on this GameObject.");
            return;
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
            // Change the sprite to the filled sprite
            spriteRenderer.sprite = filledSprite;
            // Optionally, you can also change the color
            // spriteRenderer.color = new Color(Random.value, Random.value, Random.value);
        }
        else
        {
            Debug.LogError("SpriteRenderer component not found on this GameObject.");
        }
        GameManager.Instance.FillBox(gridX, gridY, 1);
    }
}
