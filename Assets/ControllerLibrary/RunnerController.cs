using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RunnerController : MonoBehaviour {

    public float speed = 10.0f;
    public LayerMask structure;
    public Transform feet;
    public float jumpHeight;
    public float gravity;
	public Text testDisplay;

    private Vector3 walkingVelocity;
    private Vector3 fallingVelocity;
    private CharacterController controller;
	private float freezeIntensity;
	private GameController gameController;

    // Use this for initialization
    void Start () {
        gravity = 9.8f;
        jumpHeight = 3.0f;
        fallingVelocity = Vector3.zero;
        controller = GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked;
		freezeIntensity = 1.0f;

		GameObject gameControllerObject = GameObject.FindWithTag("GameController");
		if (gameControllerObject != null)
		{
			gameController = gameControllerObject.GetComponent<GameController> ();
		}
		if (gameControllerObject == null)
		{
			Debug.Log("Cannot find 'GameController' script");
		}
	}
	
	// Update is called once per frame
	void Update () {
        float horiz = Input.GetAxis("Horizontal");
        float vert = Input.GetAxis("Vertical");

		freezeIntensity = (1.0f / (1.0f - gameController.getIntensity())) + gameController.getIntensity() * gameController.pillsBoostSpeed;
		Vector3 moveDirSide = transform.right * horiz * speed * freezeIntensity;
		Vector3 moveDirForward = transform.forward * vert * speed * freezeIntensity;

		if (!gameController.getIsAsleep ())
		{
        	controller.Move(moveDirSide * Time.deltaTime);
        	controller.Move(moveDirForward * Time.deltaTime);
			transform.position += new Vector3 (gameController.getDrunkenPlayerX (), 0, gameController.getDrunkenPlayerZ ());
		}

        bool isOnStructure = Physics.CheckSphere(feet.position, 0.1f, structure, QueryTriggerInteraction.Ignore);
        if (isOnStructure)
            fallingVelocity.y = 0f;
        else
            fallingVelocity.y -= gravity * Time.deltaTime;
		if (Input.GetButtonDown("Jump") && isOnStructure && !gameController.getIsAsleep())
        {
			fallingVelocity.y = Mathf.Sqrt(gravity * jumpHeight) + gameController.getIntensity() * gameController.pillsBoostJump;
        }
        controller.Move(fallingVelocity * Time.deltaTime);

		//Pour les test :
        if (Input.GetKeyDown("escape"))
        {
                Cursor.lockState = CursorLockMode.None;
        }
		if (Input.GetButtonDown("Fire1"))
		{
			Cursor.lockState = CursorLockMode.Locked;
		}
		testDisplay.text += "\nMove forward: " + (moveDirForward.magnitude) + " " + (moveDirForward.magnitude * Time.deltaTime);
    }
}
