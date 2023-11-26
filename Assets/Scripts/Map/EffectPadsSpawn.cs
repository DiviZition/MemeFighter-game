using UnityEngine;

public class EffectPadsSpawn : MonoBehaviour
{
    [SerializeField] private EffectPad _padPrefab;
    [SerializeField] private Transform _effectPadsStorage;

    [SerializeField] private Vector3 _spawnerCenterOffset;
    [SerializeField] private float _spawnerLength;

    [SerializeField] private float _spawnDelay;

    private float _spawnTimer;

    private void FixedUpdate()
    {
        if (_spawnTimer < Time.time)
        {
            _spawnTimer = Time.time + _spawnDelay;
            SpawnPad();
        }
    }

    private void SpawnPad()
    {
        Vector3 randomPosition = _spawnerCenterOffset;
        randomPosition.x = Random.Range
            (randomPosition.x + _spawnerLength / 2, randomPosition.x - _spawnerLength / 2);

        EffectPad pad = Instantiate
            (_padPrefab, randomPosition, Quaternion.identity, _effectPadsStorage);

        pad.SetEffectType
            (EffectsStorage.Effects[Random.Range(1, EffectsStorage.Effects.Count)].TypeOfEffect);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;

        Gizmos.DrawLine
            (_spawnerCenterOffset + Vector3.right * _spawnerLength / 2,
            (_spawnerCenterOffset + Vector3.left * _spawnerLength / 2));
    }
}
