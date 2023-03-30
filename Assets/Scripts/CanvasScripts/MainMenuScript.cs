using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour {
    [SerializeField] private GameObject loadingScreen;
    public AsyncOperation asyncOperation;
    public void onClickPlay() {
        this.gameObject.SetActive(false);    
        asyncOperation =  SceneManager.LoadSceneAsync(1);
        loadingScreen.SetActive(true);
    }
    public void onClickSettings() {
        //Debug.Log("settings");
    }
    public void onClickQuit() {
        Application.Quit();
    }

    public AsyncOperation getAsyncOperation() {
        return asyncOperation;
    }
}
