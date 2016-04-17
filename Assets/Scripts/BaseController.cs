using UnityEngine;
using System.Collections;

public class BaseController : MonoBehaviour {

	void OnControllerColliderHit(ControllerColliderHit hit)
    {
        Debug.Log("Potato");
    }
}
