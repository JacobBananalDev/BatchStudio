using System;

namespace BatchStudio.Infrastructures
{
    public abstract class SingletonBase<T> where T: class
    {
        private static readonly Lazy<T> m_SingletonInstance = new Lazy<T>(() => CreateInstanceOfT());
        public static T Instance => m_SingletonInstance.Value;

        private static T CreateInstanceOfT()
        {
            return Activator.CreateInstance(typeof(T), true) as T;
        }
    }
}
