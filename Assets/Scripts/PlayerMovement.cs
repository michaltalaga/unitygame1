using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;

public class PlayerMovement : NetworkBehaviour
{
    [SerializeField] float speed = 10;
    [SerializeField] float jumpHeight = 20;
    [SerializeField] Animator animator;

    Rigidbody2D body;
    IGroundChecker groundChecker;

    private void Start()
    {
        body = GetComponent<Rigidbody2D>();
        groundChecker = GetComponentInChildren<IGroundChecker>();
    }

    private void ProcessJump()
    {
        Debug.Log("ProcessJump");
        Debug.Log("Is Grounded: " + groundChecker.CheckIsGrounded());
        if (!groundChecker.IsGrounded) return;
        if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W))
        {
            ProcessJumpServerRpc();
        }
    }
    [ServerRpc]
    private void ProcessJumpServerRpc()
    {
        if (!groundChecker.IsGrounded) return;
        body.velocity = Vector2.up * jumpHeight;
    }
    private void Update()
    {
        if (!IsLocalPlayer) return;
        ProcessHorizontalMove();
        ProcessJump();
    }
    private void ProcessHorizontalMove()
    {
        var horizontal = Input.GetAxis("Horizontal");
        animator.SetFloat("Moving", horizontal);
        ProcessHorizonalMoveServerRpc(horizontal);
        
    }
    [ServerRpc]
    private void ProcessHorizonalMoveServerRpc(float horizontal)
    {
        body.velocity = new Vector2(horizontal * speed, body.velocity.y);
    }
}