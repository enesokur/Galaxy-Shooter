using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    [SerializeField]
   private float _speed = 2f;
   [SerializeField]
   private int powerUpId;
   [SerializeField]
   private AudioClip _clip;

   private void Update() {
       this.transform.Translate(Vector3.down*_speed*Time.deltaTime);
       if(this.transform.position.y < -7){
        Destroy(this.gameObject);
       }
   }
   private void OnTriggerEnter2D(Collider2D other) {
       if(other.tag == "Player"){
            AudioSource.PlayClipAtPoint(_clip,Camera.main.transform.position,0.4f);
            Player player = other.gameObject.GetComponent<Player>();
            if(player != null){
                if(powerUpId == 0){
                    player.StartTripleShotPowerDown();
                }
                else if(powerUpId == 1){
                    player.StartSpeedPowerDown();
                }
                else if(powerUpId == 2){
                    player.StartShieldPowerDown();
                }
            }
            Destroy(this.gameObject);
       }
   }
}
