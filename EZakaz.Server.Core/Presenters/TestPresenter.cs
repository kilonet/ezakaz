using System;
using System.Collections.Generic;
using System.Text;
using EZakaz.Server.Core.Services;

namespace EZakaz.Server.Core.Presenters
{
    public class TestPresenter: AbstractPresenter<IView>
    {
        private TestService testService = Repository.Default.Resolve<TestService>();
        
        public void GenerateTestData()
        {
            testService.CreateTestData();
        }

        public void MarkOrdersRead()
        {
            testService.MarkSomeOrdersRead();
        }

		public void GenerateNonActiveUser()
		{
			testService.CreateTestUsers();
		}
	}
}
