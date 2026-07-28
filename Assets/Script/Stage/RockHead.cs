using UnityEngine;
using System.Collections;

public class RockHead : MonoBehaviour
{
    // Targeting
    [Header("Target")]
    [SerializeField] private Transform player;

    // Moving
    [Header("Move")]
    [SerializeField] private float detectRange = 2f;
    [SerializeField] private float fallSpeed = 8f;
    [SerializeField] private float returnSpeed = 2f;
    [SerializeField] private float waitTime = 1f;

    private Vector3 startPos;
    private bool isMoving;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start()
    {
        startPos = transform.position;
    }

    // Update is called once per frame
    private void Update()
    {
        if (isMoving)
            return;

        if (Mathf.Abs(player.position.x - transform.position.x) < detectRange && player.position.y < transform.position.y)
        {
            StartCoroutine(Attack());
        }
    }

    IEnumerator Attack()
    {
        isMoving = true;
        Vector3 downPos = startPos + Vector3.down * 5f;

        while (Vector3.Distance(transform.position, downPos) > 0.05f)
        {
            transform.position = Vector3.MoveTowards(transform.position, downPos, fallSpeed * Time.deltaTime);

            yield return null;
        }

        yield return new WaitForSeconds(waitTime);

        while (Vector3.Distance(transform.position, startPos) > 0.05f)
        {
            transform.position = Vector3.MoveTowards(transform.position, startPos, returnSpeed * Time.deltaTime);

            yield return null;
        }

        transform.position = startPos;
        isMoving = false;
    }
}
