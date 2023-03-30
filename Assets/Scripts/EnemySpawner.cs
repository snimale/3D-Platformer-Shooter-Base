using Unity.Mathematics;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {
    [SerializeField] private GameObject player;
    [SerializeField] private float enemySpawnDist;
    [SerializeField] private GameObject enemy;
    private Vector3 playerPos;
    private Vector3 thisPos;

    private void Start() {
        thisPos = transform.position;
    }
    private void Update() {
        playerPos = player.transform.position;
        float dist = (playerPos-thisPos).magnitude;
        if(dist<enemySpawnDist) {
            spawn();
            GameObject.Destroy(this.gameObject);
        }
    }

    private void spawn() {
        GameObject enemyGenerated = Instantiate(enemy, transform.position, Quaternion.identity);
        enemyGenerated.GetComponent<Enemy>().player = player; // give reference of player
    }
}
