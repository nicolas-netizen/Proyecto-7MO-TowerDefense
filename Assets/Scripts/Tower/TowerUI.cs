using UnityEngine;
using System.Collections;

public class TowerUI : MonoBehaviour
{
    public SpriteRenderer priceSpriteRenderer1;
    public SpriteRenderer priceSpriteRenderer2;
    public Color canAffordColor = Color.green;
    public Color cannotAffordColor = Color.red;
    public float detectionRadius = 2f;

    private Tower tower;
    private bool canAfford = false;
    private bool playerInRange = false;
    private bool isTowerActive = false;

    private bool isFlashing = false;
    private Color originalColor;

    private void Start()
    {
        tower = GetComponent<Tower>();
        priceSpriteRenderer1.enabled = false;
        priceSpriteRenderer2.enabled = false;
        originalColor = priceSpriteRenderer1.color;
    }

    private void Update()
    {
        if (!isTowerActive)
        {
            if (Input.GetKeyDown(KeyCode.Q) && canAfford && playerInRange)
            {
                tower.ActivateTower();
                isTowerActive = true;
                HidePriceSprites();
            }
        }
        if (!canAfford && playerInRange && !isFlashing)
        {
            StartCoroutine(FlashSprite());
        }
    }

    private void HidePriceSprites()
    {
        priceSpriteRenderer1.enabled = false;
        priceSpriteRenderer2.enabled = false;
    }

    private IEnumerator FlashSprite()
    {
        isFlashing = true;
        while (!canAfford)
        {
            priceSpriteRenderer1.color = cannotAffordColor;
            priceSpriteRenderer2.color = cannotAffordColor;
            yield return new WaitForSeconds(0.5f);
            priceSpriteRenderer1.color = originalColor;
            priceSpriteRenderer2.color = originalColor;
            yield return new WaitForSeconds(0.5f);
        }
        isFlashing = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = true;
            if (!isTowerActive)
            {
                priceSpriteRenderer1.enabled = true;
                priceSpriteRenderer2.enabled = true;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = false;
            if (!isTowerActive)
            {
                priceSpriteRenderer1.enabled = false;
                priceSpriteRenderer2.enabled = false;
            }
        }
    }

    public void SetCanAfford(bool canAffordValue)
    {
        canAfford = canAffordValue;
    }
}
