using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneLoader : MonoBehaviour
{
    // Start is called before the first frame update
    public static SceneLoader Instance;
    [SerializeField] private GameObject root;
    [SerializeField] private Image progressbar;
    void Awake()
    {
        if (Instance == null)
            Instance = this;
        DontDestroyOnLoad(gameObject);
        root.gameObject.SetActive(false);
    }
    public void LoadScene(string sceneName) 
    {
        StartCoroutine(ILoadScene(sceneName));
    }
    IEnumerator ILoadScene(string name) 
    { 
        var scene = SceneManager.LoadSceneAsync(name);
        root.gameObject.SetActive(true);
        while (!scene.isDone) 
        {
            
            progressbar.fillAmount = scene.progress;
            Debug.Log($"scene.progress:{scene.progress}, progressbar.fillAmount:{progressbar.fillAmount}");
            yield return new WaitForEndOfFrame();

        }
        root.gameObject.SetActive(false);
    }
}
