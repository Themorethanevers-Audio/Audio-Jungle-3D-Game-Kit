using System;
using System.Collections.Generic;
using UnityEngine;
namespace _3DGamekit.Scripts.Audio.Implementation.Pooling
{ 
    public class AudioGrid
    {
        const int NUMBER_OF_CELLS = 500;
        const int SIZE_OF_CELL = 20;

        private List<AudioEmitter>[][] audioGridArray = new List<AudioEmitter>[NUMBER_OF_CELLS][];

        public void Add(AudioEmitter emitter)
        {
            int xIndex = GetPositionIndexAsInt(new Vector2(emitter.gameObject.transform.position.x,emitter.gameObject.transform.position.y), out var yIndex);

            audioGridArray[xIndex][yIndex].Add(emitter);
        }

        public void Remove(AudioEmitter emitter)
        {
            int xIndex = GetPositionIndexAsInt(new Vector2(emitter.gameObject.transform.position.x,emitter.gameObject.transform.position.y), out var yIndex);
            audioGridArray[xIndex][yIndex].Remove(emitter);
        }

        public void Get(List<AudioEmitter> queryList, Vector2 positionInGrid)
        {
            int xIndex = GetPositionIndexAsInt(positionInGrid, out var yIndex);
            for (int x = xIndex - 1; x < xIndex + 1; ++x)
            {
                for (int y = yIndex - 1; y < yIndex + 1; ++y)
                {
                    if (xIndex < 0 ||
                        xIndex >= NUMBER_OF_CELLS ||
                        yIndex < 0 ||
                        yIndex >= NUMBER_OF_CELLS) return;

                    List<AudioEmitter> gridList = audioGridArray[xIndex][yIndex];
                    foreach (AudioEmitter emitter in gridList)
                    {
                        queryList.Add(emitter);
                    }
                }
            }
        }
        
        private int GetPositionIndexAsInt(Vector2 position, out int yIndex)
        {
            int xIndex = Convert.ToInt32(position.x) / SIZE_OF_CELL;
            yIndex = Convert.ToInt32(position.y) / SIZE_OF_CELL;
            return xIndex;
        }
    }
}

