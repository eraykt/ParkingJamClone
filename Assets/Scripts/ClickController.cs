using UnityEditor;
using UnityEngine;

public class ClickController : MonoBehaviour
{
    private Vector3 _firstPos;
    private Vector3 _lastPos;
    RaycastHit hit, hit2;

    private bool go;

    private void Update()
    {
        Click();
    }

    private void Click()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.CompareTag("Car"))
                {
                    var position = hit.transform.position;
                    _firstPos = new Vector3(position.x, 0f, position.z);
                }
            }
        }

        if (Input.GetMouseButtonUp(0))
        {
            Ray ray2 = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray2, out hit2))
            {
                var position = hit2.point;
                _lastPos = new Vector3(position.x, 0f, position.z);

                go = true;
            }
        }

        DetectWay();
    }

    private void DetectWay()
    {
        if (hit.collider && hit2.collider && go &&
            hit.collider.GetComponent<CarController>().way == CarController.Direction.Further)
        {
            CarController car = hit.collider.GetComponent<CarController>();

            if (_lastPos.x - _firstPos.x > 0)
            {
                car.DriveCar(1);
                go = false;
            }

            else if (_lastPos.x - _firstPos.x < 0)
            {
                car.DriveCar(-1);
                go = false;
            }
        }

        else if (hit.collider && hit2.collider && go &&
                 hit.collider.GetComponent<CarController>().way == CarController.Direction.Side)
        {
            CarController car = hit.collider.GetComponent<CarController>();

            if (_lastPos.z - _firstPos.z < 0)
            {
                car.DriveCar(-1);
                go = false;
            }

            else if (_lastPos.z - _firstPos.z > 0)
            {
                car.DriveCar(1);
                go = false;
            }
        }
    }
}