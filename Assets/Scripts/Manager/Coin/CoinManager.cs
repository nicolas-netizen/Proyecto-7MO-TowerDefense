using UnityEngine;
using UnityEngine.UI;

public class CoinManager : MonoBehaviour
{
    public Text _coinText;
    private int _totalCoins = 0;

    public static CoinManager Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    void Start()
    {
        UpdateUI();
    }

    public void AddCoins(int amount)
    {
        _totalCoins += amount;
        UpdateUI();
    }

    private void UpdateUI()
    {
        _coinText.text = "Coins: " + _totalCoins.ToString();
    }
}
