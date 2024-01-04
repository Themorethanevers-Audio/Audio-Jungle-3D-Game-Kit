using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace _3DGamekit.Scripts.Audio
{
    public abstract class AudioEmitter : MonoBehaviour
    {
        protected Transform emitterPosition;
        
        public abstract void Play(uint id);
        public abstract void UpdateEmitter();
        public abstract void SetEmitterPosition();
        
        protected abstract void RegisterAudioEmitter();
        protected abstract void DeregisterAudioEmitter();
    }

    public class BasicAudioEmitter : AudioEmitter
    {
        [SerializeField] private bool isEmitterMoving;
        public override void Play(uint id)
        {
            AkSoundEngine.PostEvent(id, gameObject);
        }

        public override void UpdateEmitter()
        {
            throw new System.NotImplementedException();
        }

        public override void SetEmitterPosition()
        {
            throw new System.NotImplementedException();
        }

        protected override void RegisterAudioEmitter()
        {
            throw new System.NotImplementedException();
        }

        protected override void DeregisterAudioEmitter()
        {
            throw new System.NotImplementedException();
        }
    }
}

