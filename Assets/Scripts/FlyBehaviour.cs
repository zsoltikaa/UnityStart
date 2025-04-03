using UnityEngine;
using UnityEngine.InputSystem;

public class NewMonoBehaviourScript : MonoBehaviour
{

    [SerializeField] // arra szolgal, hogy az Inspector ablakban egy valtozot lathatova es szerkeszthetove tegyen
    private float _velocity = 1.5f; // _ azt ele rakjuk ami private mezo

    [SerializeField]
    private float _rotationSpeed = 10f;

    private Rigidbody2D _rigidbody;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (Mouse.current.leftButton.wasPressedThisFrame) 
        {
            _rigidbody.linearVelocity = Vector2.up * _velocity;
        }
    }

    private void FixedUpdate()
    {
        transform.rotation = Quaternion.Euler(0, 0, _rigidbody.linearVelocityY * _rotationSpeed);
    }

}
