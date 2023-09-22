using UnityEngine;
using UnityEngine.UI;

public class CoinManager : MonoBehaviour
{
    public Text _coinText;
    private int _totalCoins = 0;

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
