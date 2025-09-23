using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class L4PlayerController : MonoBehaviour
{
    Rigidbody2D rb;
    private bool isJumping = true;
    public float JumpPower = 10.0f;
    public float moveSpeed = 5f;
    public GameObject text;
    private float moveInput;
    Animator animator;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        isJumping = true;
        Debug.Log("Player : isJumping = true");
        if (text != null)
            text.SetActive(false);
        animator = GetComponent<Animator>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Floor"))
        {
            Debug.Log("Player : 바닥 충돌");
            isJumping = false;
            Debug.Log("Player : isJumping = false");
        }

        if (collision.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("Player : Game Over!");
            if (text != null)
                text.SetActive(true);
            Time.timeScale = 0f;
        }
    }

    void Update()
    {
        // 점프 입력 체크 (Space 키)
        if (Keyboard.current.spaceKey.wasPressedThisFrame && !isJumping)
        {
            Debug.Log("Player : 점프 (Space Bar Pressed)");
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, JumpPower);
            isJumping = true;
            Debug.Log("Player : isJumping = true");
            animator.Play("PlayerJump",-1, 0f);
        }

        // 좌우 이동 입력 (키보드 A/D 또는 좌우 화살표)
        if (Keyboard.current.aKey.isPressed)
        {
            moveInput = -1f;
        }
        else if (Keyboard.current.dKey.isPressed)
        {
            moveInput = 1f;
        }
        else if (Keyboard.current.leftArrowKey.isPressed)
        {
            moveInput = -1f;
        }
        else if (Keyboard.current.rightArrowKey.isPressed)
        {
            moveInput = 1f;
        }
        else
        {
            moveInput = 0f;
        }
    }

    void FixedUpdate()
    {
        rb.linearVelocity = new Vector2(moveInput * moveSpeed, rb.linearVelocity.y);
    }
}
