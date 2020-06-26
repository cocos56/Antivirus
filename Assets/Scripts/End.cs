using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class End : MonoBehaviour
{
    public static bool win = true;
    public static int buildIndex = 0;
    public Text _endMessage;
    public GameObject townBg, cityBg, hospitalBg;
    
    void Start()
    {
        if (win)
        {
            _endMessage.text = "游戏胜利";
        }
        else
        {
            _endMessage.text = "游戏失败";
        }
        Select.DisplayBg(Select.sceneIndex, townBg, cityBg, hospitalBg);
    }

    public void Retry()
    {
        SceneManager.LoadSceneAsync(buildIndex);
    }
    
    public void Back()
    {
        SceneManager.LoadSceneAsync("Select");
    }
}
