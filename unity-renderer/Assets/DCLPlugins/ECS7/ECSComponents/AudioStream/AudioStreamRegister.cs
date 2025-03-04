﻿using System;
using DCL.ECSRuntime;

namespace DCL.ECSComponents
{
    public class AudioStreamRegister : IDisposable
    {
        private readonly ECSComponentsFactory factory;
        private readonly IECSComponentWriter componentWriter;
        private readonly int componentId;

        public AudioStreamRegister(int componentId, ECSComponentsFactory factory, IECSComponentWriter componentWriter)
        {
            factory.AddOrReplaceComponent(componentId, AudioStreamSerializer.Deserialize, () => new ECSAudioStreamComponentHandler());
            componentWriter.AddOrReplaceComponentSerializer<PBAudioStream>(componentId, AudioStreamSerializer.Serialize);

            this.factory = factory;
            this.componentWriter = componentWriter;
            this.componentId = componentId;
        }

        public void Dispose()
        {
            factory.RemoveComponent(componentId);
            componentWriter.RemoveComponentSerializer(componentId);
        }
    }
}