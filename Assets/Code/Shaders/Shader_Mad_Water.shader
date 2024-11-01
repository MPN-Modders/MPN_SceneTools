Shader "Madness/Fluid Ripple" {
	Properties {
		_MainTex ("Base (RGB)", 2D) = "white" {}
		_Color ("Color", Color) = (1,0,0,1)
		//_Cutoff ("Alpha cutoff", Range(0,1)) = 0.5
		_Transparent ( "Transparent", Range (0, 1) ) = 1


	DispMap ("Displacement Map (RG)", 2D) = "white" {} // From Distort
	//_MaskTex ("Mask (R)", 2D) = "white" {}	// From Distort (But used for blade swoosh, not needed)
	_DispScrollSpeedX  ("Map Scroll Speed X", Float) = 0
	_DispScrollSpeedY  ("Map Scroll Speed Y", Float) = 0
	_StrengthX  ("Displacement Strength X", Float) = 1
	_StrengthY  ("Displacement Strength Y", Float) = -1

	}


	SubShader {

		Tags {"LightMode"="ForwardBase" "IgnoreProjector"="True" "Queue"="Transparent+60"}  
		LOD 100
		Lighting Off
		//AlphaTest Greater [_Cutoff]
		AlphaTest Greater [fixed (0.001)]  // This and ZWrite off is where alpha cutout technique comes from: http://docs.unity3d.com/Documentation/Components/SL-AlphaTest.html
		Cull Off
		ZTest Less
		ZWrite off
		Fog { Mode Off }
		Blend SrcAlpha OneMinusSrcAlpha

		Pass {
		
			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag
			#pragma multi_compile_fwdbase
				#pragma fragmentoption ARB_precision_hint_fastest // From Distort
				#include "UnityCG.cginc" // From Distort

			uniform sampler2D _MainTex;
			uniform fixed4 _Color;
			uniform fixed _Transparent;
			
			uniform half _StrengthX; // From Distort
			uniform half _StrengthY;
			uniform sampler2D _DispMap;
			//uniform sampler2D _MaskTex;
			uniform half _DispScrollSpeedY;
			uniform half _DispScrollSpeedX;

			struct vertexInput{
				fixed4 vertex : POSITION;
				fixed4 texcoord : TEXCOORD0; // Distort needed 2 of this...?
					float2 param : TEXCOORD1; // From Distort 
			};
			struct vertexOutput{
				fixed4 pos : SV_POSITION;
				fixed4 tex : TEXCOORD0;
					float2 uvmain : TEXCOORD0; // From Distort
					float2 param : TEXCOORD1; // From Distort
					float4 uvgrab : TEXCOORD2; // From Distort
			};



			vertexOutput vert (vertexInput v) {
				vertexOutput o;
				o.pos = mul( UNITY_MATRIX_MVP, v.vertex );

					 // From Distort
					#if UNITY_UV_STARTS_AT_TOP	
					float scale = -1.0;
					#else
					float scale = 1.0;
					#endif

					 // From Distort
					o.uvgrab.xy = (float2(o.pos.x, o.pos.y*scale) + o.pos.w) * 0.5;
					o.uvgrab.zw = o.pos.zw;
					o.uvmain = TRANSFORM_TEX( v.texcoord, _DispMap );

				o.tex = v.texcoord;
				
				return o;
			}
			
			fixed4 frag (vertexOutput i) : COLOR {


					 // From Distort
				
						//scroll displacement map.
					half2 mapoft = half2(_Time.y*_DispScrollSpeedX, _Time.y*_DispScrollSpeedY);

						//get displacement color
					half4 offsetColor = tex2D(_DispMap, i.uvmain + mapoft);

						//get offset
					half oftX =  offsetColor.r * _StrengthX * i.param.x;
					half oftY =  offsetColor.g * _StrengthY * i.param.x;

					i.uvgrab.x += oftX;
					i.uvgrab.y += oftY;

					half4 displacementColor = tex2Dproj( _GrabTexture, UNITY_PROJ_COORD(i.uvgrab));
					

				fixed4 myTexture = tex2D(_MainTex, i.tex.xy);

				return fixed4(_Color.r, _Color.g, _Color.b, myTexture.a * _Transparent) * displacementColor;
					
			}
			
			
			ENDCG
		}
	} 
	SubShader {
		Blend SrcAlpha OneMinusSrcAlpha
		Pass {
			Name "BASE"
			SetTexture [_MainTex] {	combine texture * primary double, texture * primary }
		}
	}

}
