using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Vector3 offset;
    public float speed = 0.125f;
    private Transform player;
    public Vector3 velocity;
    // Start is called before the first frame update
    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        offset = transform.position - player.position;
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        MoveCamera();
    }

    private void MoveCamera()
    {
        if (player)
        {
            Vector3 newPos = player.position + offset;
            Vector3 smoothPost = Vector3.SmoothDamp(transform.position, new Vector3(newPos.x, transform.position.y, transform.position.z), ref velocity, speed);
            transform.position = smoothPost;
        }
    }
}
