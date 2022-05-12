using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OnSpaceScene : MonoBehaviour
{

    public Animator sceneTransition;

    void Update()
    {
       if (this.transform.position.y < -5)
       {
            StartCoroutine(LoadLevel());
       }
    }

    IEnumerator LoadLevel()
    {
        sceneTransition.SetTrigger("Start");
        yield return new WaitForSeconds(0.5f);
        SceneManager.LoadScene("Space");
    }
}
