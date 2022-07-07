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
// Shild power up ın setupını kur. Toplanabilir yap. Shild yeteneğini aktif et. Shield açık olduğunda 1 hasarı absorbe edebiliyoruz ve sonra shield
// kapanıyor. Shieldı belli bir saniye açık tut.