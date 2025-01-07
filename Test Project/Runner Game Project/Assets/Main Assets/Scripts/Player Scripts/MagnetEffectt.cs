using UnityEngine;
using UnityEngine.UI;

public class MagnetEffectt : MonoBehaviour
{
    [Header("Magnet Settings")]
    [SerializeField] float magnetRadius = 8f; // Radius within which coins will be attracted
    [SerializeField] float magnetStrength = 40f;// Strength of attraction

    public GameObject MagnetIcon;
    public Text magnetTimerText;
    GameManager gameManager;

    private void Start()
    {
        gameManager = FindAnyObjectByType<GameManager>();
    }
    private void OnEnable()
    {
        MagnetIcon.SetActive(true);
    }

    void Update()
    {
        int x = (int)gameManager.MagnetEffectTime; // float to int

        magnetTimerText.text = x.ToString();
        AttractCoins();

        gameManager.MagnetEffectTime = gameManager.MagnetEffectTime - 1*Time.deltaTime;

        if(gameManager.MagnetEffectTime < 0)
            DisableMagnet();
    }

    void AttractCoins()
    {
        // Detect all colliders in the magnet radius
        Collider[] coins = Physics.OverlapSphere(transform.position, magnetRadius);

        foreach (var coin in coins)
        {
            // Check if the object is a coin
            if (coin.CompareTag("Coin"))
            {
                // Attract the coin towards the player
                Vector3 direction = (transform.position - coin.transform.position).normalized;

                // Move the coin directly towards the player
                coin.transform.position = Vector3.MoveTowards(coin.transform.position, transform.position, magnetStrength * Time.deltaTime);

            }
        }
    }
    void DisableMagnet()
    {
        this.enabled = false;
        MagnetIcon.SetActive(false);
    }
}
