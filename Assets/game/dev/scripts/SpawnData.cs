using UnityEngine;

[CreateAssetMenu(menuName = "Spawn/SpawnData")]
public class SpawnData : ScriptableObject
{
    public float spawnDelay;
    public GameObject[] prefabs;
}
