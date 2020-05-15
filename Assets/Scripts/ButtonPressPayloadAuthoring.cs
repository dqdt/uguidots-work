using System.Collections;
using System.Collections.Generic;


using UnityEngine;
using Unity.Entities;
using UGUIDots.Controls;

namespace ButtonExample {

    public struct PressTag : IComponentData {}
    public struct PressPayload : IComponentData {
        public int Value;
    }

    public class ButtonPressPayloadAuthoring : MonoBehaviour, IConvertGameObjectToEntity {
        public void Convert(Entity entity, EntityManager dstManager, GameObjectConversionSystem conversionSystem) {

            var msgEntity = dstManager.CreateEntity();
            dstManager.AddComponentData(msgEntity, new PressTag {});
            dstManager.AddComponentData(msgEntity, new PressPayload {Value = 222});

            dstManager.AddComponentData(entity, new ButtonMessageFramePayload {Value = msgEntity});
        }
    }
}