using System;
using UnityEngine;

public class UserInputs : MonoBehaviour {

    
    public event EventHandler onJump;
    private Vector2 moveDirection;
    private bool run;
    private bool shooting;
    private void Start() {
        moveDirection = Vector2.zero;
    }

    private void Update() {
        if((Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow)) && (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))) {
            moveDirection = Vector2.zero;
        } else if(Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow)) {
            moveDirection = new Vector2(0, -1);
        } else if((Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))) {
            moveDirection = new Vector2(0, 1);
        } else {
            moveDirection = Vector2.zero;
        }

        if(Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow)) {
            run = true;
        } else run = false;

        if(Input.GetKeyDown(KeyCode.Space)) {
            onJump?.Invoke(this, EventArgs.Empty);
        }

        if(Input.GetKey(KeyCode.Mouse0)) shooting=true;
        else shooting = false;
    }

    public Vector2 getMoveDir() {
        return moveDirection;
    }

    public bool isRunning() {
        return run;
    }

    public bool isShooting() {
        return shooting;
    }
}
