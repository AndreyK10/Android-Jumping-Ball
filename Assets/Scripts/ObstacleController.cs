using UnityEngine;

public class ObstacleController : MonoBehaviour
{
    [SerializeField] private float obstacleSpeed = 10f;
    private void Update()
    {
        transform.position += Vector3.left * Time.deltaTime * obstacleSpeed;
    }
}
