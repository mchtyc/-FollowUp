using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RingPlacer : PipeItemGenerator {

	public PipeItem[] itemPrefabs;
	private int skippedSegment = 5; 

	public void Start(){
		
	}

	public override void GenerateItems (Pipe pipe) {
		float angleStep = pipe.CurveAngle / pipe.CurveSegmentCount;

		for (int i = 3; i < pipe.CurveSegmentCount; i += skippedSegment) {
			for (int j = 0, p = 0; j < pipe.pipeSegmentCount; j++, p++) {
				if (p == itemPrefabs.Length) {
					p = 0;
				}
				PipeItem item = Instantiate<PipeItem>(itemPrefabs[p]);

				float pipeRotation = j * 360f / pipe.pipeSegmentCount;
				
				item.Position(pipe, i * angleStep, pipeRotation);
			}
		}
	}
}
