using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public int ballAmount = 5;

    [SerializeField] private TextMeshProUGUI resultText;
    [SerializeField] private TextMeshProUGUI bulletText;

    private void Awake()
    {
        instance = this;
        UpdateBulletText();
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
        bulletText.text = "CANNONBALLS: " + ballAmount;
    }

}
