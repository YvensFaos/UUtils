using UnityEditor;
using UnityEngine;

namespace UUtils.Editor
{
    [InitializeOnLoad]
    public class PlayInBackground : MonoBehaviour
    {
        private const string Item = "Edit/Play In Background";

        static PlayInBackground()
        {
            EditorApplication.delayCall += InitMenu;
        }

        private static void InitMenu()
        {
            Menu.SetChecked(Item, Application.runInBackground);
        }

        [MenuItem(Item, priority = 300)]
        public static void TogglePlayInBackground()
        {
            Menu.SetChecked(Item, !Menu.GetChecked(Item));
            Application.runInBackground = Menu.GetChecked(Item);
        }
    }
}