using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CameraAndGroundController : MonoBehaviour
{
    public float rotationSpeed = 150f;
    public GameObject ground;
    public float pitchThreshold = 30f;
    public Slider sensitivitySlider;
    public TMP_InputField inputField;

    private float pitch = 0f;
    private float yaw = 0f;

    private Vector3 initialPosition;
    private Vector3 initialRotation;

    void Start()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        initialPosition = transform.position;
        initialRotation = transform.eulerAngles;

        if (ground != null)
        {
            ground.SetActive(true);
        }
        else
        {
            Debug.LogError("Ground is not assigned!");
        }

        if (sensitivitySlider != null)
        {
            sensitivitySlider.onValueChanged.AddListener(AdjustSensitivity);
            sensitivitySlider.value = rotationSpeed;
        }
        else
        {
            Debug.LogError("Sensitivity slider is not assigned!");
        }
    }

    void Update()
    {
        if (!TMPInputFieldToggle.inputFieldIsFocused)
        {
            if (Input.GetKey(KeyCode.W))
            {
                pitch -= rotationSpeed * Time.deltaTime;
            }
            if (Input.GetKey(KeyCode.S))
            {
                pitch += rotationSpeed * Time.deltaTime;
            }
            if (Input.GetKey(KeyCode.A))
            {
                yaw -= rotationSpeed * Time.deltaTime;
            }
            if (Input.GetKey(KeyCode.D))
            {
                yaw += rotationSpeed * Time.deltaTime;
            }
        }

        pitch = Mathf.Clamp(pitch, -90f, 90f);
        transform.eulerAngles = new Vector3(pitch, yaw, 0f);

        if (pitch >= pitchThreshold)
        {
            ground?.SetActive(false);
        }
        else
        {
            ground?.SetActive(true);
        }

        if (Input.GetKey(KeyCode.R) && Input.GetKey(KeyCode.LeftControl))
        {
            ResetCameraPosition();
        }
    }

    public void AdjustSensitivity(float newSensitivity)
    {
        rotationSpeed = newSensitivity;
    }

    private void ResetCameraPosition()
    {
        transform.position = initialPosition;
        transform.eulerAngles = initialRotation;
        pitch = initialRotation.x;
        yaw = initialRotation.y;
        Debug.Log("Camera reset to original position.");
    }
}