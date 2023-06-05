using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;
using UnityEngine;

public readonly partial struct MoveToPositionAspect : IAspect
{
    private readonly RefRW<LocalTransform> m_transform;
    private readonly RefRO<Speed> m_speed;
    private readonly RefRW<TargetPosition> m_targetPosition;

    public float3 TargetPosition
    {
        get => m_targetPosition.ValueRO.Position;
        set => m_targetPosition.ValueRW.Position = value;
    }

    public bool TargetIsReached() => 
        math.distancesq(m_transform.ValueRO.Position, TargetPosition) == 0;

    public void Move(float deltaTime)
    {
        float3 moveVector = m_targetPosition.ValueRO.Position - m_transform.ValueRO.Position;
        float distanceToTarget = math.length(moveVector);
        if (distanceToTarget == 0) 
            return;
      
        float moveDistance = Mathf.Min( distanceToTarget, m_speed.ValueRO.Value * deltaTime);
        float3 direction = math.normalize(moveVector);

        m_transform.ValueRW.Position += direction * moveDistance;
    }
}