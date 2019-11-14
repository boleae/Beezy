using BeezyTest.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Unity;
using Unity.Lifetime;

namespace BeezyTest.Unity
{
    public static class Container
    {
        #region Properties

        static IUnityContainer currentContainer;

        public static IUnityContainer Current
        {
            get
            {
                return currentContainer;
            }
        }

        #endregion

        #region Constructor

        static Container()
        {
            currentContainer = new UnityContainer();
        }

        #endregion

        public static void Register<TFrom, TTo>() where TTo : TFrom
        {
            Current.RegisterType<TFrom, TTo>(new HierarchicalLifetimeManager());
        }

        public static void Register<TFrom, TTo>(Enum parameter) where TTo : TFrom
        {
            Current.RegisterType<TFrom, TTo>(EnumStringAttribute.GetSearchValue(parameter), new HierarchicalLifetimeManager()); ;
        }

        public static T Resolve<T>()
        {
            return Resolve<T>(string.Empty);
        }

        public static T Resolve<T>(Enum enumValue)
        {
            return Resolve<T>(EnumStringAttribute.GetSearchValue(enumValue));
        }



        private static T Resolve<T>(string name)
        {
            return (T)Current.Resolve(typeof(T), name);
        }

    }
}