using UnityEngine;

public class TrapDamage : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        // Hit Log
        if (other.CompareTag("Player"))
        {
            PlayerController player = other.GetComponent<PlayerController>();

            if (player != null)
            {
                player.Hit();
            }
        }
    }
}
