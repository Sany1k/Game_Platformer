using UnityEngine;

public class LayerCheck : MonoBehaviour
{
    [SerializeField] private LayerMask groundLayer;
    private Collider2D _collider;
    public bool isTouchingLayer;

    private void Awake()
    {
        _collider = GetComponent<Collider2D>();
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        isTouchingLayer = _collider.IsTouchingLayers(groundLayer);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        isTouchingLayer = _collider.IsTouchingLayers(groundLayer);
    }
}
