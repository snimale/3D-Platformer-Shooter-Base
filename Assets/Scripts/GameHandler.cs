using UnityEngine;

public class GameHandler : MonoBehaviour {
    [SerializeField] private GameObject gameOverUI;
    [SerializeField] private GameObject levelCompleteUI;
    [SerializeField] private GameObject player;

    [System.Obsolete]
    private void Update() {
        if((player.active==false && player.transform.position.z>=-49f) || player.transform.position.y<=-20) gameOverUI.SetActive(true);
        else gameOverUI.SetActive(false);

        if(player.transform.position.z<-49.5f) {
            levelCompleteUI.SetActive(true);
            player.SetActive(false);
            return;
        }
        else levelCompleteUI.SetActive(false);
    }
}