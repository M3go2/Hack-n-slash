using UnityEngine;

public class HeartRotation : MonoBehaviour
{
    public float rotationSpeed = 30f; // Adjust the rotation speed as needed

    void Update()
    {
        // Create a Vector3 representing rotation around the Y-axis
        Vector3 rotation = new Vector3(0, rotationSpeed * Time.deltaTime, 0);

        // Apply the rotation to the transform
        transform.Rotate(rotation);
    }
}