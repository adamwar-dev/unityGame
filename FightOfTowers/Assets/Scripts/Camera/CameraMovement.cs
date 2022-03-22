using UnityEngine;

/*
* Adam Warzecha
* Camera Movement Script
*/
public class CameraMovement : MonoBehaviour
{
	[SerializeField] GameObject ground;
	[SerializeField] float moveCameraSpeed = 5;
	[SerializeField] float moveCameraSpeedFast = 10;

	void FixedUpdate()
	{
		MoveCamera();
	}

	void MoveCamera() {
		float cameraHalfWidth = Camera.main.orthographicSize * Camera.main.aspect;
		float groundWidth = ground.transform.localScale.x;
		float mapStart = ground.transform.position.x - groundWidth/2;
		float mapEnd = mapStart + groundWidth - transform.localScale.x/2;

		if (Input.mousePosition.y < Screen.height * 0.8) {
			if (Input.mousePosition.x > Screen.width * 0.9 && Input.mousePosition.x < Screen.width * 0.97 && transform.position.x < mapEnd) {
				transform.position = new Vector3(transform.position.x + moveCameraSpeed * Time.deltaTime, transform.position.y, transform.position.z);
			} 
			else if (Input.mousePosition.x >= Screen.width * 0.97 && transform.position.x < mapEnd) {
				transform.position = new Vector3(transform.position.x + moveCameraSpeedFast * Time.deltaTime, transform.position.y, transform.position.z);
			}
			else if (Input.mousePosition.x < Screen.width * 0.1 && Input.mousePosition.x > Screen.width * 0.03 && transform.position.x > mapStart + transform.localScale.x/2) {
				transform.position = new Vector3(transform.position.x - moveCameraSpeed * Time.deltaTime, transform.position.y, transform.position.z);
			}
			else if (Input.mousePosition.x <= Screen.width * 0.03 && transform.position.x > mapStart + transform.localScale.x/2) {
				transform.position = new Vector3(transform.position.x - moveCameraSpeedFast * Time.deltaTime, transform.position.y, transform.position.z);
			}
		}
	}
}
