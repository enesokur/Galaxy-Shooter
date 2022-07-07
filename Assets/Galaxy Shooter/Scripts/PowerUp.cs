using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    [SerializeField]
   private float _speed = 2f;
   [SerializeField]
   private int powerUpId;

   private void Update() {
       this.transform.Translate(Vector3.down*_speed*Time.deltaTime);
   }
   private void OnTriggerEnter2D(Collider2D other) {
       if(other.tag == "Player"){
            Player player = other.gameObject.GetComponent<Player>();
            if(player != null){
                if(powerUpId == 0){
                    player.StartTripleShotPowerDown();
                }
                else if(powerUpId == 1){
                    player.StartSpeedShotPowerDown();
                }
            }
            Destroy(this.gameObject);
       }
   }
}