using UnityEngine;

public class GroundLoop : MonoBehaviour
{

    [SerializeField]
    private float _speed = 1.3f; // novekedes sebessege masodpercenkent

    [SerializeField]
    private float _width = 6f; // maximalis szelesseg mielott visszaall az eredetire

    private SpriteRenderer _spriteRenderer; // referencia a sprite renderer komponensre

    private Vector2 _startSize; // a sprite kezdeti merete

    private void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>(); // sprite renderer komponens lekerese

        _startSize = new(x: _spriteRenderer.size.x, y: _spriteRenderer.size.y); // kezdeti meret eltarolasa
    }

    private void Update()
    {
        // a sprite szelessegenek novelese ido alapjan
        _spriteRenderer.size = new(x: _spriteRenderer.size.x + _speed * Time.deltaTime, y: _spriteRenderer.size.y);

        // ha a sprite szelessege nagyobb mint a maximalis ertek, visszaallitjuk az eredetire
        if (_spriteRenderer.size.x > _width)
        {
            _spriteRenderer.size = _startSize;
        }
    }

}
