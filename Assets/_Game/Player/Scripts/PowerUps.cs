using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUps : MonoBehaviour
{
    public int numPower;
    public bool activador;
    public float correT, maxT;
    public Sprite pl1;
    public Sprite pl2;
    public Sprite pl3;
    private void Update()
    {
        if (activador)
        {
            if (numPower == 4 || numPower == 1 || numPower == 2)
            {
                correT += Time.deltaTime;
                maxT = 5;
                if (correT >= maxT)
                {
                    GetComponent<CapsuleCollider2D>().size = new Vector2(1.04f, 0.24f);
                    GetComponent<SpriteRenderer>().sprite = pl1;
                    numPower = 0;
                    correT = 0;
                    activador = false;
                }
            }
            else
            {
                if (FindObjectOfType<InterfasUsuario>().numBalls >= 1)
                {
                    FindObjectOfType<MovementController>().velocity = FindObjectOfType<MovementController>().saveSpeed;
                    FindObjectOfType<MovementController>().power = false;
                }
                GetComponent<CapsuleCollider2D>().size = new Vector2(1.04f, 0.24f);
                GetComponent<SpriteRenderer>().sprite = pl1;
                correT = 0;
                activador = false;
            }
        }
    }
    public void Disruption()
    {
        if (activador)
        {
            GameObject go = Instantiate(Resources.Load("ballGrey"), new Vector3(0, 0, 0), transform.rotation) as GameObject;
            go.GetComponent<MovementController>().velocity = FindObjectOfType<MovementController>().saveSpeed;
            activador = false;
        }
    }
    public void Expand()
    {
        if (numPower == 2)
        {
            GetComponent<CapsuleCollider2D>().size = new Vector2(1.4f, 0.24f);
            GetComponent<SpriteRenderer>().sprite = pl2;
            activador = true;
        }
    }
    public void Catch()
    {
        if (numPower == 1)
        {
            GetComponent<CapsuleCollider2D>().size = new Vector2(1.04f, 0.24f);
            GetComponent<SpriteRenderer>().sprite = pl1;
        }
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "SpeedDown")
        {
            numPower = 4;
            activador = true;
            Destroy(col.gameObject);
        }
        if (col.gameObject.tag == "Catch")
        {
            numPower = 1;
            Catch();
            activador = true;
            Destroy(col.gameObject);
        }
        if (col.gameObject.tag == "Expand")
        {
            numPower = 2;
            Expand();
            Destroy(col.gameObject);
        }
        if (col.gameObject.tag == "Disruption")
        {
            numPower = 5;
            activador = true;
            Disruption();
            Destroy(col.gameObject);
        }
        if (col.gameObject.tag == "Laser")
        {
            Debug.Log("dispara rayos laser de la barra ");
            numPower = 3;
            Destroy(col.gameObject);
        }
        if (col.gameObject.tag == "PlayerExtend")
        {
            numPower = 6;
            if (FindObjectOfType<InterfasUsuario>().life < 3)
            {
                FindObjectOfType<InterfasUsuario>().life += 1;
            }
            Destroy(col.gameObject);
        }
    }
}