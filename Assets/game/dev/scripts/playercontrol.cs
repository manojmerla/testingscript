using UnityEngine;

public class playercontrol : MonoBehaviour
{
    public float mousesensitivity;
    public int runspeed = 2;
    public float xrotation = 0f;
    public Rigidbody rb;
    public Transform cam;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        // ===== SHOOT =====
        if (Input.GetKeyDown(KeyCode.Space))
        {
            RaycastHit hit;

          if (Physics.Raycast(transform.position, transform.forward, out hit, 20f))
            {
                Enemy e = hit.collider.GetComponent<Enemy>();

                if (e != null)
                {
                    e.TakeDamage(2);
                }
            }
        }

        // ===== MOUSE LOOK =====
        float Mousex = Input.GetAxis("Mouse X") * mousesensitivity * Time.deltaTime;
        float MouseY = Input.GetAxis("Mouse Y") * mousesensitivity * Time.deltaTime;

        xrotation -= MouseY;
        xrotation = Mathf.Clamp(xrotation, -60f, 60f);

        cam.localRotation = Quaternion.Euler(xrotation, 0f, 0f);
        transform.Rotate(Vector3.up * Mousex);
    }

    void FixedUpdate()
    {
        float h = Input.GetAxis("Horizontal") * runspeed;
        float v = Input.GetAxis("Vertical") * runspeed;

        Vector3 move = transform.right * h + transform.forward * v;

        rb.linearVelocity = new Vector3(move.x, rb.linearVelocity.y, move.z);
    }
}
