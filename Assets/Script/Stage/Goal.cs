using UnityEngine;

public class Goal : MonoBehaviour
{
    // Clear Panel
    [SerializeField]
    private GameObject clearPanel;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start()
    {
        
    }

    // Update is called once per frame
    private void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            clearPanel.SetActive(true);
            Time.timeScale = 0f;
        }
    }
}
