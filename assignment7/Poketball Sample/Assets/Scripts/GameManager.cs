using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    UIManager MyUIManager;

    public GameObject BallPrefab;   // prefab of Ball

    // Constants for SetupBalls
    public static Vector3 StartPosition = new Vector3(0, 0, -6.35f);
    public static Quaternion StartRotation = Quaternion.Euler(0, 90, 90);
    const float BallRadius = 0.286f;
    const float RowSpacing = 0.02f;

    GameObject PlayerBall;
    GameObject CamObj;

    const float CamSpeed = 3f;

    const float MinPower = 15f;
    const float PowerCoef = 1f;

    void Awake()
    {
        // PlayerBall, CamObj, MyUIManager를 얻어온다.
        // ---------- TODO ---------- 
        PlayerBall = GameObject.Find("PlayerBall");
        CamObj = GameObject.Find("Main Camera");
        MyUIManager = FindObjectOfType<UIManager>();
        // -------------------- 
    }

    void Start()
    {
        SetupBalls();
    }

    // Update is called once per frame
    void Update()
    {
        // 좌클릭시 raycast하여 클릭 위치로 ShootBallTo 한다.
        // ---------- TODO ---------- 
        if(Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if(Physics.Raycast(ray, out hit))
            {
                ShootBallTo(hit.point);
            }   
        }
        // -------------------- 
    }

    void LateUpdate()
    {
        CamMove();
    }

    void SetupBalls()
    {
        // 15개의 공을 삼각형 형태로 배치한다.
        // 가장 앞쪽 공의 위치는 StartPosition이며, 공의 Rotation은 StartRotation이다.
        // 각 공은 RowSpacing만큼의 간격을 가진다.
        // 각 공의 이름은 {index}이며, 아래 함수로 index에 맞는 Material을 적용시킨다.
        // Obj.GetComponent<MeshRenderer>().material = Resources.Load<Material>("Materials/ball_1");
        // ---------- TODO ---------- 
        int ballCount = 0;
        int totalRows = 5;
        for(int row=0;row<totalRows;row++)
        {
            int ballsInRow = row + 1;
            for(int i=0;i<ballsInRow;i++)
            {
                Vector3 pos = StartPosition;
                float xOffset = (-(ballsInRow - 1) * (BallRadius + RowSpacing)) / 2f + i * (BallRadius * 2 + RowSpacing);
                float zOffset = row * (BallRadius * 2 + RowSpacing);
                pos.x += xOffset;
                pos.z += zOffset;
                GameObject obj = Instantiate(BallPrefab, pos, StartRotation);
                obj.name = ballCount.ToString();
                string matName = "Materials/ball_" + (ballCount + 1).ToString();
                Material mat = Resources.Load<Material>(matName);
                if (mat != null)
                {
                    obj.GetComponent<MeshRenderer>().material = mat;
                }
                else
                {
                    Debug.LogWarning("Material " + matName + " not found.");
                }
                ballCount++;
            }
        }
        // -------------------- 
    }
    void CamMove()
    {
        // CamObj는 PlayerBall을 CamSpeed의 속도로 따라간다.
        // ---------- TODO ---------- 
        Vector3 targetPos = PlayerBall.transform.position;
        Vector3 currentPos = CamObj.transform.position;
        targetPos.y = currentPos.y;
        CamObj.transform.position = Vector3.Lerp(currentPos, targetPos, Time.deltaTime * CamSpeed);
        // -------------------- 
    }

    float CalcPower(Vector3 displacement)
    {
        return MinPower + displacement.magnitude * PowerCoef;
    }

    void ShootBallTo(Vector3 targetPos)
    {
        // targetPos의 위치로 공을 발사한다.
        // 힘은 CalcPower 함수로 계산하고, y축 방향 힘은 0으로 한다.
        // ForceMode.Impulse를 사용한다.
        // ---------- TODO ---------- 
        Rigidbody rb = PlayerBall.GetComponent<Rigidbody>();
        Vector3 displacement = targetPos - PlayerBall.transform.position;
        displacement.y = 0;
        float power = CalcPower(displacement);
        Vector3 force = displacement.normalized * power;
        rb.AddForce(force, ForceMode.Impulse);
        // -------------------- 
    }
    
    // When ball falls
    public void Fall(string ballName)
    {
        // "{ballName} falls"을 1초간 띄운다.
        // ---------- TODO ---------- 
        MyUIManager.DisplayText(ballName + " falls", 1.0f);
        // -------------------- 
    }
}
