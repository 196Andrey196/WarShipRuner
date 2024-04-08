using UnityEngine;

public class OffObstacleBehind : MonoBehaviour
{
   private void OnTriggerEnter(Collider obj) {
    if(obj.tag == "Obstacle")obj.gameObject.SetActive(false);
   }
}
