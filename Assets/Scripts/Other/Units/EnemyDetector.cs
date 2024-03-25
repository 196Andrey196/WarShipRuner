using UnityEngine;

public class EnemyDetector : MonoBehaviour
{
    private ProjectileLauncher _projectileLauncher;
    private void Start() {
        _projectileLauncher = transform.parent.GetComponent<ProjectileLauncher>();
        _projectileLauncher.enabled = false;
    }
    private void OnTriggerEnter(Collider collision) {
        if(collision.tag == "Player")
        {
            Debug.Log(collision.name);
             _projectileLauncher.enabled = true;
        }
    }

}
