using UnityEngine;
using UnityEngine.UI;

public class LoadingCanvasScriptMtoL : MonoBehaviour {
    [SerializeField] private MainMenuScript mainMenuScript;
    [SerializeField] private Slider slider;
    private AsyncOperation asyncOperation;
    private void OnEnable() {
        asyncOperation = mainMenuScript.getAsyncOperation();
    }
    private void Update() {
        slider.value = asyncOperation.progress;
    }
}