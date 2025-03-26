using UnityEngine;

public class Enemy : MonoBehaviour {
    [SerializeField] private Transform[] walkingPoints;

    [SerializeField] private float enemySpeed;

    [SerializeField] private int actualPoint;

    [SerializeField] private bool enemyAlive;
    [SerializeField] private bool enemyCanWalk;

    [SerializeField] private float actualTime;

    void Start() {
        enemyAlive   = true;
        enemyCanWalk = true;

        transform.position = walkingPoints[0].position;
    }

    void Update() {
        MoveEnemy();
    }

    private void MoveEnemy() {
        if (enemyAlive) {
            if (enemyCanWalk) {
                transform.position = Vector2.MoveTowards(transform.position, walkingPoints[actualPoint].position, enemySpeed * Time.deltaTime);

                if (transform.position.y == walkingPoints[actualPoint].position.y) {
                    WaitBeforeWalk(1.5f);
                }

                if (actualPoint == walkingPoints.Length) {
                    actualPoint = 0;
                }
            }
        }
    }

    private void WaitBeforeWalk(float timeBetweenPoints) {
        // enemyCanWalk = false;

        actualTime -= Time.deltaTime;

        if (actualTime <= 0) {
            enemyCanWalk = true;
            actualPoint++;
            actualTime = timeBetweenPoints;
        }
    }
}
