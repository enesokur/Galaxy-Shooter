using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    [SerializeField]
    private float _speed = 10f;
    private Player playerScript;
    [SerializeField]
    private int laserType;
    private void Start() {
        playerScript = GameObject.FindWithTag("Player").GetComponent<Player>();
    }
    private void Update() {
        this.transform.Translate(new Vector3(0f,_speed,0f)*Time.deltaTime);
        if(this.transform.position.y > 6f){
            if(laserType == 0){
                Destroy(this.gameObject);
            }
            else if(laserType == 1){
                Destroy(this.transform.parent.gameObject);
            }
        }
    }
}
