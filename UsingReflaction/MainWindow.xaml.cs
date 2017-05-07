﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using UsingReflaction.Entities;
using UsingReflaction.TestEntities;

namespace UsingReflaction
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            MyClassInfo myClass = new MyClassInfo();

            Type type = GetType(txtClassName.Text);

            myClass.ClassName = type.Name;
            txbClassName.Text = myClass.ClassName;

            myClass.Assambly = type.Assembly.FullName;
            txbAssambly.Text = myClass.Assambly;

            myClass.Attributes = type.Attributes;
            txbAttributes.Text = myClass.Attributes.ToString();

            myClass.BaseType = type.BaseType.Name;
            txbBaseType.Text = myClass.BaseType;

            myClass.FullName = type.FullName;
            txbFullName.Text = myClass.FullName;

            myClass.Namespace = type.Namespace;
            txbNamespace.Text = myClass.Namespace;

            myClass.Module = type.Module.Name;
            txbModule.Text = myClass.Module;

            //List<MyNestedTypeInfo> nestedList = new List<MyNestedTypeInfo>();
            //foreach (Type nestedType in type.GetNestedTypes())
            //{
            //    nestedList.Add(new MyNestedTypeInfo(nestedType.ToString()));
            //}
            //myClass.NestedTupesList = nestedList;

            List<MyFieldInfo> myFields = new List<MyFieldInfo>();
            foreach (FieldInfo info in type.GetFields())
            {
                string infoType = (((FieldInfo)(info)).FieldType).FullName;
                string infoName = ((FieldInfo)(info)).Name;

                myFields.Add(new MyFieldInfo(info, infoName, infoType, info.MemberType));
            }
            myClass.FieldsList = myFields;

            List<MyPropertyInfo> myProperties = new List<MyPropertyInfo>();
            foreach (PropertyInfo info in type.GetProperties())
            {
                myProperties.Add(new MyPropertyInfo(info, info.MemberType, info.PropertyType.FullName, ((MemberInfo)(info)).Name));
            }
            myClass.PropertiesList = myProperties;

            List<MyConstructorInfo> myConstructors = new List<MyConstructorInfo>();
            foreach (ConstructorInfo info in type.GetConstructors())
            {
                string name = info.DeclaringType.FullName;

                List<MyParameterInfo> parameters = new List<MyParameterInfo>();
                foreach (ParameterInfo pParameter in info.GetParameters())
                {
                    parameters.Add(new MyParameterInfo(pParameter.ParameterType.Name, pParameter.Name));
                }

                myConstructors.Add(new MyConstructorInfo(info.MemberType, info, name, parameters));
            }
            myClass.ConstructorsList = myConstructors;

            List<MyMethodInfo> myMethods = new List<MyMethodInfo>();
            foreach (MethodInfo info in type.GetMethods())
            {
                string returntype = info.ReturnType.FullName;
                string name = info.Name;

                List<MyParameterInfo> parameters = new List<MyParameterInfo>();
                foreach (ParameterInfo pParameter in info.GetParameters())
                {
                    parameters.Add(new MyParameterInfo(pParameter.ParameterType.Name, pParameter.Name));
                }

                myMethods.Add(new MyMethodInfo(info.MemberType, info, returntype, name, parameters));
            }

            myClass.MethodsList = myMethods;

            List<MyEventInfo> myEvents = new List<MyEventInfo>();
            foreach (EventInfo info in type.GetEvents())
            {
                myEvents.Add(new MyEventInfo(info.MemberType, info, info.ToString()));
            }

            myClass.EventsList = myEvents;

            dgProperties.ItemsSource = myClass.PropertiesList;
            dgFields.ItemsSource = myClass.FieldsList;
            dgMethods.ItemsSource = myClass.MethodsList;
            dgConstructors.ItemsSource = myClass.ConstructorsList;
            dgEvents.ItemsSource = myClass.EventsList;
        }

        public static Type GetType(string typeName)
        {
            var type = Type.GetType(typeName);
            if (type != null) return type;
            foreach (var a in AppDomain.CurrentDomain.GetAssemblies())
            {
                type = a.GetType(typeName);
                if (type != null)
                    return type;
            }
            return null;
        }
    }
}