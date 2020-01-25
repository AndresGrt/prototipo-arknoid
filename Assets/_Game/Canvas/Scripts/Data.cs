using UnityEngine;
public class Data : MonoBehaviour
{
    public int highScore;
    public void SaveData()
    {
        SetData();
        PlayerPrefs.SetInt("Score", highScore);
    }
    public void LoadData()
    {
        highScore =  PlayerPrefs.GetInt("Score");
    }
    public void SetData()
    {
        highScore = System.Convert.ToInt32(FindObjectOfType<InterfasUsuario>().score);
    }
}