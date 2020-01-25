using UnityEngine;
public class LevelController : MonoBehaviour
{
    [Header("Numero de filas")]public int lineH;
    [Header("Numero de columnas")]public int lineV;
    [Header("Tipos de bloques")]public int typeOfBlock;
    [Header("Numero de bloques")]public int numBloques;
    string nameAdobe; GameObject[] bloquesTotal; Adobes adobes;
    void Start () {
        for (int i = 0; i < lineV; i++)
        {
            for (int j = 0; j < lineH; j++)
            {
                adobes = (Adobes)Random.Range(0, typeOfBlock);
                switch (adobes)
                {
                    case Adobes.Adobe1: nameAdobe = "Adobe1"; FindObjectOfType<InterfasUsuario>().sumaBloques += 5; break;
                    case Adobes.Adobe2: nameAdobe = "Adobe2"; FindObjectOfType<InterfasUsuario>().sumaBloques += 10; break;
                    case Adobes.Adobe3: nameAdobe = "Adobe3"; FindObjectOfType<InterfasUsuario>().sumaBloques += 20; break;
                    case Adobes.Adobe4: nameAdobe = "Adobe4"; FindObjectOfType<InterfasUsuario>().sumaBloques += 50; break;
                    case Adobes.Adobe5: nameAdobe = "Adobe5"; FindObjectOfType<InterfasUsuario>().sumaBloques += 100; break;
                    case Adobes.Adobe6: nameAdobe = "Adobe6"; FindObjectOfType<InterfasUsuario>().sumaBloques += 500; break;
                }
                GameObject go = Instantiate(Resources.Load(nameAdobe), this.transform) as GameObject;
                go.transform.localPosition = new Vector2(i * 0.64f, j * 0.32f);
            }
        }
    }
    private void Update()
    {
        bloquesTotal = GameObject.FindGameObjectsWithTag("bloque");
        numBloques = bloquesTotal.Length;
    }
    public void Reset()
    {
        Start();
    }
}
enum Adobes
{
    Adobe1, Adobe2, Adobe3, Adobe4, Adobe5, Adobe6
}