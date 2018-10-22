using UnityEngine;

public class CameraBehaviour : MonoBehaviour
{
    public Transform target;
    private float distance = 10.0f, height = 5.0f;
    public float minDistance, maxDistance, minHeight, maxHeight, heightDamping, rotationDamping;

    public Vector3 sensibilite;

    // Update is called once per frame
    void LateUpdate()
    {
        // Early out if we don't have a target
        if (!target)
            return;
        //calcular a distancia
        distance -= Input.GetAxis("Mouse ScrollWheel") * sensibilite.z;
        distance = Mathf.Clamp(distance, minDistance, maxDistance);

        //calcular altura
        height -= Input.GetAxis("Mouse Y") * sensibilite.y;
        height = Mathf.Clamp(height, minHeight, maxHeight);
        // Calculate the current rotation angles
        float wantedRotationAngle = target.eulerAngles.y;
        float wantedHeight = target.position.y + height;

        float currentRotationAngle = transform.eulerAngles.y;
        float currentHeight = transform.position.y;
		
		
		// Damp the rotation around the y-axis
		currentRotationAngle = Mathf.LerpAngle(currentRotationAngle, wantedRotationAngle, rotationDamping * Time.deltaTime);
        
		// Damp the height
        currentHeight = Mathf.Lerp(currentHeight, wantedHeight, heightDamping * Time.deltaTime);

        // Convert the angle into a rotation
        Quaternion currentRotation = Quaternion.Euler(0, transform.eulerAngles.y + Input.GetAxis("Mouse X") * sensibilite.x, 0);

        // Set the position of the camera on the x-z plane to:
        // distance meters behind the target
        transform.position = target.position;
        transform.position -= currentRotation * Vector3.forward * distance;

        // Set the height of the camera
        transform.position = new Vector3(transform.position.x, currentHeight, transform.position.z);

        // Always look at the target
        transform.LookAt(target);
    }
}
