using UnityEngine;
using UnityEngine.SceneManagement;

namespace town
{
    public class NextScene : MonoBehaviour
    {

        // Use this for initialization
        public void retry()//重玩
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        
        public void back()//返回
        {
            SceneManager.LoadScene("Select");
        }
    }
}