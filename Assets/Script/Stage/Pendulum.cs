using UnityEngine;

public class Pendulum : MonoBehaviour
{
    [SerializeField] private float swingAngle = 60f;
    [SerializeField] private float swingSpeed = 2f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start()
    {
        
    }

    // Update is called once per frame
    private void Update()
    {
        float angle = Mathf.Sin(Time.time * swingSpeed) * swingAngle;
        transform.localRotation = Quaternion.Euler(0, 0, angle);
    }
}
