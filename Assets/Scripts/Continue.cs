using UnityEngine;

public class Continue : MonoBehaviour
{
    private GameManager gameManager;

    // Start is called before the first frame update
    private void Start()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    public void ContinueGame()
    {
        gameManager.Continue();
    }
    public void WithdrawTokens()
    {
        var tokens = gameManager.tokensCollected;

    }
}
