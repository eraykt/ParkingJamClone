using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Manager { get; private set; }

    public Transform cars;
    public GameObject text;

    public int carCount;

    private void Awake()
    {
        Manager = this;
    }

    private void Start()
    {
        foreach (Transform transform1 in cars)
        {
            carCount++;
        }
    }


    private void Update()
    {
        WinScreen();
    }

    void WinScreen()
    {
        if (carCount == 0)
        {
            text.SetActive(true);
        }
    }
}