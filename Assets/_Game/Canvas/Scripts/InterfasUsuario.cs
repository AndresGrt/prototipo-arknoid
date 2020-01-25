using UnityEngine;
using UnityEngine.UI;
public class InterfasUsuario : MonoBehaviour
{
    public int score, life, level, randomPower, sumaBloques, numBalls;
    int bloques, blockLevel, rowBlocks;
    public bool saque; bool estado;
    public Data m_data;
    public GameObject startButton, menu;
    GameObject[] totalBalls;
    public Text publicScore, publicLevel, publicHighScore;
    public Image vida1, vida2, vida3;
    public Vector3 coordinates;
    private void Start()
    {
        m_data = GetComponent<Data>();
        life = 3; level = 1;
        menu.SetActive(true);
        GameObject go = Instantiate(Resources.Load("ballGrey"), new Vector3(
                   FindObjectOfType<PlayerController>().transform.position.x,
                   FindObjectOfType<PlayerController>().transform.position.y + 0.25f, 0),
                   this.transform.rotation) as GameObject;
        saque = true;
    }
    private void Update()
    {
        publicScore.text = "" + score;
        publicHighScore.text = "" + m_data.highScore;
        publicLevel.text = "" + level;
        totalBalls = GameObject.FindGameObjectsWithTag("Balls");
        numBalls = totalBalls.Length;
        PawerUps(); ScoringController(); LifeController(); StartingController();
        bloques = FindObjectOfType<LevelController>().numBloques;
        blockLevel = FindObjectOfType<LevelController>().typeOfBlock;
        rowBlocks = FindObjectOfType<LevelController>().lineH;
    }
    public void ScoringController()
    {
        m_data.LoadData();
        if (score > m_data.highScore) m_data.SaveData();
        if (score == sumaBloques) { Win(); }
        if (score > sumaBloques && bloques <= 0) { sumaBloques = score; }
    }
    public void LifeController()
    {
        switch (life)
        {
            case 3: vida3.enabled = true; vida2.enabled = true; vida1.enabled = true; break;
            case 2: vida3.enabled = false; vida2.enabled = true; vida1.enabled = true; break;
            case 1: vida3.enabled = false; vida2.enabled = false; vida1.enabled = true; break;
            case 0: vida3.enabled = false; vida2.enabled = false; vida1.enabled = false; break;
        }
        if (life < 0) { Misses(); }
        if (life > 3) { life = 3; }
    }
    public void Misses()
    {
        estado = false;
        if (!estado)
        {
            for (int i = 0; i < bloques; i++)
                Destroy(GameObject.FindGameObjectWithTag("bloque"));
            if (bloques <= 0)
            {
                sumaBloques = 0; score = 0; life = 3; level = 1;
                menu.SetActive(true);
                FindObjectOfType<LevelController>().typeOfBlock = 1;
                FindObjectOfType<LevelController>().lineH = 1;
                FindObjectOfType<LevelController>().Reset();
            }
        }
    }
    public void Win()
    {
        estado = true;
        if (estado)
        {
            for (int i = 0; i < totalBalls.Length; i++)
                Destroy(GameObject.FindGameObjectWithTag("Balls"));
            level += 1; life += 1; saque = true;
            FindObjectOfType<PowerUps>().numPower = 0;
            if (blockLevel < 6) FindObjectOfType<LevelController>().typeOfBlock += 1;
            if (rowBlocks < 10) FindObjectOfType<LevelController>().lineH += 1;
            FindObjectOfType<LevelController>().Reset();
        }
    }
    public void StartingController()
    {
        if (numBalls <= 0)
        {
            GameObject go = Instantiate(Resources.Load("ballGrey"), new Vector3(
                   FindObjectOfType<PlayerController>().transform.position.x,
                   FindObjectOfType<PlayerController>().transform.position.y + 0.25f, 0),
                   this.transform.rotation) as GameObject;
            life -= 1;
            saque = true;
        }
        if (saque)
        {
            startButton.SetActive(true);
            FindObjectOfType<MovementController>().velocity = 0;
            FindObjectOfType<PowerUps>().numPower = 0;
            FindObjectOfType<MovementController>().transform.position = new Vector3(
                FindObjectOfType<PlayerController>().transform.position.x,
                FindObjectOfType<PlayerController>().transform.position.y + 0.25f, 0);
        }
    }
    public void StartGame()
    {
        saque = false;
        startButton.SetActive(false);
        FindObjectOfType<MovementController>().power = false;
        FindObjectOfType<MovementController>().velocity =
            FindObjectOfType<MovementController>().saveSpeed;
    }
    public void StartMenu()
    {
        menu.SetActive(false);
    }
    public void PawerUps()
    {
        if (randomPower == 2) {
            GameObject go = Instantiate(Resources.Load("SpeedDown"), 
                coordinates, this.transform.rotation) as GameObject;
            randomPower = 0;
        }
        if (randomPower == 4) {
            GameObject go = Instantiate(Resources.Load("Catch"), 
                coordinates, this.transform.rotation) as GameObject;
            randomPower = 0;
        }
        if (randomPower == 6) {
            GameObject go = Instantiate(Resources.Load("Expand"), 
                coordinates, this.transform.rotation) as GameObject;
            randomPower = 0;
        }
        if (randomPower == 8) {
            GameObject go = Instantiate(Resources.Load("Disruption"), 
                coordinates, this.transform.rotation) as GameObject;
            randomPower = 0;
        }
        if (randomPower == 10) {
            GameObject go = Instantiate(Resources.Load("Laser"), 
                coordinates, this.transform.rotation) as GameObject;
            randomPower = 0;
        }
        if (randomPower == 12) {
            GameObject go = Instantiate(Resources.Load("PlayerExtend"), 
                coordinates, this.transform.rotation) as GameObject;
            randomPower = 0;
        }
    }
}