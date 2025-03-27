using UnityEngine;

public class Enemy : MonoBehaviour {
    [SerializeField] private Transform[] walkingPoints;
    [SerializeField] private Transform shootLocation;

    [SerializeField] private GameObject enemyProjectile;

    [SerializeField] private float enemySpeed, distanceToAttack, timeBetweenAttacks;

    private float actualTime;

    private int actualPoint;

    private bool enemyAlive, enemyCanWalk, enemyHasAttacked;

    void Start() {
        enemyAlive       = true;
        enemyCanWalk     = true;
        enemyHasAttacked = false;

        transform.position = walkingPoints[0].position;
    }

    void Update() {
        MoveEnemy();
        VerifyDistance();
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
        actualTime -= Time.deltaTime;

        if (actualTime <= 0) {
            enemyCanWalk = true;
            actualTime   = timeBetweenPoints;
            actualPoint++;
        }
    }

    private void VerifyDistance() {
        if (Vector3.Distance(transform.position, PlayerControl.instance.transform.position) <= distanceToAttack) {
            AttackPlayer();
        } else {
            enemyCanWalk = true;
        }
    }

    private void AttackPlayer() { 
        if (!enemyHasAttacked) {
            enemyCanWalk = false;

            Instantiate(enemyProjectile, shootLocation.position, shootLocation.rotation);
            enemyHasAttacked = true;

            Invoke(nameof(ResetEnemyAttack), timeBetweenAttacks);
        }
    }

    private void ResetEnemyAttack() {
        enemyHasAttacked = false;
    }
}
