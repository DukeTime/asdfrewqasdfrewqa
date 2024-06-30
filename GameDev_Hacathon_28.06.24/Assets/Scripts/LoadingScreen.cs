using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadingScreen : MonoBehaviour
{
    [SerializeField] private Animator loadingAnim;
    void Start()
    {
        //loadingAnim.SetTrigger("Hide");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SceneChange(int scene_num)
    {
        loadingAnim.SetTrigger("Reveal");
        StartCoroutine(LoadingScene(scene_num));
    }

    IEnumerator LoadingScene(int scene_num)
    {
        AsyncOperation loadAcync = SceneManager.LoadSceneAsync(scene_num);
        //loadAcync.allowSceneActivation = false;

        while (!loadAcync.isDone)
        {
            //if (loadAcync.progress > 0.9f && !loadAcync.allowSceneActivation)
            //{
            //    Debug.Log("1 sec");
            //    yield return new WaitForSeconds(1f);
            //    loadAcync.allowSceneActivation = true;
            //}
            yield return null;
        }
    }
}
