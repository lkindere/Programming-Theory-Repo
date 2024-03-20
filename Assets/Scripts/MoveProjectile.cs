using System.Collections;
using UnityEngine;

public class MoveProjectile : MonoBehaviour
{
    private float speed = 2.0f;
    private float sampleTime = 0.0f;
    private Vector3 startPos;
    public Vector3 targetPos;
    public Vector3 controlPos;

    void Start()
    {
        startPos = transform.position;
    }

    void Update()
    {
        sampleTime += Time.deltaTime * speed;
        if (sampleTime <= 1.0f) {
            transform.position = Evaluate(sampleTime);
        }
        else
            StartCoroutine(DestroyObject());
    }

    private Vector3 Evaluate(float t) {
        Vector3 ac = Vector3.Lerp(startPos, controlPos, t);
        Vector3 cb = Vector3.Lerp(controlPos, targetPos, t);

        return Vector3.Lerp(ac, cb, t);
    }

    private IEnumerator DestroyObject() {
        yield return new WaitForSeconds(1.0f);

        Destroy(gameObject);
    }
}
