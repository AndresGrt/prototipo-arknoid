using UnityEngine;
public class PointTotalBloques : MonoBehaviour
{
    public int puntos, numGolpes;
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.GetComponent<MovementController>())
        {
            numGolpes -= 1;
            if (numGolpes <= 0)
            {
                FindObjectOfType<InterfasUsuario>().randomPower = Random.Range(0, 14);
                FindObjectOfType<InterfasUsuario>().coordinates = transform.position;
                FindObjectOfType<InterfasUsuario>().score += puntos;
                Destroy(this.gameObject);
            }
        }
    }
}