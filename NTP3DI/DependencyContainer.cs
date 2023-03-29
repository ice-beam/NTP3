/*
    This file is part of NTP3
    Copyright (C) 2020-2023 boris.mitrin@gmail.com

    NTP3 is free software: you can redistribute it and/or modify
    it under the terms of the GNU General Public License as published by
    the Free Software Foundation, either version 3 of the License, or
    (at your option) any later version.

    This program is distributed in the hope that it will be useful,
    but WITHOUT ANY WARRANTY; without even the implied warranty of
    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
    GNU General Public License for more details.

    You should have received a copy of the GNU General Public License
    along with this program.  If not, see <http://www.gnu.org/licenses/>.
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
