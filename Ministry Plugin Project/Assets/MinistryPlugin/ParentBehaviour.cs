using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ParentBehaviour : MonoBehaviour
{

    public string itemName;
    public string itemDescription;
    public int itemOrder;

    public static Sprite ministryLogo;


    [MenuItem("GameObject/Create Other/Ministry/Ministry Splash Screen[Mobile]")]
    static void StartCreate()
    {
        //PrefabUtility.CreateEmptyPrefab("Assets/MinistryPlugin/MinistryObject.prefab");
        var createSplashScreen = new GameObject();
        createSplashScreen.name = "MinistrySplashScreen";
        createSplashScreen.AddComponent<MinistrySplashScreen>();


        //name = createCanvas
        #region Create Splash Canvas

        var createCanvas = new GameObject();
        createCanvas.name = "SplashScreenCanvas";
        createCanvas.transform.SetParent(createSplashScreen.transform);
        createCanvas.layer = 5;

        //adding canvas related components
        Canvas canvas = createCanvas.AddComponent<Canvas>();
        canvas.renderMode = RenderMode.ScreenSpaceOverlay;
        CanvasScaler cs = createCanvas.AddComponent<CanvasScaler>();
        cs.scaleFactor = 10.0f;
        cs.dynamicPixelsPerUnit = 10f;
        //GraphicRaycaster gr = createCanvas.AddComponent<GraphicRaycaster>();
        createCanvas.GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, 3.0f);
        createCanvas.GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, 3.0f);

        //change to scale with screen size
        cs.uiScaleMode = CanvasScaler.ScaleMode.ScaleWithScreenSize;
        cs.referenceResolution = new Vector2(1080, 1920);
        #endregion

        #region Create Event System
        //create EventSystem
        if (GameObject.FindObjectOfType<EventSystem>() == null)
        {
            var createEventSystem = new GameObject();
            createEventSystem.AddComponent<EventSystem>();
            createEventSystem.AddComponent<StandaloneInputModule>();
            createEventSystem.name = "Event System";
        }
        else
        {
            Debug.LogWarning("Event System already exist!");
        }
        #endregion

        #region Create Image Child to Splash Canvas

        for (int i = 0; i < 2; i++)
        {
            var createImage = new GameObject();
            int num = i + 1;
            createImage.name = "SplashScreen" + num;
            createImage.AddComponent<Image>();
            createImage.transform.SetParent(createCanvas.transform);
            createImage.GetComponent<RectTransform>().anchoredPosition = Vector2.zero;
            createImage.GetComponent<RectTransform>().sizeDelta = new Vector2(1080, 1920);
        }
        

        #endregion

    }

}
