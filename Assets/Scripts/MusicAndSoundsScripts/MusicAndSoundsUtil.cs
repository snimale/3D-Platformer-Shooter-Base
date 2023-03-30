using System;
using UnityEngine;

public class MusicAndSoundsUtil : MonoBehaviour {
    [SerializeField] private UserInputs userInputs;
    [SerializeField] private GameObject bulletsSound;
    [SerializeField] private GameObject jumpSound;
    [SerializeField] private GameObject walk;
    [SerializeField] private GameObject player;
    private float lastTimeJumped;

    private void Start() {
        lastTimeJumped=-1f;
        userInputs.onJump += sound_OnJump;
    }

    [Obsolete]
    private void Update() {
        if(userInputs.isShooting() && player.active) bulletsSound.SetActive(true);
        else bulletsSound.SetActive(false);
        if(Time.time-lastTimeJumped>1f) jumpSound.SetActive(false);

        if(userInputs.getMoveDir().y!=0) walk.SetActive(true);
        else walk.SetActive(false);
    }

    private void sound_OnJump(object sender, EventArgs e) {
        if(Time.time-lastTimeJumped>1f) {
            jumpSound.SetActive(true);
            lastTimeJumped=Time.time;
        }
    }
}
