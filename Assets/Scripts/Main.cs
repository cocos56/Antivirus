using UnityEngine;
using UnityEngine.SceneManagement;

public class Main : MonoBehaviour
{
    
    private float interval = 2f;
    public GameObject townBg, cityBg, hospitalBg;
    
    private float cnt = 0f;
    private int index = 0;
    
    void Update()
    {
        cnt += Time.deltaTime;
        if (cnt>=interval)
        {
            cnt = 0f;
            index = (index+1)%3;
            // Debug.Log(index);
            Select.DisplayBg(index, townBg, cityBg, hospitalBg);
        }
    }

    public void OnStartGame()
    {
        SceneManager.LoadSceneAsync("Select");
    }
    
    public void OnExitGame()
    {
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #else
            Application.Quit();
        #endif
    }
}