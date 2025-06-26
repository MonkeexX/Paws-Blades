using UnityEngine;
using UnityEngine.SceneManagement;

public static class LevelManager
{
    public static void Load(string sceneName) => SceneManager.LoadScene(sceneName);
    public static void LoadAsync(string sceneName) => SceneManager.LoadSceneAsync(sceneName);
}
