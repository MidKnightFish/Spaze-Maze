using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartLevel : MonoBehaviour
{
    private AssetBundle myLoadedAssetBundle;
    private string[] scenePaths;
    string realLevel = "8_Scene/Gate1.2";

    void Start()
    {
        realLevel.Trim();
        // myLoadedAssetBundle = AssetBundle.LoadFromFile("Assets/AssetBundles/scenes");
        // scenePaths = myLoadedAssetBundle.GetAllScenePaths();
    }

    void Update() {
        if (Input.GetKey(KeyCode.JoystickButton7))
    

        {
            //SceneManager.LoadScene(scenePaths[1], LoadSceneMode.Single);
            Debug.Log("Trying to load real Level: " + realLevel);
            SceneManager.LoadScene(realLevel, LoadSceneMode.Single);
        }
    }
}


