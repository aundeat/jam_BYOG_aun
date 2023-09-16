using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float speedIncreaseRate = 2f; 
    [SerializeField] private float maxSpeed = 10f;
    [SerializeField] private bool canRun = false; 

    private bool isIncreasingSpeed;
    private float minSpeed;
    private Vector2 movement = Vector2.zero;

    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float decreaseSpeed = 2f;

 
    private bool isSitting = false;
    private void Start()
    {
        minSpeed = moveSpeed;
    }
    private void Update()
    {

        PlayerRun();
        PlayerMove();

    }
    private void PlayerRun()
    {
        if (canRun)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                isIncreasingSpeed = true;
            }
            else if (Input.GetKeyUp(KeyCode.Space))
            {
                isIncreasingSpeed = false;
            }
        }
    }
    private void PlayerRunLogic()
    {
        if (isIncreasingSpeed && moveSpeed < maxSpeed)
        {
            moveSpeed += speedIncreaseRate;
            isIncreasingSpeed = false;
        }
        else
        {
            if (moveSpeed > minSpeed)
                moveSpeed -= 0.1f;
        }
    }


    private void PlayerMove()
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
            PlayerRunLogic();
            movement = new Vector2(horizontalInput, verticalInput) * moveSpeed * Time.deltaTime;
            isSitting = false;
        }

        transform.Translate(movement);
    }
}
