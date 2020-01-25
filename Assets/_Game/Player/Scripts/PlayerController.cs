using UnityEngine;
public class PlayerController : MonoBehaviour
{
    public float sencibilite;
    private float limit_X_Positive, limit_X_Negative;
    public Vector2 touchPositionsPlayer;
    private void Start()
    {
        limit_X_Positive = 1.8f; limit_X_Negative = -1.8f;
    }
    private void Update()
    {
        PlayerMovement(); PlayerLimit();
    }
    public void PlayerMovement()
    {
        if (Input.touchCount == 1)
        {
            Touch firstTouch = Input.GetTouch(0);
            if (firstTouch.phase == TouchPhase.Moved)
            {
                touchPositionsPlayer = Input.GetTouch(0).deltaPosition;
                transform.Translate((touchPositionsPlayer.x * sencibilite)*Time.deltaTime, 0, 0);
            }
        }
    }
    public void PlayerLimit()
    {
        if (this.transform.position.x > limit_X_Positive)
            this.transform.position = new Vector2(limit_X_Positive, this.transform.position.y);
        else if (this.transform.position.x < limit_X_Negative)
            this.transform.position = new Vector2(limit_X_Negative, this.transform.position.y);
    }
}
