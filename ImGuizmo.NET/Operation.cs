using System;

namespace Ktisis.ImGuizmo;

[Flags]
public enum Operation {
	/* Main flags */
	TRANSLATE_X   = 0x0001,
	TRANSLATE_Y   = 0x0002,
	TRANSLATE_Z   = 0x0004,
	ROTATE_X      = 0x0008,
	ROTATE_Y      = 0x0010,
	ROTATE_Z      = 0x0020,
	ROTATE_SCREEN = 0x0040,
	SCALE_X       = 0x0080,
	SCALE_Y       = 0x0100,
	SCALE_Z       = 0x0200,
	BOUNDS        = 0x0400,
	SCALE_XU      = 0x0800,
	SCALE_YU      = 0x1000,
	SCALE_ZU      = 0x2000,

	/* Utility combinations, same as Dalamud library */
	TRANSLATE = TRANSLATE_X | TRANSLATE_Y | TRANSLATE_Z,
	ROTATE = ROTATE_X | ROTATE_Y | ROTATE_Z | ROTATE_SCREEN,
	SCALE = SCALE_X | SCALE_Y | SCALE_Z,
	SCALE_U = SCALE_XU | SCALE_YU | SCALE_ZU,
	UNIVERSAL = TRANSLATE | ROTATE | SCALE_U
}


/* Flag tree for this set:
                  .- ( 1 <<  0) TRANSLATE_X
                 .+- ( 1 <<  1) TRANSLATE_Y
                .++- ( 1 <<  2) TRANSLATE_Z
              .-+++- ( 1 <<  3) ROTATE_X
             .+-+++- ( 1 <<  4) ROTATE_Y
            .++-+++- ( 1 <<  5) ROTATE_Z
           .+++-+++- ( 1 <<  6) ROTATE_SCREEN
         .-++++-+++- ( 1 <<  7) SCALE_X
        .+-++++-+++- ( 1 <<  8) SCALE_Y
       .++-++++-+++- ( 1 <<  9) SCALE_Z
     .-+++-++++-+++- ( 1 << 10) BOUNDS
   .-+-+++-++++-+++- ( 1 << 11) SCALE_XU
  .+-+-+++-++++-+++- ( 1 << 12) SCALE_YU
 .++-+-+++-++++-+++- ( 1 << 13) SCALE_ZU
 ||| | ||| |||| |||
 ___ _ ___ ____ ___

*/
