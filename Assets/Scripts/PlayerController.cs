using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Vector2Int currentPosition = new Vector2Int(4, 4);
    private SpriteRenderer spriteRenderer;
    
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        UpdatePosition();
    }
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W) && currentPosition.y < 8)
        {
            currentPosition.y += 1;
            UpdatePosition();
        }
        if (Input.GetKeyDown(KeyCode.S) && currentPosition.y > 0)
        {
            currentPosition.y -= 1;
            UpdatePosition();
        }
        if (Input.GetKeyDown(KeyCode.D) && currentPosition.x < 8)
        {
            currentPosition.x += 1;
            UpdatePosition();
        }
        if (Input.GetKeyDown(KeyCode.A) && currentPosition.x > 0)
        {
            currentPosition.x -= 1;
            UpdatePosition();
        }
    }
    
    void UpdatePosition()
    {
        transform.position = new Vector3(currentPosition.x, currentPosition.y, 0);
    }
}
