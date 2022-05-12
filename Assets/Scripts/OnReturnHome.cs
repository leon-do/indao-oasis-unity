using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OnReturnHome : MonoBehaviour
{
    public Animator sceneTransition;
    void Update()
    {
         // when player press R
         if (Input.GetKeyDown(KeyCode.R))
         {
            StartCoroutine(LoadLevel());
         }

         if (Input.GetKeyDown(KeyCode.B))
         {
            // open website
            Application.OpenURL("https://gaming.chainsafe.io/");
         }
    }

    IEnumerator LoadLevel()
    {
        sceneTransition.SetTrigger("Start");
        yield return new WaitForSeconds(0.5f);
        SceneManager.LoadScene("Ship");
    }
}
