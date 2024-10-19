using UnityEngine;

public class GameController : MonoBehaviour
{
    public static GameController Instance;
    public Light[] wireLights; // Array of lights representing wire connections

    void Awake()
    {
        Instance = this;
    }

    public void CheckConnection(Color wireColor, Color endColor)
    {
        if (wireColor == endColor)
        {
            // Light up the corresponding light
            foreach (Light light in wireLights)
            {
                if (light.color == wireColor)
                {
                    light.enabled = true;
                }
            }
        }
    }
}
