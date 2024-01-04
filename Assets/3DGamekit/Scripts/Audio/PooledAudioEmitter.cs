namespace _3DGamekit.Scripts.Audio.Implementation.Pooling
{
    public class PooledAudioEmitter
    {
        public AudioEmitter audioEmitter;
        public PooledAudioEmitter nextPooledEmitter;
    }

    public class AudioEmitterPool
    {
        public const int MAX_POOL_SIZE = 500;
        public PooledAudioEmitter firstEmitter;
        public PooledAudioEmitter[] emitterPool = new PooledAudioEmitter[MAX_POOL_SIZE];
        
        public AudioEmitterPool()
        {
            firstEmitter = emitterPool[0];
            for (int i = 0; i < MAX_POOL_SIZE ; i++)
            {
                PooledAudioEmitter temp = firstEmitter;
                firstEmitter = emitterPool[i];
                firstEmitter.nextPooledEmitter = temp;
            }
        }

        public PooledAudioEmitter GetFreeAudioEmitter()
        {
            if (firstEmitter == null) return null;
            
            PooledAudioEmitter temp = firstEmitter;
            firstEmitter = firstEmitter.nextPooledEmitter;
            return temp;
        }

        public void ReturnAudioEmitter(PooledAudioEmitter emitter)
        {
            PooledAudioEmitter temp = firstEmitter;
            firstEmitter = emitter;
            firstEmitter.nextPooledEmitter = temp;
        }
    }
}

