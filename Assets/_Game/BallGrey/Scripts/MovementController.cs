using UnityEngine;
public class MovementController : MonoBehaviour
{
    public bool horizontal, vertical, power;
    public float saveSpeed, velocity;
    private float limitex1, limitex2, limitey1, limitey2;
    private void Start()
    {
        limitex1 = 2.2f; limitex2 = -2.2f;
        limitey1 = 3.75f; limitey2 = -3.75f;
        vertical = true;
        if (FindObjectOfType<PlayerController>().touchPositionsPlayer.x >= 0)
            horizontal = false;
        if (FindObjectOfType<PlayerController>().touchPositionsPlayer.x <= 0)
            horizontal = true;
    }
    void Update()
    {
        PLayBall();
    }
    public void PLayBall()
    {
        if (horizontal)
        {
            if (transform.position.x > limitex2)
            {
                transform.Translate(Vector2.left * (velocity * Time.deltaTime));
                if (transform.position.x <= limitex2) { horizontal = false; }
            }
        }
        else if (transform.position.x < limitex1)
        {
            transform.Translate(Vector2.right * (velocity * Time.deltaTime));
            if (transform.position.x >= limitex1) { horizontal = true; }
        }
        if (vertical)
        {
            if (transform.position.y < limitey1)
            {
                transform.Translate(Vector2.up * (velocity * Time.deltaTime));
                if (transform.position.y >= limitey1) { vertical = false; }
            }
        }
        else if (transform.position.y > limitey2)
        {
            transform.Translate(Vector2.down * (velocity * Time.deltaTime));
            if (transform.position.y <= limitey2)
            {
                vertical = true;
                Destroy(this.gameObject);
            }
        }
        if (FindObjectOfType<PowerUps>().numPower == 1)
        {
            PowerActive();
        }
        else if (FindObjectOfType<PowerUps>().numPower != 4 || FindObjectOfType<PowerUps>().activador == false)
        {
            power = false;
            velocity = saveSpeed;
        }
        if (FindObjectOfType<PowerUps>().activador && FindObjectOfType<PowerUps>().numPower == 4)
        {
            velocity = 1f;
        }
    }
    public void PowerActive()
    {
        if (power)
        {
            velocity = 0;
            FindObjectOfType<InterfasUsuario>().startButton.SetActive(true);
            this.transform.position = new Vector3(
                FindObjectOfType<PlayerController>().transform.position.x,
                FindObjectOfType<PlayerController>().transform.position.y + 0.25f, 0);
        }
    }
    private void OnTriggerEnter2D(Collider2D choque)
    {
        if ((choque.gameObject.name == "Player") || (choque.gameObject.tag == "bloque"))
        {
            float direccion_y = transform.position.y - choque.transform.position.y;
            float direccion_x = transform.position.x - choque.transform.position.x;
            if (direccion_y > 0) vertical = true;
            else vertical = false;
            if (direccion_x > 0) horizontal = false;
            else horizontal = true;
        }
        if (choque.gameObject.name == "Player"&& FindObjectOfType<PowerUps>().numPower == 1)
        {
            power = true;
        }
    }
}