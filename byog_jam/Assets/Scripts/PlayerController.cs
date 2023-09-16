using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float decreaseSpeed = 2f;
    private Vector2 movement = Vector2.zero;
    public bool isSitting = false;

    private void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        if (Input.GetKey(KeyCode.LeftControl))
        {
            movement = new Vector2(horizontalInput, verticalInput) * ((moveSpeed * Time.deltaTime) / decreaseSpeed);
            isSitting = true;
        }
        else
        {
            movement = new Vector2(horizontalInput, verticalInput) * moveSpeed * Time.deltaTime;
            isSitting = false;
        }



        transform.Translate(movement);

    }
}
