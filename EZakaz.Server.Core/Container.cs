// Copyright (C) 2005 - 2007 American College of Radiology
//

using System;
using Castle.Windsor;
using Castle.Windsor.Configuration;

namespace EZakaz.Server.Core
{
	public class Container
	{
		
		protected WindsorContainer container = new WindsorContainer();

		#region Constructors
		//public Container()
		//{
		//}

		//public Container(IConfigurationInterpreter interpreter)
		//    : base(interpreter)
		//{
		//}
		#endregion

		#region HelperMethods

		public void RegisterComponent<TService, TClass>()
		{
			Type serviceType = typeof(TService);
			container.AddComponent(serviceType.FullName, serviceType, typeof(TClass));
		}

		public void RegisterComponent<TClass>()
		{
			Type classType = typeof(TClass);
			container.AddComponent(classType.FullName, classType);
		}

		#endregion
	}
}