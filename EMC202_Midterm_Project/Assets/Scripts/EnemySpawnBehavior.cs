using System.Collections;
using UnityEngine;

public class EnemySpawnBehavior : MonoBehaviour
{
    public GameObject enemy;
    public Transform[] enemyPositions;
    private int spawnPoint;

    // Start is called before the first frame update
    private void Start()
    {
        StartCoroutine(EnemySpawn());
    }

    // Update is called once per frame
    private IEnumerator EnemySpawn()
    {
        while (true)
        {
            var pos = enemyPositions[spawnPoint];
            Instantiate(enemy, pos.position, Quaternion.identity);
            spawnPoint = (spawnPoint + 1) % enemyPositions.Length;
            yield return new WaitForSeconds(1.5f);
        }
    }
}