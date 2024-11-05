using UnityEngine;
using UnityEngine.SceneManagement;

namespace UUtils
{
    public class ApplicationHelper : MonoBehaviour
    {
        public void QuitApplicationCommand()
        {
            QuitApplication();
        }

        public void RestartLevel()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

        public void GoToScene(string scene)
        {
            SceneManager.LoadScene(scene);
        }
        
        public static void QuitApplication()
        {
            #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
            #else
            Application.Quit();
            #endif
        }
    }
}
