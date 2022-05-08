using UnityEngine;

public class CameraController : MonoBehaviour
{
    Camera mainCamera;
    public GameObject player;
    [SerializeField] Vector3 offset;
    void Start()
    {
        mainCamera = GetComponent<Camera>();
        mainCamera.transform.position = new Vector3(player.transform.position.x, player.transform.position.y + 4.5f, player.transform.position.z - 7.5f);
        offset = new Vector3(0f, 5f, -9f);
    }

    void Update()
    {
        mainCamera.transform.position = new Vector3(0f, player.transform.position.y, player.transform.position.z) + offset;
    }
}
