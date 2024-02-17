using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowRocket : MonoBehaviour
{
    public Transform target;
    private bool isChasing;
    private Launcher launcher;
    // Start is called before the first frame update
    void Start()
    {
        launcher = GetComponent<Launcher>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Alpha1))
        {
            target = GameObject.FindObjectOfType<Rocket>().gameObject.transform;
            transform.parent = null;
            isChasing = true;
            launcher.enabled = false;
        }
    }
    private void LateUpdate()
    {
        if (isChasing)
        {
            transform.forward = target.forward;
            transform.position = Vector3.Lerp(transform.position, target.position, Time.deltaTime);
        }
    }
}
