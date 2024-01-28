using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
    [SerializeField]
    private Rigidbody2D carRigidBody;
    [SerializeField]
    private GameObject Car;

    private void OnEnable()
    {
        StartCoroutine(DelayRegistration());
    }

    private IEnumerator DelayRegistration()
    {
        yield return new WaitForEndOfFrame();
        GameManager.Instance.OnLaunchCar += Instance_OnLaunchCar;
    }

    private void Instance_OnLaunchCar(Vector2 startPos, int direction)
    {
        carRigidBody.MovePosition(startPos);
        carRigidBody.gameObject.transform.localScale = new Vector3(direction, 1, 1);
        carRigidBody.velocity = new Vector2(10*-direction, 0);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Limits"))
        {
            carRigidBody.velocity = Vector2.zero;
        }
    }

    private void OnDisable()
    {
        GameManager.Instance.OnLaunchCar -= Instance_OnLaunchCar;
    }
}
