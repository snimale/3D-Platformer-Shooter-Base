using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour {
    [SerializeField] private float enemySpeed;
    [SerializeField] private float ThresholdTime;
    [SerializeField] private float ThresholdTimeContactDamage;
    [SerializeField] private float bulletDamage;
    [SerializeField] private Slider slider;
    public GameObject player;
    [SerializeField] private float maxHealth;
    [SerializeField] private float playerTouchDamage;
    private float health;
    private float lastTimeDamageTaken;
    private Rigidbody rb;
    private float lastTimeMoved;
    private Vector3 enemyToPlayerNormalized;
    private void Start() {
        rb = GetComponent<Rigidbody>();
        lastTimeMoved=-1;
        enemyToPlayerNormalized = Vector3.zero;
        health = maxHealth;
    }
    private void Update() {
        //update health bar value
        slider.value = health/maxHealth;

        enemyToPlayerNormalized = (player.transform.position - transform.position).normalized;
        if(Time.time-lastTimeMoved>ThresholdTime) {
            rb.AddForce(enemyToPlayerNormalized*enemySpeed, ForceMode.Impulse);
            lastTimeMoved=Time.time;
        }
        if(health<=0 || transform.position.y<-20) die();
    }

    private void OnCollisionEnter(Collision collidedWith) {
        if(collidedWith.gameObject == player.gameObject) {
            // reduce self health or die if too low
            health-=playerTouchDamage;
            lastTimeDamageTaken = Time.time;
            //Debug.Log(health);
        }
    }

    private void OnCollisionStay(Collision collidedWith) {
        if(collidedWith.gameObject == player.gameObject && Time.time-lastTimeDamageTaken>ThresholdTimeContactDamage) {
            // reduce self health or die if too low
            health-=playerTouchDamage;
            lastTimeDamageTaken=Time.time;
            //Debug.Log(health);
        }
    }

    public void takeBulletDamage() {
        health-=bulletDamage;
    }

    private void die() {
        GameObject.Destroy(this.gameObject);
    }

    public Vector3 getPlayerToEnemyNormalized() {
        return enemyToPlayerNormalized;
    }
}
