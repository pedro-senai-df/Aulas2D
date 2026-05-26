using UnityEngine;
using System;
using System.Collections;

public class BatBehaviour : MonoBehaviour
{
    public enum JumpMode
    {
        SetVelocity,
        AddForce
    }

    public JumpMode jumpMode;
    public float jumpHeight = 2f;
    public float jumpForce = 200f;

    [Space]

    public float maxHeight = 4.5f;

    public Action onFirstInput;
    public Action onJump;
    public Action onStartFall;
    public Action onDeath;

    private bool canJump_ = true;
    private bool isJumping_ = false;
    private Rigidbody2D rb_;



    public static BatBehaviour Instance { get; private set; }
    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        rb_ = GetComponent<Rigidbody2D>();
        StartCoroutine(WaitForFirstInput());
    }


    private void Update()
    {
        if (isJumping_ && rb_.linearVelocityY < 0f)
        {
            onStartFall?.Invoke();
            isJumping_ = false;
        }

        if (canJump_ && Input.anyKeyDown)
        {
            Jump();
        }

        if (transform.position.y > maxHeight)
        {
            rb_.linearVelocityY = 0f;

            Vector3 pos = transform.position;
            pos.y = maxHeight;

            transform.position = pos;
        }
    }


    private void OnCollisionEnter2D(Collision2D col)
    {
        canJump_ = false;
        onDeath?.Invoke();
    }



    private void Jump()
    {
        onJump?.Invoke();
        isJumping_ = true;

        switch (jumpMode)
        {
            case JumpMode.SetVelocity:
                rb_.linearVelocityY = Mathf.Sqrt(jumpHeight * Physics.gravity.y * -2f);
                break;

            case JumpMode.AddForce:
                rb_.AddForceY(jumpForce);
                break;
        }
    }


    private IEnumerator WaitForFirstInput()
    {
        rb_.gravityScale = 0f;
        rb_.linearVelocityY = 0f;

        yield return new WaitUntil(() => isJumping_);
        onFirstInput?.Invoke();

        rb_.gravityScale = 1f;

        yield break;
    }
}
