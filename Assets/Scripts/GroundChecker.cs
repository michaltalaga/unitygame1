using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IGroundChecker
{
    bool IsGrounded { get; }
}
public class GroundChecker : MonoBehaviour, IGroundChecker
{
    [SerializeField] LayerMask groundLayer;

    bool isGrounded;
    public bool IsGrounded { get => isGrounded; }
  

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if ((groundLayer & (1 << collision.gameObject.layer)) == 0) return;
        isGrounded = true;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if ((groundLayer & (1 << collision.gameObject.layer)) == 0) return;
        isGrounded = false;
    }
}
