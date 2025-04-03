using UnityEngine;
using UnityEngine.InputSystem; // az uj input rendszert tartalmazo namespace, amely a felhasznaloi bemeneteket kezeli

public class NewMonoBehaviourScript : MonoBehaviour
{
    [SerializeField] // ez a tagfuggveny lehetove teszi, hogy az adott valtozot az Inspector ablakban is meg lehessen jeleniteni es szerkeszteni
    private float _velocity = 1.5f; // a mozgas sebesseget tarolo valtozo, amelyet az Inspectorban allithatunk

    [SerializeField]
    private float _rotationSpeed = 10f; // a forgasi sebesseget tarolo valtozo, amelyet szinten az Inspectorban lehet modositani

    private Rigidbody2D _rigidbody; // referencia a Rigidbody2D komponensre, amely fizikai muveleteket hajt vegre az objektumon

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>(); // a Rigidbody2D komponens hozzarendelese a _rigidbody valtozohoz
    }

    private void Update()
    {
        // ha az eger bal gombjat megnyomjak az adott framen belul
        if (Mouse.current.leftButton.wasPressedThisFrame) 
        {
            _rigidbody.linearVelocity = Vector2.up * _velocity; 
            // az objektum fuggoleges iranyba mozdul el a beallitott sebesseggel (Y tengely menten felfele)
        }
    }

    private void FixedUpdate()
    {
        // az objektum forgatasat allitja be a sebesseg fuggvenyeben
        transform.rotation = Quaternion.Euler(0, 0, _rigidbody.linearVelocityY * _rotationSpeed); 
        // a forgatas a z tengely menten tortenik, az aktualis sebesseg es a forgasi sebesseg alapjan
    }
}
