using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    private Animator _anim;
    private void Start() {
        _anim = this.GetComponent<Animator>();
    }
    private void Update() {
        if(Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow)){
            _anim.SetBool("turnLeft",true);
            _anim.SetBool("turnRight",false);
        }
        else if(Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.LeftArrow)){
            _anim.SetBool("turnLeft",false);
        }
        if(Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow)){
            _anim.SetBool("turnRight",true);
            _anim.SetBool("turnLeft",false);
        }

        else if(Input.GetKeyUp(KeyCode.D) || Input.GetKeyUp(KeyCode.RightArrow)){
            _anim.SetBool("turnRight",false);
        }
    }
}
