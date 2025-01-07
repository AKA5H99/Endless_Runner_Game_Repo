using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [Header("Player Settings")]
    [SerializeField] float playerSpeedInBegining = 10;
    [SerializeField] float speedUpEffectTime = 15;
    public float MagnetEffectTime = 15;

    [Header("Item Spawning Settings")]
    public float ItemSpawningDelay = 2;


    [Header("Give Prefabs")]
    [SerializeField] Text coinText;
    [SerializeField] GameObject gameOverPanel;
    [SerializeField] GameObject SpeedUpIcon;
    [SerializeField] Text speedUpTimerText;


    //private values
    [HideInInspector] public float playerSpeed;
    private float currentPlayerSpeed, speedIncreasingValue = 0.1f;
    bool playerIsOnSpeedUpMode = false;
    int Coin = 0;



    private void Awake()
    {
        coinText.text = Coin.ToString();
        playerSpeed = playerSpeedInBegining;
        Time.timeScale = 1;
    }

    private void Update()
    {
        // if Player is on speedUp Mode reduce speedUp Effect time, when it gets 0 or less than 0, call disableSpeedUpMode() which disables the speedup mode
        if (playerIsOnSpeedUpMode)
        {
            speedUpEffectTime = speedUpEffectTime - 1 * Time.deltaTime;
            int x = (int)speedUpEffectTime;
            speedUpTimerText.text = x.ToString();

            if (speedUpEffectTime < 0)
            {
                disableSpeedUpMode();

            }
        }
        
    }
    public void IncreaseCoin()
    {
        Coin += 1;
        coinText.text = Coin.ToString();
        IncreasePlayerSpeed();
        reduceItemSpawningDelay();

    }

    void IncreasePlayerSpeed()
    {
        //increase players speed based on coin score
        currentPlayerSpeed = Coin * speedIncreasingValue;

        //if player is not on speedup mode increase player speed based on coin score
        if (!playerIsOnSpeedUpMode)
        {
            if (playerSpeedInBegining >= currentPlayerSpeed)
            {
                playerSpeed = playerSpeedInBegining;
            }
            else
            {
                playerSpeed = currentPlayerSpeed;

                if (speedIncreasingValue > 0.05f)
                {
                    speedIncreasingValue -= 0.0002f;
                }
            }
        }
        

    }

    void reduceItemSpawningDelay()
    {
        ItemSpawningDelay = ItemSpawningDelay - 0.002f;
    }


    #region PlayerSpeedUpMode
    //Enable speedup mode
    public void SpeedUpPlayer()
    {
        SpeedUpIcon.SetActive(true);
        playerSpeed += 5;
        speedUpEffectTime = 15;
        playerIsOnSpeedUpMode = true;
    }
    //Disable speedup mode
    private void disableSpeedUpMode()
    {
        SpeedUpIcon.SetActive(false);
        playerIsOnSpeedUpMode = false;
        IncreasePlayerSpeed();
    }
    #endregion


    public void GameOver()
    {
        gameOverPanel.SetActive(true);
        Time.timeScale = 0;
    }

    //Buttons
    public void On_Click_Restart()
    {
        SceneManager.LoadScene("GameScene");
    }

    public void On_Click_Quit()
    {
        Application.Quit();
    }

}
