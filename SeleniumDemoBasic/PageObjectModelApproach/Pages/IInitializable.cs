using System;
using System.Collections.Generic;
using System.Text;

namespace SeleniumDemoBasic.PageObjectModelApproach.Pages
{
    public interface IInitializable<T> where T: class
    {
        T Initialize();
    }
}
