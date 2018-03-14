using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MinistrySplashScreen : MonoBehaviour {

    //public string nextSceneName = "Put Intro Scene Name Here";

    private Sprite ministryLogo;

    public float splashLogoTime = 2.5f;

    [SerializeField]
    private Image ministrySplashScreen;
    public Image otherSplashScreen;

    private void Awake()
    {
        ministryLogo = Resources.Load<Sprite>("MSplashScreen");

        ministrySplashScreen = this.transform.GetChild(0).GetChild(0).GetComponent<Image>();
        otherSplashScreen = this.transform.GetChild(0).GetChild(1).GetComponent<Image>();
        ministrySplashScreen.sprite = ministryLogo;

        StartCoroutine("SplashMethod");
    }


    IEnumerator SplashMethod()
    {
        transform.GetChild(0).GetChild(0).gameObject.SetActive(false);
        transform.GetChild(0).GetChild(1).gameObject.SetActive(false);
        transform.GetChild(0).GetChild(0).gameObject.SetActive(true);
        yield return new WaitForSeconds(splashLogoTime);
        transform.GetChild(0).GetChild(0).gameObject.SetActive(false);

        if (otherSplashScreen.sprite != null)
        {
            transform.GetChild(0).GetChild(1).gameObject.SetActive(true);
            yield return new WaitForSeconds(splashLogoTime);
            //SceneManager.LoadScene(nextSceneName);
            Destroy(this.gameObject);

        }

        else if(otherSplashScreen.sprite == null)
        {
            try
            {
                //SceneManager.LoadScene(nextSceneName);
                Destroy(this.gameObject);
            }
            catch (System.Exception ex)
            {
                throw;

               // Debug.Log("No such scene detected: " + ex);
            }
            
        }

    }


}
