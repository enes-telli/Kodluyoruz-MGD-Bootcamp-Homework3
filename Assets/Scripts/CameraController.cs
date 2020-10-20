using UnityEngine;

public class CameraController : MonoBehaviour
{
    GameObject player;
    Vector3 offset;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        offset = transform.position - player.transform.position;
    }

    void LateUpdate()
    {
        transform.position = player.transform.position + offset;
    }
}
