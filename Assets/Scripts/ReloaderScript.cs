using UnityEngine;

public class ReloaderScript : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Obstacle")
        {
            collision.gameObject.SetActive(false);
            SpawnController.Obstacles.Enqueue(collision.gameObject);
        }
    }
}
