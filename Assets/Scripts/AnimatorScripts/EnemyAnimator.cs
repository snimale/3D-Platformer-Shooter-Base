using Unity.VisualScripting;
using UnityEngine;

public class EnemyAnimator : MonoBehaviour {
    [SerializeField] private Enemy enemy;
    private Animator animator;
    private void Start() {
        animator = GetComponent<Animator>();
    }
    private void Update() {
        animator.SetFloat("zdir", enemy.getPlayerToEnemyNormalized().z);
    }
}
