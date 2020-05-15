using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;
using UGUIDots.Controls;

namespace ButtonExample {

    public struct HoldTag : IComponentData {}
    public struct HoldPayload : IComponentData {
        public int Value;
    }

    public class ButtonHoldPayloadAuthoring : MonoBehaviour, IConvertGameObjectToEntity {
        public void Convert(Entity entity, EntityManager dstManager, GameObjectConversionSystem conversionSystem) {

            var msgEntity = dstManager.CreateEntity();
            dstManager.AddComponentData(msgEntity, new HoldTag {});
            dstManager.AddComponentData(msgEntity, new HoldPayload {Value = 444});

            dstManager.AddComponentData(entity, new ButtonMessageFramePayload {Value = msgEntity});
        }
    }
}