using Unity.Entities;
using UnityEngine;

public class SpeedAuthoring : MonoBehaviour
{
  public float Value;
  
  public class Baker : Baker<SpeedAuthoring>
  {
    public override void Bake(SpeedAuthoring authoring)
    {
      Entity entity = GetEntity(TransformUsageFlags.Dynamic);
      AddComponent(entity, new Speed
      {
        Value = authoring.Value
      });
    }
  }
}