using UnityEngine;

public class RotateTrap : MonoBehaviour
{
    // Rotation Trap
    [SerializeField]
    private float rotateSpeed = 60f;

    private void Update()
    {
        // Rotate Trap
        transform.Rotate(0, 0, rotateSpeed * Time.deltaTime);
    }
}