using System;
using System.Collections.Generic;
using System.Text;

namespace Adohope.Modules.Contacts.Enums
{
    public enum LabelType
    {
        NullValue = 0
        , Mobile = 1
        , Home = 2
        , AlJawal = 3 // it means Mobile in arabic (الجوال)

        //todo: make sure that the following data is correct
        , Work = 4
        , iPhone = 5
        , Main = 6
        , HomeFax = 7
        , Pager = 8
        , Other = 9
    }
}
