/*
    NTP3DI
    Copyright (C) 2020-2023 boris.mitrin@gmail.com

    Permission is hereby granted, free of charge, to any person obtaining
    a copy of this software and associated documentation files 
    (the "Software"), to deal in the Software without restriction, including
    without limitation therights to use, copy, modify, merge, publish,
    distribute, sublicense, and/or sell copies of the Software, and to permit
    persons to whom the Software is furnished to do so, subject to
    the following conditions:

    The above copyright notice and this permission notice shall be included in
    all copies or substantial portions of the Software.

    THE SOFTWARE IS PROVIDED “AS IS”, WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
    IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
    FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL
    THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
    LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING 
    FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER 
    DEALINGS IN THE SOFTWARE.
*/
using System;
using System.Collections.Concurrent;

namespace NTP3.DI
{
    public class DependencyContainer
    {
        private static readonly ConcurrentDictionary<Type, object> ObjectRepository = new ConcurrentDictionary<Type, object>();

        private static readonly ConcurrentDictionary<Type, Func<object>> FactoryRepository =
            new ConcurrentDictionary<Type, Func<object>>();

        public static void Register<T>(Func<T> factory) where T : class
        {
            if (!FactoryRepository.TryAdd(typeof(T), factory))
            {
                throw new InvalidOperationException($"Factory for {typeof(T).Name} has been registered already");
            }
        }

        public static T GetInstance<T>() where T : class
        {
            if (!FactoryRepository.TryGetValue(typeof(T), out Func<object> factory))
            {
                throw new InvalidOperationException($"Factory for {typeof(T).Name} has not been registered yet");
            }
            return (T)ObjectRepository.GetOrAdd(typeof(T), _ => factory());
        }
    }
}
