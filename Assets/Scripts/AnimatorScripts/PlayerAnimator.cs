using System;
using UnityEngine;


public class PlayerAnimator : MonoBehaviour {
    [SerializeField] private UserInputs userInputs;
    [SerializeField] private float timeInAir;
    private float timeJumpStarted;
    private Vector3 moveDir;
    private bool jump;
    private bool walk;
    private bool run;
    private bool idle;
    private bool left;
    private bool right;
    private Animator animator;
    private void Start() {
        userInputs.onJump += animation_OnJump;
        timeJumpStarted = 0f;
        jump=false;
        walk=false;
        run=false;
        idle=false;
        animator = GetComponent<Animator>();
    }

    private void animation_OnJump(object sender, EventArgs e) {
        jump=true;
        timeJumpStarted = Time.time;
    }

    private void Update() {
        
        // set parameters to true or false and at end call one function to set all parameters in animator together

        moveDir = new Vector3(0, 0, userInputs.getMoveDir().y);
        if(moveDir.z<0) {
            if(transform.forward.z < 0) transform.rotation = new Quaternion(0, 0, 0, 0);
        } else if (moveDir.z>0) {
            if(transform.forward.z > 0) transform.rotation = new Quaternion(0, 180, 0, 0);
        }
        //Debug.Log(transform.forward);

        if(moveDir.z!=0 && jump==false) {
            idle = false;
            if (userInputs.isRunning()) {
                run = true;
                walk = false;
            } else {
                walk = true;
                run = false;
            }
        } else if(jump==false) {
            idle = true;
            run = false;
            walk = false;
        }

        if(jump == true && Time.time - timeJumpStarted > timeInAir) {
            jump = false;
        }
        setParameters();
    }

    private void setParameters() {
        animator.SetBool("jumped", jump);
        animator.SetBool("run", run);
        animator.SetBool("walk", walk);
        animator.SetBool("idle", idle);
        animator.SetBool("isShooting", userInputs.isShooting());
    }
}
