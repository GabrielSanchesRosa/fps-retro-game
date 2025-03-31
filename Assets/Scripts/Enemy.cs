using UnityEngine;

public class Enemy : MonoBehaviour {
    [SerializeField] private Transform[] walkingPoints;
    [SerializeField] private Transform shootLocation;

    [SerializeField] private GameObject enemyProjectile;

    [SerializeField] private Animator oAnimator;

    [SerializeField] private float enemySpeed, distanceToAttack, timeBetweenAttacks;

    [SerializeField] private int maxEnemyLife, enemyLife;

    private float actualTime;

    private int actualPoint;

    private bool enemyIsAlive, enemyCanWalk, enemyHasAttacked;

    void Start() {
        enemyIsAlive     = true;
        enemyCanWalk     = true;
        enemyHasAttacked = false;

        enemyLife = maxEnemyLife;

        transform.position = walkingPoints[0].position;
    }

    void Update() {
        if (GameManager.instance.playerAlive) {
            MoveEnemy();
            VerifyDistance();
        }
    }

    private void MoveEnemy() {
        if (enemyIsAlive) {
            if (enemyCanWalk) {
                transform.position = Vector2.MoveTowards(transform.position, walkingPoints[actualPoint].position, enemySpeed * Time.deltaTime);

                if (transform.position != walkingPoints[actualPoint].position) {
                    oAnimator.SetTrigger("Walking");
                }

                if (transform.position == walkingPoints[actualPoint].position) {
                    oAnimator.SetTrigger("Stopped");
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

            oAnimator.SetTrigger("Attacking");
            Instantiate(enemyProjectile, shootLocation.position, shootLocation.rotation);
            enemyHasAttacked = true;

            Invoke(nameof(ResetEnemyAttack), timeBetweenAttacks);
        }
    }

    private void ResetEnemyAttack() {
        enemyHasAttacked = false;
    }

    public void HitEnemy(int damage) {
        if (enemyIsAlive) {
            enemyLife -= damage;
            oAnimator.SetTrigger("Damage");

            if (enemyLife <= 0) {
                enemyIsAlive = false;
                enemyCanWalk = false;

                oAnimator.SetTrigger("Defeated");
            }
        }
    }

    public void DefeatEnemy() {
        Destroy(this.gameObject);
    }
}
