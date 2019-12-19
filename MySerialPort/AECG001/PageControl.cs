using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AECG100Demo
{
    interface IPageControl
    {
        void onConnected ();
        void onStartOutput ();
    }
}
