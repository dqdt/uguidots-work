using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;
using UGUIDots.Controls;

namespace ButtonExample {

    public struct ReleaseTag : IComponentData {}
    public struct ReleasePayload : IComponentData {
        public int Value;
    }

    public class ButtonReleasePayloadAuthoring : MonoBehaviour, IConvertGameObjectToEntity {
        public void Convert(Entity entity, EntityManager dstManager, GameObjectConversionSystem conversionSystem) {

            var msgEntity = dstManager.CreateEntity();
            dstManager.AddComponentData(msgEntity, new ReleaseTag {});
            dstManager.AddComponentData(msgEntity, new ReleasePayload {Value = 333});

            dstManager.AddComponentData(entity, new ButtonMessageFramePayload {Value = msgEntity});
        }
    }
}