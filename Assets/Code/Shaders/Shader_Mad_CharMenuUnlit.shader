Shader  "Madness/Menu/Character - MenuUnlitColor" {
	Properties {
		_UnlitColor("Color", Color) = (1,1,1,1)
		_ShineColor("Shine Color", Color) = (1,1,1,1)
		//_Color("Unlit Color", Color) = (1,1,1,1)
		_GlowColor("Glow Color", Color) = (0,0,0,0)				// Color glow on top of all other colors.
		_Outline("Outline Thickness", Range(0.05, 0.2)) = 0.05
		_OutlineColor("Outline Color", Color) = (0, 0, 0, 1)
		_TintColor("Tint Color", Color) = (0, 0, 0, 0)
	}


	SubShader {
	
	Tags { "RenderType" = "Opaque""IgnoreProjector"="True" }
	
	Tags { "Queue" = "Geometry+20" } 	// These are for outline behind walls. Transparency+50 is the old amount, but that would make these items overlap-silhouette EACHOTHER.

		Fog { Mode Off }


/////////////////////////////////////////
//			TOON OUTLINE
/////////////////////////////////////////
		UsePass "Madness/StoredPasses/Outline/OUTLINEMENU"

		
		
/////////////////////////////////////////
//			PRIMARY LIGHTS
/////////////////////////////////////////
		UsePass "Madness/StoredPasses/Primary/PRIMARYUNLITCOLOR"
		
		
		
		
	
	}
		//FallBack "Diffuse"

}