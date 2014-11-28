// Copyright (C) 2005 - 2007 American College of Radiology
//

using System;
using System.Collections.Generic;
using System.Text;
using System.Web.Services.Protocols;

namespace EZakaz.WebService
{
    public class SessionManagerHelperSoapExtension : SoapExtension
    {
        public override void ProcessMessage(SoapMessage message)
        {
            switch (message.Stage)
            {
                case SoapMessageStage.BeforeSerialize:
                    if (message.Exception == null)
                    {
                        EZakaz.DaoImpl.NHibernateSessionManager.Instance.CommitTransaction();
                    }
                    else
                    {
                        EZakaz.DaoImpl.NHibernateSessionManager.Instance.RollbackTransaction();
                    }
                    break;
            }
        }

        public override object GetInitializer(Type serviceType)
        {
            return null;
        }

        public override object GetInitializer(LogicalMethodInfo methodInfo, SoapExtensionAttribute attribute)
        {
            return null;
        }

        public override void Initialize(object initializer)
        {
            
        }
    }
}