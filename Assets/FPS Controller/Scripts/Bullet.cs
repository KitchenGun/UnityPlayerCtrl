using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private void OnEnable()
    {
        StartCoroutine(SetDisactiveAfter(5f));
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Obstacle"))
        {
            Destroy(collision.gameObject);
        }
        //Destroy(this.gameObject);
        gameObject.SetActive(false);
    }

    private IEnumerator SetDisactiveAfter(float sec)
    {
        yield return new WaitForSeconds(sec);
        gameObject.SetActive(false);
    }

    private void OnDisable()
    {
        gameObject.transform.localPosition = Vector3.zero;
        gameObject.transform.rotation = Quaternion.identity;
        GetComponent<Rigidbody>().velocity = Vector3.zero;
        GetComponent<Rigidbody>().angularVelocity=Vector3.zero;
    }
}
