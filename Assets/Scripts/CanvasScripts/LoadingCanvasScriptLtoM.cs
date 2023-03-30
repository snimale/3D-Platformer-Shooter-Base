using UnityEngine;
using UnityEngine.UI;

public class LoadingCanvasScript : MonoBehaviour {
    [SerializeField] private GameOverCanvas gameOverCanvas;
    [SerializeField] private Slider slider;
    private AsyncOperation asyncOperation;
    private void OnEnable() {
        asyncOperation = gameOverCanvas.getAsyncOperation();
    }
    private void Update() {
        slider.value = asyncOperation.progress;
    }
}