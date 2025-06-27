using UnityEngine;
using UnityEngine.SceneManagement;

public class Teleportingscript : MonoBehaviour
{
    public string TeleportingScene;

    void Start()
    {
        /*LevelManager.sceneName = TeleportingScene;
        LevelManager.Load(LevelManager.sceneName);*/

        LevelManager.Load(TeleportingScene);
    }

    void Update()
    {
        
    }
}
