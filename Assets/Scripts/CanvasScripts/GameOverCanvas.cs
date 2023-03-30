using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverCanvas : MonoBehaviour {
    [SerializeField] private GameObject loadingScreen;
    private AsyncOperation asyncOperation;
    // [SerializeField] private Slider loadingSlider;
    public void back() {
        asyncOperation =  SceneManager.LoadSceneAsync(0);
        this.gameObject.SetActive(false);
        loadingScreen.SetActive(true);
        
    }

    public AsyncOperation getAsyncOperation() {
        return asyncOperation;
    }
}