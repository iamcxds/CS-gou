using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed=6.0f;
    public float rayDistence = 100.0f;
   // Rigidbody rg;
    Animator ani;
    Vector3 movement;
    public LayerMask mask;
    void Awake()
    {
       // rg= GetComponent<Rigidbody>();
        ani = GetComponent<Animator>();
    }
    private void FixedUpdate()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        Move(h, v);
        Turn();
        Animating(h * h + v * v);
    }
    private void Move(float h,float v)
    {
        movement.Set(h, 0, v);
        movement = movement.normalized * speed * Time.deltaTime;
        transform.Translate(movement, Space.World);
    }
    void Turn()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if(Physics.Raycast(ray,out hit, rayDistence, mask))
        {
            Vector3 toMouse = hit.point - transform.position;
            toMouse.y = 0;
            transform.rotation = Quaternion.LookRotation(toMouse);
        }
    }
    void Animating(float x)
    {
        bool animate = (x != 0);
        ani.SetBool("IsWalking", animate);
    }

}
