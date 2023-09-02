using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class launchercotroll : MonoBehaviour
{

    public Collider bola;
    public KeyCode input;
    public float maxForce;
    public float maxTimeHold;


    private bool isHold = false;

    private void OnCollisionStay(Collision collision)
    {
        if(collision.collider == bola)
        {
            ReadInput(bola);
        }
    }

    private void ReadInput(Collider collider)
    {
        if (Input.GetKey(input) && !isHold)
        {
           StartCoroutine(StartHold(collider));
        }
    }

    private IEnumerator StartHold()
    {
        isHold = true;
        float force = 0.0f;
        float timeHold = 0.0f;

        while (Input.GetKey(input))
        {
            force = Mathf.Lerp(0, maxForce, timeHold/maxTimeHold);

            yield return new WaitForEndOfFrame();
            timeHold += Time.deltaTime;
        }
        GetComponent<Collider>().GetComponent<Rigidbody>().AddForce(Vector3.forward * Force);
        isHold = false;
    }
}
