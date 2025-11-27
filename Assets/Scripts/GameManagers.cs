using UnityEngine;
using UnityEngine.Tilemaps;

public class GameManagers : MonoBehaviour
{
    [SerializeField] Tilemap tilemap;
    [SerializeField] TileBase tileBase;

    private void Update()
    {
        Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3Int cellPos = tilemap.WorldToCell(mouseWorldPos);

        Debug.Log(cellPos); // —á: (0,1), (0,2)
    }
}
