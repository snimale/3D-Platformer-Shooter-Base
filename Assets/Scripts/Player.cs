using System;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour {
    [SerializeField] private UserInputs userInputs;
    [SerializeField] private float jumpHeight;
    [SerializeField] private float playerSpeed;
    [SerializeField] private float jumpCooldownTime;
    [SerializeField] private float maxHealth;
    [SerializeField] private float damageOnCollide;
    [SerializeField] private float collisionDamageCooldown;
    [SerializeField] private Slider slider;
    private float lastCollisionDamageTaken;
    private Rigidbody rb;
    private Vector3 moveDir;
    private float health;
    private float lastJumpedTime;

    private void Start() {
        userInputs.onJump += do_onJump;
        rb = GetComponent<Rigidbody>();
        moveDir = Vector3.zero;
        lastJumpedTime=-jumpCooldownTime;
        lastCollisionDamageTaken=- collisionDamageCooldown;
        health = maxHealth;
    }

    private void do_onJump(object sender, EventArgs e) {
        if(Time.time - lastJumpedTime >= jumpCooldownTime) {
            // u = sqrt(-2as) for vertical initial velocity to reach height s with a = g
            float jumpForce = Mathf.Sqrt(jumpHeight * -2 * Physics.gravity.y);
            rb.AddForce(new Vector2(0, jumpForce), ForceMode.Impulse);
            lastJumpedTime=Time.time;
        }
    }

    private void Update() {
        if(health<=0) die();
        if(transform.position.y<=-20) die(); //fall down

        // update health bar value
        slider.value = health/maxHealth;

        moveDir = new Vector3(userInputs.getMoveDir().x, 0, userInputs.getMoveDir().y);
        moveDir.Normalize(); 
        float playerMoveDist = playerSpeed * Time.deltaTime;
        if(userInputs.isRunning()) playerMoveDist*=2; // speed double -> distance double in same time
        transform.position += moveDir * playerMoveDist;
    }

    private void OnCollisionEnter(Collision other) {
        if(other.gameObject.TryGetComponent<Enemy>(out Enemy enemy) && Time.time-lastCollisionDamageTaken>=collisionDamageCooldown) {
            health-=damageOnCollide;
            lastCollisionDamageTaken = Time.time;
        }
    }

    private void OnCollisionStay(Collision other) {
        
        if(other.gameObject.TryGetComponent<Enemy>(out Enemy enemy) && Time.time-lastCollisionDamageTaken>=collisionDamageCooldown) {
            health-=damageOnCollide;
            lastCollisionDamageTaken = Time.time;
        }
    }

    private void die(){
        this.gameObject.SetActive(false);
    }
}
