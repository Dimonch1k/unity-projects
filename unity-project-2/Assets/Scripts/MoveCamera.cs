using UnityEngine;

public class MoveCamera : MonoBehaviour
{
    Transform player;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 cameraPosition = transform.position;
        cameraPosition.x = player.position.x;
        cameraPosition.y = player.position.y;
        transform.position = cameraPosition;
    }
}
