using System.Collections;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float maxSpeed;
    [SerializeField] private float jumpForce;
    public static bool isShieldOn;

    private CharacterController characterController;
    private Vector3 moveDirection;

    private MoveLine lineToMove = MoveLine.Middle;

    [SerializeField] private float distanceBetweenLines;
    private PlayerAnimationController playerAnimation;
    [SerializeField] private float shootDistanse;
    public CapsuleCollider collider;
    public GameManager gameManager;


    private void Start()
    {
        characterController = GetComponent<CharacterController>();
        playerAnimation = GetComponentInChildren<PlayerAnimationController>();
        moveDirection = Vector3.zero;
        collider = GetComponent<CapsuleCollider>();
        isShieldOn = false;
        speed = 0;
    }

    private void SwipeCheck()
    {
        if (SwipeController.SwipeLeft && lineToMove != MoveLine.Left)
        {
            lineToMove--;
        }
        else if (SwipeController.SwipeRight && lineToMove != MoveLine.Right)
        {
            lineToMove++;
        }
        else if (SwipeController.SwipeUp && characterController.isGrounded)
        {
            Jump();
        }
        else if (SwipeController.SwipeDown)
        {
            StartCoroutine(Scroll());
        }
        else if (SwipeController.Tap)
        {
            Shoot();
        }
    }
    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.gameObject.CompareTag("Obstacle")  && !isShieldOn)
        {
            gameManager.FinishGame();
            HitSoundController.OnHit?.Invoke();
        }
        else if (hit.gameObject.CompareTag("Enemy"))
        {
            gameManager.FinishGame();
        }
       
    }
   
    private Vector3 CalculateDirection()
    {
        Vector3 targetPosition = transform.position.z * transform.forward + transform.position.y * transform.up;

        if (lineToMove == MoveLine.Left)
        {
            targetPosition += Vector3.left * distanceBetweenLines;
        }
        else if (lineToMove == MoveLine.Right)
        {
            targetPosition += Vector3.right * distanceBetweenLines;
        }

        Vector3 difference = targetPosition - transform.position; 
        Vector3 direction = difference.normalized * 25 * Time.deltaTime;

        return (direction.magnitude < difference.magnitude) ? direction : difference;
    }
    private void Update()
    {
        if (GameManager.IsGameStarted)
        {
            speed = 5;
        }
        SwipeCheck();
        characterController.Move(CalculateDirection());
    }

    private void FixedUpdate()
    {
        moveDirection.z = speed;
        moveDirection.y += Physics.gravity.y * Time.fixedDeltaTime;
        characterController.Move(moveDirection * Time.fixedDeltaTime);
    }

    private void Jump()
    {
        moveDirection.y = jumpForce;
        playerAnimation.Jump();
    }
    private IEnumerator Scroll()
    {
        collider.center = new Vector3(0, 0.27f, 0);
        collider.height = 0.9f;
        playerAnimation.Roll();
        characterController.center = new Vector3(0, 0.27f, 0);
        characterController.height = 0.9f;
        yield return new WaitForSeconds(1);

        collider.center = new Vector3(0, 0.73f, 0);
        collider.height = 1.7f;
        characterController.center = new Vector3(0, 0.73f, 0);
        characterController.height = 1.7f;
    }

    private IEnumerator SpeedIncrease()
    {
        yield return new WaitForSeconds(5);
        if (speed < maxSpeed)
        {
            speed += 1;
            StartCoroutine(SpeedIncrease());
        }
    }
    private void Shoot()
    {
        if (GameManager.IsGameStarted)
        {
            Ray ray = new Ray(transform.position, transform.forward);
            RaycastHit hit;
            Debug.DrawRay(transform.position, 100 * Vector3.forward, Color.red);
            if (Physics.Raycast(ray, out hit, shootDistanse))
            {
                if (hit.collider.gameObject.GetComponent<Enemy>())
                {
                    hit.collider.gameObject.GetComponent<Enemy>().Shoot();
                }
            }
        }
    }
}

