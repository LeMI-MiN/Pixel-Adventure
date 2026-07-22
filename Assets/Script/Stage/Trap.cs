using UnityEngine;

public class Trap : MonoBehaviour
{
    // Rotation Chain
    [SerializeField]
    private float rotateSpeed = 60f;


private void Update()
    {
        // Rotate Chain
        transform.Rotate(0, 0, rotateSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Hit Log
        if (other.CompareTag("Player"))
        {
            Debug.Log("Hit");
        }

        // Hit
        PlayerController player = other.GetComponent<PlayerController>();

        if (player != null)
        {
            player.Hit();
        }
    }
}
