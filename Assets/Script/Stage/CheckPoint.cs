using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    [SerializeField] private Animator animator;

    private bool isActive;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (isActive)
            return;

        if (!other.CompareTag("Player"))
            return;

        PlayerController player = other.GetComponent<PlayerController>();

        if (player == null)
            return;

        player.SetCheckpoint(transform.position);
        animator.SetTrigger("Active");
        isActive = true;
    }
}
