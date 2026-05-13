using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public int ballAmount = 5;
    public int score = 0;

    [SerializeField] private TextMeshProUGUI resultText;
    [SerializeField] private TextMeshProUGUI bulletText;
    [SerializeField] private TextMeshProUGUI scoreText;

    private void Awake()
    {
        instance = this;
        UpdateBulletText();
        AddScore(0);
    }

    private void Update()
    {
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
        if (win) { resultText.text = "You killed the opposing prince and won back the kingdom, hooray!";  } else
        {
            resultText.text = "You ran out of budget for more cannonballs, oopsies :3!";
        }
        resultText.enabled = true;
    }

    public void UpdateBulletText()
    {
        bulletText.text = "MUNICIÓN: " + ballAmount;
    }

    public void AddScore(int amount)
    {
        score += amount;
        scoreText.text = "PUNTUACIÓN: " + score;
    }

}
