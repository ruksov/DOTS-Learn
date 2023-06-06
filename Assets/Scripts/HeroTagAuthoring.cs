using Unity.Entities;
using UnityEngine;

public class HeroTagAuthoring : MonoBehaviour
{
  public class HeroTagBaker : Baker<HeroTagAuthoring>
  {
    public override void Bake(HeroTagAuthoring authoring)
    {
      Entity entity = GetEntity(TransformUsageFlags.Dynamic);
      AddComponent(entity, new HeroTag());
    }
  }
}