using UnityEngine;

public class TokenCounter : MonoBehaviour
{
    private GameManager gameManager;
    public int requiredTokens;
    public int collected;
    public bool continueRequired, startCountDown;
    public float countDown, countDownMax = 3f;

    private void Start()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        requiredTokens = gameManager.levelCollectibleMin;
        collected = 0;
        countDown = countDownMax;
        continueRequired = false;
        startCountDown = false;
    }
    private void Update()
    {
        if (continueRequired && Input.GetKeyDown(KeyCode.Space))
        {
            Start();
            gameManager.Continue();
            gameManager.DisableContinueMenu();
            continueRequired = false;
        }
        if (startCountDown && countDown > 0)
        {
            countDown -= Time.deltaTime;
        }
        if (countDown < 0)
        {
            countDown = countDownMax;
            startCountDown = false;
            if (collected >= requiredTokens)
            {
                continueRequired = true;
                gameManager.ShowContinueMenu();
            }
            if (collected < requiredTokens)
            {
                gameManager.ShowGameOverMenu();
            }
        }
    }
    public void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Token"))
        {
            bool added = gameManager.UpdateCollectedTokens(other.gameObject.GetComponent<TokenIDGenerator>().GetTokenID());
            DestroyGameObject(other.gameObject);
            Debug.LogWarning("Collected: " + collected);
            startCountDown = true;
            if (added)
            {
                collected++;
            }

        }
        else
        {
            Debug.LogError("Collided With: " + other.gameObject.tag);
        }
    }
    public void DestroyGameObject(GameObject gameObject)
    {
        Destroy(gameObject, 0.1f);
    }
}
