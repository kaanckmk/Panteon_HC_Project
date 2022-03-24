using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(ObstacleTransform))]
public class ObstacleEditor : Editor
{
    private ObstacleTransform obstacleTransform;
    
    public override void OnInspectorGUI()
    {
        obstacleTransform = (ObstacleTransform) target;
        
        GUILayout.Label("Set the obstacle's position or rotation animations ");
        
        //Give Movement Animation
        if (GUILayout.Button("Move Obstacle"))
        {
            obstacleTransform.isMovable = true;
        }

        if (obstacleTransform.isMovable) CreateMoveGUI();
        
        //Give Rotation Animation
        if (GUILayout.Button("Rotate Obstacle"))
        {
            obstacleTransform.isRotatable = true;
        }
        if (obstacleTransform.isRotatable) CreateRotationGUI();
        
        //Give Punch Mechanic Animation
        if (GUILayout.Button("Make it punch!"))
        {
            obstacleTransform.isPunchable = true;
        }

        if (obstacleTransform.isPunchable)
        {
            obstacleTransform.movePositionPercentage = EditorGUILayout.Slider("Move to: ",obstacleTransform.movePositionPercentage, -1, 1);
        }
        
    }

    public void CreateMoveGUI()
    {
        obstacleTransform.movementduration = EditorGUILayout.FloatField("Duration to Complete 1 Loop", obstacleTransform.movementduration);
            
        obstacleTransform.movePositionPercentage = EditorGUILayout.Slider("Move to: ",obstacleTransform.movePositionPercentage, -1, 1);
        
    }

    public void CreateRotationGUI()
    {
        GUILayout.Label("Set 1 to rotate right, -1 to left, 0 to not rotate!");
        obstacleTransform.rotationX = EditorGUILayout.IntSlider("X Rotation: ", obstacleTransform.rotationX, -1, 1);
        obstacleTransform.rotationY = EditorGUILayout.IntSlider("Y Rotation: ", obstacleTransform.rotationY, -1, 1);
        obstacleTransform.rotationZ = EditorGUILayout.IntSlider("Z Rotation: ", obstacleTransform.rotationZ, -1, 1);
        obstacleTransform.rotationDuration = EditorGUILayout.FloatField("Duration to Complete 1 Loop", obstacleTransform.rotationDuration);
    }
    
}
