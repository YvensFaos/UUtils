/*
 * Copyright (c) 2025 Yvens R Serpa [https://github.com/YvensFaos/]
 * 
 * This work is licensed under the Creative Commons Attribution 4.0 International License.
 * To view a copy of this license, visit http://creativecommons.org/licenses/by/4.0/
 * or see the LICENSE file in the root directory of this repository.
 */
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
