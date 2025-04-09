using UnityEngine;

public class PipeSpawner : MonoBehaviour
{
    [SerializeField]
    private float _maxTime = 1.5f; // ido a cso generalasa kozott

    [SerializeField]
    private float _heightRange = 0.4f; // magassag valtozas a cso poziciojaban

    [SerializeField]
    private GameObject _pipePrefab; // a cso prefabja

    private float _timer; // belso idozito

    private void Start()
    {
        SpawnPipe(); // indulasnal rogton general egy csovet
    }

    private void Update()
    {
        _timer += Time.deltaTime; // noveli az idozitot az eltelt ido alapjan

        if (_timer > _maxTime)
        {
            SpawnPipe(); // uj cso generalasa
            _timer = 0;  // idozito visszaallitasa
        }
    }

    private void SpawnPipe()
    {
        // general egy uj poziciot a random magassaggal
        Vector3 spawnPosition = transform.position + new Vector3(0, Random.Range(-_heightRange, _heightRange), 0);

        // letrehozza az uj csovet
        GameObject newPipe = Instantiate(_pipePrefab, spawnPosition, Quaternion.identity);

        // 5 masodperc utan megsemmisiti
        Destroy(newPipe, 5f);
    }
}
