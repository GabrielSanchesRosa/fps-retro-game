using UnityEngine;

public class ObjectDestruction : MonoBehaviour {
    [SerializeField] private float delay;
    [SerializeField] private bool hasAnimator;

    void Start() {
        if (hasAnimator) {
            float animTime = GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).length;

            Destroy(this.gameObject, animTime + delay);
        } else {
            Destroy(this.gameObject, delay);
        }
    }
}
