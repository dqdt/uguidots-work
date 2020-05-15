using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;
using UGUIDots;
using UGUIDots.Controls;

namespace ButtonExample {

    [UpdateInGroup(typeof(MessagingUpdateGroup))]
    public class ProcessButtonMessageRequestSystem : SystemBase {
        protected override void OnUpdate() {
            
            // Press events
            Dependency = Entities
                .WithAll<ButtonMessageRequest>()
                .ForEach(
                    (in PressPayload c0) => {
                    
                    Debug.Log($"Button Press payload = {c0.Value}");

                }).ScheduleParallel(Dependency);
            
            // Release events
            Dependency = Entities
                .WithAll<ButtonMessageRequest>()
                .ForEach(
                    (in ReleasePayload c0) => {
                    
                    Debug.Log($"Button Release payload = {c0.Value}");
                    
                }).ScheduleParallel(Dependency);

            // Hold events
            Dependency = Entities
                .WithAll<ButtonMessageRequest>()
                .ForEach(
                    (in HoldPayload c0) => {
                    
                    Debug.Log($"Button Hold payload = {c0.Value}");
                    
                }).ScheduleParallel(Dependency);
        }
    }
}