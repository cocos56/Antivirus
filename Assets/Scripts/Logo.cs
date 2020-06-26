using UnityEngine;
using UnityEngine.SceneManagement;

public class Logo : MonoBehaviour
{
    private float cnt=0f, interval = 3f;

    // Update is called once per frame
    void Update()
    {
        cnt += Time.deltaTime;
        if (cnt >= interval)
        {
            cnt = 0f;
            SceneManager.LoadSceneAsync("Main");
        }
    }
}
