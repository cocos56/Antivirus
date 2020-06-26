using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

[RequireComponent(typeof(Dropdown))]
public class Select : MonoBehaviour
{
    public Dropdown drop;
    public GameObject townBg, cityBg, hospitalBg;
    public static int sceneIndex = 0;

    private void Start()
    {
        drop.onValueChanged.AddListener(Change);
    }
    
    private void Change(int index)
    {
        sceneIndex = index;
        DisplayBg(index, townBg, cityBg, hospitalBg);
    }

    public static void DisplayBg(int index, GameObject townBg, GameObject cityBg, GameObject hospitalBg)
    {
        switch (index)
        {
            case 0:
                townBg.SetActive(true);
                cityBg.SetActive(false);
                hospitalBg.SetActive(false);
                break;
            case 1:
                townBg.SetActive(false);
                cityBg.SetActive(true);
                hospitalBg.SetActive(false);
                break;
            case 2:
                townBg.SetActive(false);
                cityBg.SetActive(false);
                hospitalBg.SetActive(true);
                break;
        }
    }

    public void Begin()
    {
        switch (drop.value)
        {
            case 0 : SceneManager.LoadSceneAsync("Town");
                break;
            case 1 : SceneManager.LoadSceneAsync("City");
                break;
            case 2 : SceneManager.LoadSceneAsync("Hospital");
                break;
            default:
                break;
        }
    }
    
    public void Back()
    {
        SceneManager.LoadSceneAsync("Main");
    }
}
