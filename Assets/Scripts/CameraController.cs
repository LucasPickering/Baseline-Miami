using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour
{

    [SerializeField]
    public GameObject target;

    void Update()
    {
        transform.position = target.transform.position - Vector3.forward;
    }
}
