using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace City
{
    public class City : MonoBehaviour
    {
        /*
         * 用于处理游戏场景主循环及场景切换
         */
        public static int virus = 0;
        public static float time=100f;
        public Text virusText, timeText;

        // Start is called before the first frame update
        void Start()
        {
            End.buildIndex = SceneManager.GetActiveScene().buildIndex;
            time=100f;
        }
        
        // Update is called once per frame
        void Update()
        {
            virusText.text = virus.ToString().PadLeft(2,'0');
            timeText.text = time.ToString("f1").PadLeft(5,'0');
            time -= Time.deltaTime;
            if (virus<=0)
            {
                End.win = true;
                SceneManager.LoadSceneAsync("End");
            }
            else if (time<=0)
            {
                End.win = false;
                SceneManager.LoadSceneAsync("End");
            }
        }
        
        public void Quit()
        {
            End.win = false;
            SceneManager.LoadSceneAsync("End");
        }
    }   
}
