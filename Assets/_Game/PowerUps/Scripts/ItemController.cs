using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class ItemController : MonoBehaviour
{
    private float limiteyn, velocity;
    void Start () {
        limiteyn = -3.74f; velocity = 1f;
    }
	void Update () {
        transform.Translate(Vector2.down * (velocity * Time.deltaTime));
        if (transform.position.y <= limiteyn)
        {
            Destroy(this.gameObject);
        }
    }
}
