﻿//
//  Author:
//    Charles Yust charles.yust@frogdesign.com
//
//  Copyright (c) 2016, frog design
//
//  All rights reserved.
//
//  Redistribution and use in source and binary forms, with or without modification, are permitted provided that the following conditions are met:
//
//     * Redistributions of source code must retain the above copyright notice, this list of conditions and the following disclaimer.
//     * Redistributions in binary form must reproduce the above copyright notice, this list of conditions and the following disclaimer in
//       the documentation and/or other materials provided with the distribution.
//     * Neither the name of frog design nor the names of its contributors may be used to endorse or promote products derived from this software without specific prior written permission.
//
//  THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS
//  "AS IS" AND ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT
//  LIMITED TO, THE IMPLIED WARRANTIES OF MERCHANTABILITY AND FITNESS FOR
//  A PARTICULAR PURPOSE ARE DISCLAIMED. IN NO EVENT SHALL THE COPYRIGHT OWNER OR
//  CONTRIBUTORS BE LIABLE FOR ANY DIRECT, INDIRECT, INCIDENTAL, SPECIAL,
//  EXEMPLARY, OR CONSEQUENTIAL DAMAGES (INCLUDING, BUT NOT LIMITED TO,
//  PROCUREMENT OF SUBSTITUTE GOODS OR SERVICES; LOSS OF USE, DATA, OR
//  PROFITS; OR BUSINESS INTERRUPTION) HOWEVER CAUSED AND ON ANY THEORY OF
//  LIABILITY, WHETHER IN CONTRACT, STRICT LIABILITY, OR TORT (INCLUDING
//  NEGLIGENCE OR OTHERWISE) ARISING IN ANY WAY OUT OF THE USE OF THIS
//  SOFTWARE, EVEN IF ADVISED OF THE POSSIBILITY OF SUCH DAMAGE.
//

using UnityEngine;
using System.Collections;

public class SkyDomeStar : MonoBehaviour {

	public GameObject rotateX; 
	public GameObject rotateZ;

	private const float SPEED_CONST = .02f;
	private const float SPEED_MAX = .5f;

	private float angleX;
	private float angleZ;
	private Vector3 localAxisX = new Vector3 (1, 0, 0);
	private Vector3 localAxisZ = new Vector3 (0, 0, 1);

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	}

	public void rotateContX(float speed) {
		float angleX = rotateX.transform.rotation.eulerAngles.x;
		speed *= SPEED_CONST;
		angleX += speed;
		rotateX.transform.RotateAround (new Vector3 (), localAxisX, speed);
	}
		
	public void rotateContZ(float speedX, float speedZ) {
		speedX *= SPEED_CONST;
		angleX += speedX;
		speedZ *= SPEED_CONST * -1.0f;
		angleZ += speedZ;
		rotateZ.transform.RotateAround (new Vector3 (), localAxisZ, speedZ);
	}

	// SINGLETON ROTATION
	public void rotX() {
		float speedX = SPEED_MAX * (PlayerInputSingleton.Instance.getXPer () - .5f) * -1f;
		rotateX.transform.RotateAround (new Vector3 (), localAxisX, speedX);
	}
	public void rotZ() {
		float speedZ = SPEED_MAX * (PlayerInputSingleton.Instance.getZPer () - .5f) * -1f;
		rotateZ.transform.RotateAround (new Vector3 (), localAxisZ, speedZ);
	}
	public void rotXZ() {
		float speedX = SPEED_MAX * (PlayerInputSingleton.Instance.getXPerDeg () - .5f) * -1f;
		float speedZ = SPEED_MAX * (PlayerInputSingleton.Instance.getZPerDeg () - .5f) * -1f;
		rotateZ.transform.Rotate(speedX, 0f, speedZ, Space.World);
	}
}