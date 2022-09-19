using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float panSpeed = 30f;
    public float panBorderThickness = 10f;

    public float scrollspeed = 5f;
    public float minY = 10f;
    public float maxY = 80f;
    public float minX = 25f;
    public float maxX = 90f;
    public float minZ = 0f;
    public float maxZ = 75f;
    // Update is called once per frame
    void Update() {
        if (GameManager.gameIsOver) {
            this.enabled = false;
            return;
        }

        if (Input.GetKey("d") || Input.mousePosition.x >= Screen.width - panBorderThickness) {
            transform.Translate(Vector3.forward * panSpeed * Time.deltaTime, Space.World);
        }

        if (Input.GetKey("a") || Input.mousePosition.x <= panBorderThickness) {
            transform.Translate(Vector3.back * panSpeed * Time.deltaTime, Space.World);
        }

        if (Input.GetKey("s") || Input.mousePosition.y <= panBorderThickness) {
            transform.Translate(Vector3.right * panSpeed * Time.deltaTime, Space.World);
        }

        if (Input.GetKey("w") || Input.mousePosition.y >= Screen.height - panBorderThickness) {
            transform.Translate(Vector3.left * panSpeed * Time.deltaTime, Space.World);
        }
        
        float scroll = Input.GetAxis("Mouse ScrollWheel");

        Vector3 pos = transform.position;

        pos.y -= scroll * 1000 * scrollspeed * Time.deltaTime;
        pos.y = Mathf.Clamp(pos.y, minY, maxY);
        pos.x = Mathf.Clamp(pos.x, minX, maxX);
        pos.z = Mathf.Clamp(pos.z, minZ, maxZ);

        transform.position = pos;

    }
}
