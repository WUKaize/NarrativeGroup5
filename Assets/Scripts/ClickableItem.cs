using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

// Attach to any clickable prop in the scene (paper pieces, locks, letters)
// Requires a Collider2D on the same GameObject
public class ClickableItem : MonoBehaviour
{
    [SerializeField] private string itemName = "Name of this item";
    [SerializeField] private UnityEvent onClick;   // What happens when clicked

    // Small hover feedback so the player knows it is interactable
    private SpriteRenderer spriteRenderer;
    private Color originalColor;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        if (spriteRenderer != null)
            originalColor = spriteRenderer.color;
    }

    private void OnMouseEnter()
    {
        if (spriteRenderer != null)
            spriteRenderer.color = new Color(1f, 0.95f, 0.8f);   // Warm highlight
    }

    private void OnMouseExit()
    {
        if (spriteRenderer != null)
            spriteRenderer.color = originalColor;
    }

    private void OnMouseDown()
    {
        // Ignore clicks when the mouse is over UI
        if (EventSystem.current != null && EventSystem.current.IsPointerOverGameObject())
            return;

        Debug.Log("Clicked: " + itemName);
        onClick?.Invoke();
    }
}
