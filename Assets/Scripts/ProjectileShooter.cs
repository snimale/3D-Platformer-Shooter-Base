using UnityEngine;

public class ProjectileShooter : MonoBehaviour{
    [SerializeField] private float range;
    [SerializeField] private int shootRate; // per min
    [SerializeField] private UserInputs userInputs;
    [SerializeField] private GameObject playerVisual;
    [SerializeField] private GameObject particleParentLeft;
    [SerializeField] private GameObject particleParentRight;
    [SerializeField] private ParticleSystem pslt;
    [SerializeField] private ParticleSystem psrt;
    [SerializeField] private ParticleSystem psl;
    [SerializeField] private ParticleSystem psr;
    private float lastShootTime;
    private float threshold;
    private float lastMoveDirY;

    [System.Obsolete]
    private void Start() {
        // eg - 40 every 60 sec rate
        // 1 every 1.5 sec rate
        threshold = 60f/shootRate;
        pslt.startLifetime=threshold;
        psrt.startLifetime=threshold;
        psl.startLifetime=threshold;
        psr.startLifetime=threshold;
        lastMoveDirY=-1;
    }

    private void Update() {
        if(userInputs.getMoveDir().y!=0) lastMoveDirY = userInputs.getMoveDir().y;
        if(userInputs.isShooting() && Time.time-lastShootTime>=threshold) shoot();
        if(Time.time-lastShootTime>=threshold/2) {
            particleParentLeft.SetActive(false);
            particleParentRight.SetActive(false);
        }
    }

    private void shoot() {
        lastShootTime = Time.time;
        pslt.transform.localScale = new Vector3(0.1f, 0.1f, 5);
        psrt.transform.localScale = new Vector3(0.1f, 0.1f, 5);

        if(lastMoveDirY<0) particleParentRight.SetActive(true);
        else if(lastMoveDirY>0) particleParentLeft.SetActive(true);
        
        if(Physics.Raycast(playerVisual.transform.position, -playerVisual.transform.forward, out RaycastHit hit, range)) {
            //createShootTracer(Vector3.Angle(new Vector3 (0, 0, 0), -playerVisual.transform.forward), (hit.transform.position-transform.position).magnitude-1f);
            pslt.transform.localScale = new Vector3(0.1f, 0.1f, (hit.transform.position-this.transform.position).magnitude-1f);
            psrt.transform.localScale = new Vector3(0.1f, 0.1f, (hit.transform.position-this.transform.position).magnitude-1f);
            Enemy enemy = hit.transform.GetComponent<Enemy>();
            if(enemy!=null) enemy.takeBulletDamage();      
        }
    }

    // private void createShootTracer(float angle, float dist) {
    //     Vector3 fromPos = transform.position + transform.forward.normalized * dist * 0.5f;
    //     world_mesh
    // }
}