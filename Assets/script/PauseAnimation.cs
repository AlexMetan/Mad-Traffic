using UnityEngine;

public class PauseAnimation : MonoBehaviour
{
    Animation pauseAnim;

    void Start() 
    {
        pauseAnim=GetComponent<Animation>();
    }
    public void PlayAnimationOut()
    {
        pauseAnim.Play("pauseout");
    }
}
