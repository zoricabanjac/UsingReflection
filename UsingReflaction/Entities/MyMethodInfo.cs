﻿using System.Collections.Generic;
using System.Reflection;

namespace UsingReflection.Entities
{
    public class MyMethodInfo
    {
        public MethodInfo MethodInfo { get; set; }
        public string MethodName { get; set; }
        public string ReturnType { get; set; }
        public MemberTypes MemberType { get; set; }

        public List<MyParameterInfo> Parameters { get; set; }

        private string parametersTypeName;
        public string ParametersTypeName
        {
            get
            {
                foreach (MyParameterInfo parameter in Parameters)
                {
                    parametersTypeName += parameter.ParameterType + " " + parameter.ParameterName;
                    if (Parameters.IndexOf(parameter) < Parameters.Count - 1)
                    {
                        parametersTypeName += ", ";
                    }
                }

                return parametersTypeName;
            }
            set
            {
                parametersTypeName = value;
            }
        }

        public MyMethodInfo(MemberTypes memberType, MethodInfo methodInfo, string returnType, string methodName, List<MyParameterInfo> parameters)
        {
            MemberType = memberType;
            MethodInfo = methodInfo;
            MethodName = methodName;
            ReturnType = returnType;
            Parameters = parameters;
        }
    }
}
