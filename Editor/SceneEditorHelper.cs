/*
 * Copyright (c) 2025 Yvens R Serpa [https://github.com/YvensFaos/]
 * 
 * This work is licensed under the Creative Commons Attribution 4.0 International License.
 * To view a copy of this license, visit http://creativecommons.org/licenses/by/4.0/
 * or see the LICENSE file in the root directory of this repository.
 */
using System.Linq;
using UnityEditor;

namespace UUtils.Editor
{
    public static class SceneEditorHelper
    {
        public static EditorBuildSettingsScene FindSceneInBuild(string sceneName)
        {
            var scenes = EditorBuildSettings.scenes;
            var foundScene = scenes.ToList().Find(editorBuildSettingsScene =>
            {
                var sceneNamePath = editorBuildSettingsScene.path.Split('/').Last();
                return sceneNamePath.Equals($"{sceneName}.unity");
            });
            return foundScene;
        }
    }
}