using UnityEngine;

public class LookAtPlayer : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {
        transform.LookAt(PlayerControl.instance.transform.position, -Vector3.forward);
    }
}
