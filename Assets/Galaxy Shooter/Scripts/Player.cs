using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public bool canTripleShoot = false;
    public bool canSpeedUp = false;
    [SerializeField]
    private GameObject _laserPrefab;
    [SerializeField]
    private GameObject _trippleLaserPrefab;
    [SerializeField]
    private float _speed = 3f;
    [SerializeField]
    private float _fireRate = 0.4f;
    private float _nextFireTime = 0.0f;
    private int _health = 3;
    [SerializeField]
    private GameObject playerExpPrefab;
    private void Update() {
        Movement();
        if(Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0)){
            Shoot();
        }
    }

    private void Shoot(){
        if(Time.time > _nextFireTime){
            if(canTripleShoot){
                Instantiate(_trippleLaserPrefab,transform.position,Quaternion.identity);
            }
            else{
                Instantiate(_laserPrefab,transform.position + new Vector3(0f,1f,0f),Quaternion.identity);
            }
            _nextFireTime = Time.time + _fireRate;
        }
    }

    private void Movement(){
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        if(canSpeedUp == true){
            this.transform.Translate(new Vector3(horizontalInput,0f,0f)*_speed*2*Time.deltaTime);
            this.transform.Translate(new Vector3(0f,verticalInput,0f)*_speed*2*Time.deltaTime);
        }
        else if(canSpeedUp == false){
            this.transform.Translate(new Vector3(horizontalInput,0f,0f)*_speed*Time.deltaTime);
            this.transform.Translate(new Vector3(0f,verticalInput,0f)*_speed*Time.deltaTime);
        }

        if(this.transform.position.x >= 9.5f){
            this.transform.position = new Vector3(-9.5f,this.transform.position.y,0f);
        }
        else if(this.transform.position.x <= -9.5f){
            this.transform.position = new Vector3(9.5f,this.transform.position.y,0f);
        }
        if(this.transform.position.y >= 0f){
            this.transform.position = new Vector3(this.transform.position.x,0f,0f);
        }
        else if(this.transform.position.y <= -4.2f){
            this.transform.position = new Vector3(this.transform.position.x,-4.2f,0f);
        }
    }
    
    public void StartTripleShotPowerDown(){
        canTripleShoot = true;
        StartCoroutine(TripleShotPowerDownRoutine());
    }

    public void StartSpeedShotPowerDown(){
        canSpeedUp = true;
        StartCoroutine(SpeedPowerDownRoutine());
    }
    

    private IEnumerator TripleShotPowerDownRoutine(){
        yield return new WaitForSeconds(5.0f);
        canTripleShoot = false;
    }
    private IEnumerator SpeedPowerDownRoutine(){
        yield return new WaitForSeconds(5.0f);
        canSpeedUp = false;
    }

    public void Die(){
        _health--;
        if(_health == 0){
            Instantiate(playerExpPrefab,this.transform.position,Quaternion.identity);
            Destroy(this.transform.gameObject);
        }
    }
}
