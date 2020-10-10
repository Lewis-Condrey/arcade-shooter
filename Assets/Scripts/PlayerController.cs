
using UnityEngine;
using UnityEngine.PlayerLoop;

public class PlayerController : MonoBehaviour
{
    //movement related 
    public float moveSpeed;
    private Rigidbody myRigidbody;
    private Vector3 moveInput;
    private Vector3 moveVelocity;
    private Camera mainCamera;

    //gun related
    public GunController theGun;

    //controller
    //main menu controller selection bools
    public static bool useController;
    public static bool usePSController;
    public static bool useXController;

    //in editor testing bools
    public bool useC;
    public bool usePS;
    public bool useX;

    // Start is called before the first frame update
    void Start()
    {
        myRigidbody = GetComponent<Rigidbody>();
        mainCamera = FindObjectOfType<Camera>();
    }

    // Update is called once per frame
    public void Update()
    {
        moveInput = new Vector3(Input.GetAxisRaw("Horizontal"), 0f, Input.GetAxisRaw("Vertical"));
        moveVelocity = moveInput * moveSpeed;


        if (!usePS && !useX)
        {
            useC = false;
            useController = false;
        }

        if (usePS)
        {
            usePSController = true;
            useC = true;
            useXController = false;
            useController = true;
        }

        if (useX)
        {
            useC = true;
            useXController = true;
            useController = true;
            usePSController = false;
        }

        

        //Mouse rotation
        if (!usePSController && !useXController && !useController)
        {
            // getting mouse postion from camera view
            Ray cameraRay = mainCamera.ScreenPointToRay(Input.mousePosition);
            Plane groundPlane = new Plane(Vector3.up, Vector3.zero);
            float rayLength;

            //getting the raycast and pointing the player at it 
            if (groundPlane.Raycast(cameraRay, out rayLength))
            {
                Vector3 pointToLook = cameraRay.GetPoint(rayLength);
                Debug.DrawLine(cameraRay.origin, pointToLook, Color.blue);
                transform.LookAt(new Vector3(pointToLook.x, transform.position.y, pointToLook.z));

            }

            if (Input.GetMouseButtonDown(0))
            {
                theGun.isFiring = true;
            }
            if (Input.GetMouseButtonUp(0))
            {
                theGun.isFiring = false;
            }
        }

        if (useController)
        {
            // Ps Controller rotation
            if (usePSController)
            {
                Vector3 playerDirection = Vector3.right * Input.GetAxisRaw("PSHorizontal") + Vector3.forward * -Input.GetAxisRaw("PSVertical");
                if (playerDirection.sqrMagnitude > 0.0f)
                {
                    transform.rotation = Quaternion.LookRotation(playerDirection, Vector3.up);
                }
                if (Input.GetKeyDown(KeyCode.Joystick1Button7))
                    theGun.isFiring = true;
                if (Input.GetKeyUp(KeyCode.Joystick1Button7))
                    theGun.isFiring = false;
            }

            // x Controller rotation
            if (useXController)
            {
                Vector3 playerDirection = Vector3.right * Input.GetAxisRaw("XHorizontal") + Vector3.forward * -Input.GetAxisRaw("XVertical");
                if (playerDirection.sqrMagnitude > 0.0f)
                {
                    transform.rotation = Quaternion.LookRotation(playerDirection, Vector3.up);
                }
                if (Input.GetKeyDown(KeyCode.Joystick1Button5))
                    theGun.isFiring = true;
                if (Input.GetKeyUp(KeyCode.Joystick1Button5))
                    theGun.isFiring = false;
            }
        }

        if (!usePSController && !useXController)
        {
            useController = false;
        }
    }
    private void FixedUpdate()
    {
        myRigidbody.velocity = moveVelocity;
    }

     
}
