using UnityEngine;

public class Box : MonoBehaviour
{
    public BoxCollider2D gridArea;
    public void Start()
    {
        RandomizePositionBox();
    }
    public void RandomizePositionBox()
    {
        Bounds bounds = this.gridArea.bounds;

        float x = Random.Range(bounds.min.x, bounds.max.x);
        float y = Random.Range(bounds.min.y, bounds.max.y);

        this.transform.position = new Vector3(Mathf.Round(x), Mathf.Round(y), 0.0f);

    }
}
