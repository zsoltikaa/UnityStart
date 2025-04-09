using UnityEngine;

public class PipeMoveBehaviour : MonoBehaviour
{

    [SerializeField]
    private float _speed = .65f; // az objektum mozgasi sebessege

    private void Update()
    {
        // az objektum balra mozgatasa minden kepkockaban a sebesseg es az eltelt ido alapjan
        transform.position += Vector3.left * _speed * Time.deltaTime;
    }

}
