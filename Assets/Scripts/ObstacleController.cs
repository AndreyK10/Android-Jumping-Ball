using UnityEngine;

public class ObstacleController : MonoBehaviour
{
    [SerializeField] private float obstacleSpeed = 10f;
    void Update()
    {
        transform.position += Vector3.left * Time.deltaTime * obstacleSpeed;
    }
}
