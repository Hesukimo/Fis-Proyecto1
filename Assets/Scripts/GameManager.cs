using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public int ballAmount = 5;
    public int score = 0;
    private int bloquesIniciales = 0;
    private int winCon = 0; //Porcentaje necesario para ganar
    private int winCon2 = 50; //Porcentaje necesario para ganar tras matar el caballero

    [SerializeField] private TextMeshProUGUI resultText;
    [SerializeField] private TextMeshProUGUI bulletText;
    [SerializeField] private TextMeshProUGUI scoreText;

    [SerializeField] private ScriptMuro castillo;

    private void Awake()
    {
        instance = this;
        UpdateBulletText();
        score = castillo.VidaTotal();
        bloquesIniciales = score;
        scoreText.text = "BLOQUES RESTANTES: " + 100 + "%";
    }

    private void Update()
    {
        //Lose Condition
        if (ballAmount == 0)
        {
            if (FindAnyObjectByType<Pelota>() == null)
            {
                Finish(false);
            }
        }
    }

    public void Finish(bool win = true)
    {
        if (win) { resultText.text = "You killed the opposing prince and destroyed their house, winning back the kingdom, hooray!";  } else
        {
            resultText.text = "You ran out of budget for more cannonballs, oopsies :3!";
        }
        resultText.enabled = true;
    }

    public void UpdateBulletText()
    {
        bulletText.text = "MUNICIÓN: " + ballAmount;
    }

    public void RemoveBlock()
    {
        score--;
        int porcentaje = (int)CalculateScore();
        scoreText.text = "BLOQUES RESTANTES: " + porcentaje + "%";
        //Win Condition
        if (porcentaje <= winCon)
        {
            Finish();
        }
        Debug.Log(score);
    }

    public float CalculateScore()
    {
        return (score * 1f / bloquesIniciales * 1f) * 100;
    }

    public void KnightKilled()
    {
        winCon = winCon2;
        scoreText.color = Color.blue;
    }

}
