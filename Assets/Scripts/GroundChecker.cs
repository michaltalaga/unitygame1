using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IGroundChecker
{
    bool IsGrounded { get; }
    bool CheckIsGrounded();
}
public class GroundChecker : MonoBehaviour, IGroundChecker
{
    [SerializeField] LayerMask groundLayer;
    [SerializeField] Collider2D collider;

    bool isGrounded;
    public bool IsGrounded { get => isGrounded; }
  
    public bool CheckIsGrounded()
    {
        var contacts = new List<Collider2D>();
        collider.GetContacts(contacts);
        return contacts.Count > 0;
    }
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
