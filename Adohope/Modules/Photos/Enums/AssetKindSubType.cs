using System;
using System.Collections.Generic;
using System.Text;

namespace Adohope.Modules.Photos.Enums
{
    public enum AssetKindSubType
    {
        Camera = 0 //ZKIND=(0|1)
        , Panorama = 1 //ZKIND=0
        , LivePhoto = 2 //ZKIND=0
        , Screenshot = 10 //ZKIND=0
        , SloMo = 101 //ZKIND=1
        , TimeLapse = 102 //ZKIND=1
        , ScreenRecording = 103 //ZKIND=1
        , Selfie //ZKIND=(0|1)?
        , Burst //ZKIND=?
        , All = -1
    }
}
