using UnityEngine;

public class GameObjectAutoAdd : MonoBehaviour
{
    private void Awake()
    {
        GameObjectList.Add(this.gameObject);
    }

    private void OnDestroy()
    {
        GameObjectList.Remove(this.gameObject);
    }
}
