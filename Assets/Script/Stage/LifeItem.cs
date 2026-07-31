using UnityEngine;

public class LifeItem : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Player"))
            return;

        GameManager.Instance.AddLife();

        // Sound
        //SoundManager.Instance.Play1UP();

        Destroy(gameObject);
    }
}