using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using Cinemachine;

public class PlayerController : MonoBehaviour
{
    public static PlayerController instance;

    public float moveSpeed = 1f;
    public float collisionOffset = 0.05f;
    public ContactFilter2D movementFilter;

    private Vector2 moveInput;
    private List<RaycastHit2D> castCollisions = new List<RaycastHit2D>();
    private Rigidbody2D rb;
    private Animator animator;
    float horizontal;
    public float speed;
    float jumpForce = 5;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
            SceneManager.sceneLoaded += OnSceneLoaded; // Subscribe to sceneLoaded event
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void OnDestroy()
    {
        if (instance == this)
        {
            SceneManager.sceneLoaded -= OnSceneLoaded; // Unsubscribe from sceneLoaded event
        }
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        AssignVirtualCamera(); // Reassign the camera target when the scene is loaded
    }

    public void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        AssignVirtualCamera();
    }

    void AssignVirtualCamera()
    {
        // Virtual Camera'yý bul ve hedefini ayarla
        var virtualCamera = FindObjectOfType<CinemachineVirtualCamera>();

        if (virtualCamera != null)
        {
            virtualCamera.Follow = transform;
            virtualCamera.LookAt = transform;
            Debug.Log("Virtual Camera target reassigned to player.");
        }
        else
        {
            Debug.LogError("Virtual Camera not found.");
        }
    }

    public void FixedUpdate()
    {
        if (moveInput != Vector2.zero)
        {
            horizontal = Input.GetAxisRaw("Horizontal");
            rb.velocity = new Vector3(horizontal * Time.deltaTime * speed, rb.velocity.y, 0);

            bool success = MovePlayer(moveInput);

            if (!success)
            {
                success = MovePlayer(new Vector2(moveInput.x, 0));

                if (!success)
                {
                    success = MovePlayer(new Vector2(0, moveInput.y));
                }
            }

            animator.SetBool("isMoving", success);
        }
        else
        {
            animator.SetBool("isMoving", false);
        }
    }

    public bool MovePlayer(Vector2 direction)
    {
        int count = rb.Cast(
            direction,
            movementFilter,
            castCollisions,
            moveSpeed * Time.fixedDeltaTime + collisionOffset);

        if (count == 0)
        {
            Vector2 moveVector = direction * moveSpeed * Time.fixedDeltaTime;
            rb.MovePosition(rb.position + moveVector);
            return true;
        }
        else
        {
            foreach (RaycastHit2D hit in castCollisions)
            {
                print(hit.ToString());
            }
            return false;
        }
    }

    public void OnMove(InputValue value)
    {
        moveInput = value.Get<Vector2>();

        if (moveInput != Vector2.zero)
        {
            animator.SetFloat("XInput", moveInput.x);
            animator.SetFloat("YInput", moveInput.y);
        }
    }

    public void OnFire()
    {
        rb.AddForce(Vector3.up * jumpForce, ForceMode2D.Impulse);
    }
}
