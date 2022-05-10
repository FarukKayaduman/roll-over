using UnityEngine;
using UnityEngine.UI;

public class StarCount : MonoBehaviour
{
    public Text starCountText;

    public GameObject gameObject;

    void Update()
    {
        starCountText.text = gameObject.GetComponent<PlayerCollision>().numberOfStarTriggered.ToString("0");
    }
}
