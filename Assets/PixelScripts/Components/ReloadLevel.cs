using UnityEngine;
using UnityEngine.SceneManagement;

namespace Platformer.Components
{
    public class ReloadLevel : MonoBehaviour
    {
        public void Reload()
        {
            var scene = SceneManager.GetActiveScene();
            SceneManager.LoadScene(scene.name);
        }
    }
}
