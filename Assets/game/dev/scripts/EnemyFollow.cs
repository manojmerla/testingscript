using UnityEngine;

public class EnemyFollow : MonoBehaviour
{
    public Transform player;
    public EnemyData enemyData;

    void Update()
    {
        if (player == null) return;

        transform.position = Vector3.MoveTowards(
            transform.position,
            player.position,
            enemyData.speed * Time.deltaTime
        );

        Vector3 direction = player.position - transform.position;
        if (direction != Vector3.zero)
        {
            transform.rotation = Quaternion.LookRotation(direction);
        }
    }
}
