using UnityEngine;

public class SceneChanger : MonoBehaviour
{
    [SerializeField] private string nextScene;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name != "Player") return;
        GameState.ChangeScene(nextScene);
    }
}
