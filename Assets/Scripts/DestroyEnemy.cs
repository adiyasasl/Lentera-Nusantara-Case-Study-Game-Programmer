using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyEnemy : MonoBehaviour
{
    public string nameObject;
    public GameObject[] enemys;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            nameObject = collision.transform.name;
            Invoke("DestroyObject", 0.2f);
        }
    }

    private void DestroyObject()
    {
        foreach(GameObject enemy in enemys)
        {
            if(enemy.name == nameObject)
            {
                enemy.SetActive(false);
            }
        }
    }
}
