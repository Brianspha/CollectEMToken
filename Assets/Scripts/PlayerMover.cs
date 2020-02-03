using UnityEngine;
[RequireComponent(typeof(Rigidbody))]
public class PlayerMover : MonoBehaviour
{
    private Rigidbody player;
    public float speed = 40;
    public float fowardSpeed;
    public float startPosition;
    private Quaternion originalRotation;
    private GameManager gameManager;
    public bool started;
    // Start is called before the first frame update
    private void Start()
    {
        started = false;
        originalRotation = transform.rotation;
        player = GetComponent<Rigidbody>();
        gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        fowardSpeed = gameManager.GetPlayerSpeed();
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !started)
        {
            started = true;
            gameManager.DisableStartText();
        }
        if (started)
        {
            MovePlayer();
            MoveFoward();
        }
    }
    private void MoveFoward()
    {
        transform.position = new Vector3(player.position.x - fowardSpeed * Time.deltaTime, player.position.y, player.position.z);
    }
    private void MovePlayer()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            player.MovePosition(Vector3.MoveTowards(player.transform.position, transform.position + Vector3.back, speed * Time.fixedDeltaTime));
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            player.MovePosition(Vector3.MoveTowards(player.transform.position, transform.position + Vector3.forward, speed * Time.fixedDeltaTime));
        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            player.MovePosition(Vector3.MoveTowards(player.transform.position, transform.position + Vector3.left, speed * Time.fixedDeltaTime));
        }
    }
    public Quaternion GetPlayerRotation()
    {
        return originalRotation;
    }
}
