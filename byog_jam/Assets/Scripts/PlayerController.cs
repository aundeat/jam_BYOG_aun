using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Animator animator;

    [SerializeField] private float speedIncreaseRate = 2f;
    [SerializeField] private float maxSpeed = 10f;
    [SerializeField] private bool canRun = false;

    private bool isIncreasingSpeed;
    private float minSpeed;
    private Vector2 movement = Vector2.zero;

    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float decreaseSpeed = 2f;

    private bool isSitting = false;
    private Rigidbody2D rb; 

    private void Start()
    {
        minSpeed = moveSpeed;
        rb = GetComponent<Rigidbody2D>(); 
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


        playerAnimation(horizontalInput, verticalInput);

        if (Input.GetKey(KeyCode.LeftControl))
        {
            movement = new Vector2(horizontalInput, verticalInput) * (moveSpeed / decreaseSpeed);
            isSitting = true;
        }
        else
        {
            PlayerRunLogic();
            movement = new Vector2(horizontalInput, verticalInput) * moveSpeed;
            isSitting = false;
        }

        rb.velocity = movement;
    }


    private void playerAnimation(float horizontalInput, float verticalInput)
    {
        animator.SetFloat("Horizontal", horizontalInput);
        animator.SetFloat("Vertical", verticalInput);
        animator.SetFloat("Speed", horizontalInput * horizontalInput + verticalInput * verticalInput);
    }
}
