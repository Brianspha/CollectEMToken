using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private int requiredTokensLevel;
    private int level;
    public int levelCollectibleMin = 5;
    public List<int> tokensCollected;
    public Text levelText, requiredText, collectedText;
    private PlayerMover player;
    public GameObject playerObject, startText, pauseMenu, gameOverMenu,continueMenu;
    private int currentSpawnablePlatforms;
    private int spawnableIncrementor;
    public float playerSpeed = 13;
    private PlatformSpawner platformSpawner;
    // Start is called before the first frame update
    private void Start()
    {
        level = 1;
        spawnableIncrementor = 2;
        currentSpawnablePlatforms = 5;
        tokensCollected = new List<int>();
        IncrementLevelRequiredTokens();
        playerObject = GameObject.FindGameObjectWithTag("Player");
        player = playerObject.GetComponent<PlayerMover>();
        platformSpawner = GameObject.FindGameObjectWithTag("PlatformSpawner").GetComponent<PlatformSpawner>();
        UpdateUI();
        DisableGameOverMenu();
        DisablePauseMenu();
        DisableContinueMenu();
    }
    private void Update()
    {

    }
    private void UpdateUI()
    {
        levelText.text = level.ToString();
        requiredText.text = requiredTokensLevel.ToString();
    }

    public bool UpdateCollectedTokens(int tokenID)
    {
        Debug.LogWarning("Attempting to add token with ID: " + tokenID);
        if (!tokensCollected.Contains(tokenID))
        {
            tokensCollected.Add(tokenID);
            Debug.LogWarning("Collected Token With ID: " + tokenID);
            collectedText.text = tokensCollected.Count.ToString();
            return true;
        }
        else
        {
            Debug.LogError("Total Collected Tokens: " + tokensCollected.Count);
            Debug.LogError("Level: " + level);
            Debug.LogError("Required Token Count for Level: " + requiredTokensLevel);
            return false;
        }

    }
    public void Continue()
    {
        level++;
        int nextLevelPlatformCount = (int)((level * levelCollectibleMin) - (level * levelCollectibleMin) * .2);
        IncrementLevelRequiredTokens();
        platformSpawner.SpawnPlatforms(nextLevelPlatformCount);
        playerObject.transform.position = platformSpawner.GetNextLevelStart();
        playerObject.transform.rotation = player.GetPlayerRotation();
        UpdateUI();
        playerObject.SetActive(true);
    }

    public void Restart()
    {
        Start();
        platformSpawner.SpawnPlatforms(levelCollectibleMin);


    }
    private void IncrementLevelRequiredTokens()
    {
        requiredTokensLevel = level * levelCollectibleMin;
    }
    public int GetCurrentSpawnable()
    {
        if (currentSpawnablePlatforms == 0)
        {
            Start();
        }
        return currentSpawnablePlatforms * level;
    }
    public int GetLevel()
    {
        if (currentSpawnablePlatforms == 0)
        {
            Start();
        }
        return level;
    }
    public int GetNextLevelSpawnable()
    {
        if (currentSpawnablePlatforms == 0)
        {
            Start();
        }
        return (level + 1) * GetCurrentSpawnable();
    }
    public float GetPlayerSpeed()
    {
        return playerSpeed;
    }
    public void DisableStartText()
    {
        startText.gameObject.SetActive(false);
    }
    public void ShowGameOverMenu()
    {
        gameOverMenu.SetActive(true);
    }
    public void ShowContinueMenu()
    {
        continueMenu.SetActive(true);
    }
    public void ShowPauseMenu()
    {
        pauseMenu.SetActive(true);
    }
    public void DisablePauseMenu()
    {
        pauseMenu.SetActive(false);
    }
    public void DisableGameOverMenu()
    {
        gameOverMenu.SetActive(false);
    }
    public void DisableContinueMenu()
    {
        continueMenu.SetActive(false);
    }
}
