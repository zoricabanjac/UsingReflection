﻿using System.Collections.Generic;
using System.Reflection;

namespace UsingReflection.Entities
{
    public class MyClassInfo
    {
        public string Namespace { get; set; }
        public string ClassName { get; set; }
        public string FullName { get; set; }
       
        public string Assambly { get; set; }
        public TypeAttributes Attributes { get; set; }
        public string BaseType { get; set; }
        public string Module { get; set; }

        public List<MyConstructorInfo> ConstructorsList { get; set; }
        public List<MyPropertyInfo> PropertiesList { get; set; }
        public List<MyFieldInfo> FieldsList { get; set; }
        public List<MyMethodInfo> MethodsList { get; set; }
        public List<MyEventInfo> EventsList { get; set; }
    }
}