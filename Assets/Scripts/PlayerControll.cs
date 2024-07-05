using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControll : MonoBehaviour
{
    [SerializeField] 
    private VariableJoystick joystick;
    [SerializeField]
    private GameObject arrowObject;
    private Rigidbody rb;

    [SerializeField]
    private float speed;
    private float angleA;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    private void Update()
    {
        if (Mathf.Atan2(joystick.Horizontal, joystick.Vertical) * Mathf.Rad2Deg != 0)
        { 
            angleA = Mathf.Atan2(joystick.Horizontal, joystick.Vertical) * Mathf.Rad2Deg; 
        }
        transform.eulerAngles = new Vector3(0f, angleA, 0f);

        if (Input.GetMouseButtonDown(0))
        {
            arrowObject.SetActive(true);
            Time.timeScale = 0.3f;
            Time.fixedDeltaTime = 0.02f * Time.timeScale;
        }
        else if(Input.GetMouseButtonUp(0))
        {
            arrowObject.SetActive(false);
            GameManager.instance.DecreaseChance();
            Time.timeScale = 1f;
            Time.fixedDeltaTime = 0.02f * Time.timeScale;
            Fire();
        }
    }

    private void Fire()
    {
        rb.AddRelativeForce(Vector3.forward * speed, ForceMode.Impulse);
    }
}
