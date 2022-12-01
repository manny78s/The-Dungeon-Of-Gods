using UnityEngine;

public class BossCom : MonoBehaviour
{
    [SerializeField] public Animator Anim;
    [SerializeField] public Rigidbody2D Rb;
    [SerializeField] public Transform Pl_Pos;
    [SerializeField] public Transform Boss_Pos;
    [SerializeField] public bool LookRigth;
    [SerializeField] public float DisPL;
    [SerializeField] private float DisRayMin;
    [SerializeField] public float TimeRay;
    // Start is called before the first frame update
    void Start()
    {

        //Pl_Pos = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }
    private void Awake()
    {
        Anim = GetComponent<Animator>();
        Rb = GetComponent<Rigidbody2D>();
        Boss_Pos = GetComponent<Transform>();
        Pl_Pos = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        LookPlayer();
        DisPL = Vector2.Distance(Boss_Pos.position, Pl_Pos.position);
        Anim.SetFloat("DistancePL",DisPL);
        TimeRay += Time.deltaTime * 1;
        if(TimeRay >= 10 && DisPL > DisRayMin)
        {
            Anim.SetInteger("Ramdom", 1);
            TimeRay = 0;
        }
        else
        {
            Anim.SetInteger("Ramdom", 0);
            //TimeRay = 0;
        }
    }
    public void LookPlayer()
    {
        if(Boss_Pos.position.x > Pl_Pos.position.x)
        {
            Boss_Pos.localScale = new Vector3(-1,Boss_Pos.localScale.y, Boss_Pos.localScale.z);
        }
        else
        {
            Boss_Pos.localScale = new Vector3(1, Boss_Pos.localScale.y, Boss_Pos.localScale.z);
        }
    }
}
