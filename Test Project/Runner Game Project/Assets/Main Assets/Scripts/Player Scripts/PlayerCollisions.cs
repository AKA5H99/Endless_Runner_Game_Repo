using UnityEngine;

public class PlayerCollisions : MonoBehaviour
{

    MagnetEffectt magnetEffectt;
    GameManager gameManager;

    private void Start()
    {
        gameManager = FindAnyObjectByType<GameManager>();
        magnetEffectt = GetComponent<MagnetEffectt>();

    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            gameManager.GameOver();
            print("Game Over");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        switch (other.tag)
        {
            case "Coin":
                gameManager.IncreaseCoin();
                break;

            case "Magnet":
                magnetEffectt.enabled = true;
                gameManager.MagnetEffectTime = 15;
                break;

            case "SpeedUp":
                gameManager.SpeedUpPlayer();
                break;


            default:
                break;
        }

        Destroy(other.gameObject);
    }


}
