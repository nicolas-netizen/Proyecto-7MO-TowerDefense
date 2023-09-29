using UnityEngine;
using UnityEngine.UI;

public class CoinManager : MonoBehaviour
{
    public Text _coinText;
    private int _coins = 0;

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
        _coins += amount;
        UpdateUI();
    }
    public void UpdateUI()
    {
        _coinText.text = "Coins: " + _coins.ToString();
    }

    public void UpdateCoinText()
    {
        UpdateUI();
    }

    public void SubtractCoins(int amount)
    {
        if (_coins >= amount)
        {
            _coins -= amount;
        }
        else
        {
            Debug.Log("No tienes suficientes monedas.");
        }
    }
    public bool HasEnoughCoins(int amount)
    {
        return _coins >= amount;
    }
}
