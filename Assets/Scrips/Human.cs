using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.ARFoundation;
using UnityEngine.EventSystems;
[RequireComponent(typeof(ARRaycastManager))]
public class Human : MonoBehaviour
{
    Human human;
    //생성할 인디케이터
    [SerializeField]
    private GameObject indicator;

    public GameObject Myhuman;

    [SerializeField]
    private Button arButton1;

    [SerializeField]
    private Button arButton2;

    [SerializeField]
    private Button arButton3;

    public Text textUI;

    ARRaycastManager arManager;

    GameObject placedObject;

    public GameObject Object;

    GameObject[] avatar;

    Btn1 btn = new Btn1();
    public void ChangePrefabTo(string prefabName)
    {
        Myhuman = Resources.Load<GameObject>($"Prefab/{prefabName}");
        Object = (GameObject)Instantiate(Myhuman, indicator.transform.position, indicator.transform.rotation);
        if (Object == null)
        {
            Debug.LogError($"Prefab with name{prefabName} could not be loaded, make sure you check the naming of your prefabs...");
        }
    }

    void Awake()
    {
        indicator.SetActive(false);
        arManager = GetComponent<ARRaycastManager>();

    }

    // Update is called once per frame
    void Update()
    {
        DetectGround();
        if (Input.touchCount > 0)
        {
            //사람 모델링 생성
            //indicator가 활성화 되어있으면서 화면 터치가 있다면
            if (indicator.activeInHierarchy && Input.touchCount > 0)
            {
                Touch touch = Input.GetTouch(0);
                if (touch.phase == TouchPhase.Began)//손가락을 가져다 대자마자
                {
                    if (Object == null)
                    {
                        Object = Instantiate(Object, indicator.transform.position, indicator.transform.rotation);//오브젝트가 생기지 않았을떄만 생성
                    }
                    else if (Object != null && Object == Myhuman)
                    {
                        Object.transform.SetPositionAndRotation(indicator.transform.position, indicator.transform.rotation);//객체를 지우기 보단 위치만 변경                                                                                                    //placedObject = Instantiate(Object, indicator.transform.position, indicator.transform.rotation);//오브젝트가 생기지 않았을떄만 생성
                    }
                    else if (Object != null && Object != Myhuman)
                    {
                        Destroy(Object);
                        Object = Instantiate(Object, indicator.transform.position, indicator.transform.rotation);//오브젝트가 생기지 않았을떄만 생성
                    }
                }
                else if (touch.phase == TouchPhase.Stationary)
                {
                    if (Object != null)
                    {
                        indicator.SetActive(false);
                    }
                }
            }
        }

        //바닥 감지 및 indicator 츨력 함수
        void DetectGround()
        {
            Vector2 screenSize = new Vector2(Screen.width * 0.5f, Screen.height * 0.5f);
            List<ARRaycastHit> hitinfos = new List<ARRaycastHit>();
            //ray를 이용해 바닥 감지
            if (arManager.Raycast(screenSize, hitinfos, UnityEngine.XR.ARSubsystems.TrackableType.Planes))
            {
                //인디케이터 활성화
                indicator.SetActive(true);
                //인디케이터의 위치와 회전값을 레이가 닿은 지점에 일치
                indicator.transform.position = hitinfos[0].pose.position;
                indicator.transform.rotation = hitinfos[0].pose.rotation;
                //인디케이터 위치를 위로 0.1 미터 올림
                indicator.transform.position += indicator.transform.up * 0.1f;
            }
            else
            {
                indicator.SetActive(false);
            }
        }
    }
}
