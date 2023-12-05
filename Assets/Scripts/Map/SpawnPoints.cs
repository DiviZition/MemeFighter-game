using UnityEngine;

public class SpawnPoints : MonoBehaviour
{
    [SerializeField] private Vector3[] _spawnPoints;

    public Vector3 GetNextSpawnPoint(int playerIndex)
    {
        if (_spawnPoints.Length > playerIndex)
            return _spawnPoints[_spawnPoints.Length - 1];
        else
            return _spawnPoints[playerIndex];
    }

    private void OnDrawGizmos()
    {
        if (_spawnPoints.Length < 1)
            return;

        for (int i = 0; i < _spawnPoints.Length; i++)
        {
            Gizmos.color = Color.Lerp(Color.blue, Color.red, (float)i / _spawnPoints.Length);
            Gizmos.DrawWireCube(_spawnPoints[i], Vector3.one * 1f);
        }
    }
}
