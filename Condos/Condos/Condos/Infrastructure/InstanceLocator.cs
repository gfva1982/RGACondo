using System;
using Condos.ViewModels;

namespace Condos.Infrastructure
{
    public class InstanceLocator
    {
        public MainViewModel Main
        {
            get;
            set;
        }

        public InstanceLocator()
        {
            Main = new MainViewModel();
        }
    }
}
