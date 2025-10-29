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