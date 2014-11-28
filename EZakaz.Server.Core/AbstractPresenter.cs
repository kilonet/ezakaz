using System;
using System.Collections.Generic;
using System.Text;
using System.Web;
using System.Web.Security;
using Castle.Core;
using EZakaz.Domain;
using EZakaz.Server.Core.Web;
using EZakaz.Server.Core.Services;

namespace EZakaz.Server.Core
{
	[Transient]
    public abstract class AbstractPresenter<TView>: IPresenter where TView: IView
	{
		private TView view;
	    private IUserContext userContext = Repository.Default.Resolve<IUserContext>();
	    private User currentUser;
		
		public TView View
		{
			get { return view; }
        }

	    protected AbstractPresenter()
	    {
	        currentUser = userContext.CurentUser;
	    }

        //public bool IsShowNews
        //{
        //    get
        //    {
        //        if (currentUser == null) return false;
        //        //if (!currentUser.IsClient) return false;
        //        return NewsService.IsShowNews();
        //    }
        //}

		#region IPresenter Members

		public virtual void OnPreRender(EventArgs e)
		{
            //if (!Request.IsAuthenticated)
            //    FormsAuthentication.RedirectToLoginPage();
		}


	    public void AttachView(IView _view)
	    {
	        view = (TView)_view;
	    }


	    public HttpRequest Request
	    {
            get { return HttpContext.Current.Request; }
	    }

        public HttpResponse Response
        {
            get { return HttpContext.Current.Response; }
        }

	    #endregion

	    public IUserContext UserContext
	    {
	        set { userContext = value; }
            get { return userContext; }
	    }

	    public User CurrentUser
	    {
            get { return currentUser;  }
	    }

	    public int IdParameter
	    {
	        get
	        {
                if (Request.QueryString["id"] != null)
                {
                    int id;
                    if (int.TryParse(Request.QueryString["id"], out id))
                    {
                        return id;
                    }
                }
                return -1;
	        }
	    }
	}
}
