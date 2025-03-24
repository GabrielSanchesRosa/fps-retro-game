using UnityEngine;

public class ObjectDestruction : MonoBehaviour
{
    [SerializeField] private float delay;

    void Start() {
        float animTime = GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).length;

        Destroy(this.gameObject, animTime + delay);
    }
}
