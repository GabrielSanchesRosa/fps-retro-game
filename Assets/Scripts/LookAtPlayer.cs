using UnityEngine;

public class LookAtPlayer : MonoBehaviour {
    void Update() {
        transform.LookAt(PlayerControl.instance.transform.position, -Vector3.forward);
    }
}
