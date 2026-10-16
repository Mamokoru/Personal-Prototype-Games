using UnityEngine;
using UnityEditor;

public class FitColliderShortcuts
{
    // This adds a shortcut to the Component context menu (Right-click Box Collider -> Fit to Mesh)
    [MenuItem("CONTEXT/BoxCollider/Fit to Mesh")]
    static void FitToMesh(MenuCommand command)
    {
        Debug.LogWarning("Called");
        GameObject selectedObj = Selection.activeGameObject;

        BoxCollider boxCollider = (BoxCollider)command.context;
        Renderer meshRenderer = boxCollider.GetComponentInChildren<MeshRenderer>();

        if (meshRenderer == null)
        {
            meshRenderer = boxCollider.GetComponentInChildren<SkinnedMeshRenderer>();
        }
        Bounds worldBounds = meshRenderer.bounds;

        // Transform the world bounds center into the object's local space
        Vector3 localCenter = selectedObj.transform.InverseTransformPoint(worldBounds.center);

        // Unscale the world size back to local size to prevent multiplication scaling issues
        Vector3 localSize = worldBounds.size;
        Vector3 lossyScale = selectedObj.transform.lossyScale;

        localSize.x /= lossyScale.x != 0 ? lossyScale.x : 1f;
        localSize.y /= lossyScale.y != 0 ? lossyScale.y : 1f;
        localSize.z /= lossyScale.z != 0 ? lossyScale.z : 1f;

        // Apply to the Box Collider
        boxCollider.center = localCenter;
        boxCollider.size = localSize;

        Debug.Log($"Successfully fit BoxCollider to '{selectedObj.name}' mesh bounds.");
    }
}
