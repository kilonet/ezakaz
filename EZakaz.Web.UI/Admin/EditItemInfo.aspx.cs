using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EZakaz.Dao;
using EZakaz.Domain;
using EZakaz.Server.Core;
using EZakaz.Server.Core.Presenters;
using EZakaz.Server.Core.Views;
using ItemInfo = EZakaz.Domain.ItemInfo;

namespace EZakaz.Web.UI.Admin
{
    public partial class EditItemInfo : AbstractPage<EditItemInfoPresenter>, IEditItemInfoView
    {
        private IItemDao itemDao = Repository.Default.Resolve<IItemDao>();
        private IItemInfoDao itemInfoDao = Repository.Default.Resolve<IItemInfoDao>();

        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            
            if (!IsPostBack)
            {
                if (!string.IsNullOrEmpty(getCurrentItemInfo().SmallImage))
                {
                    Image1.ImageUrl = ResolveUrl("~\\uploads\\" + getCurrentItemInfo().SmallImage);
                    HyperLink1.NavigateUrl = ResolveUrl("~\\uploads\\" + getCurrentItemInfo().Image);
                }
                Editor1.Content = getCurrentItemInfo().Description;
            }
        }

        protected override string PageTitle
        {
            get { return "Редактирование информации о товаре: " + GetCurrentItem().Name; }
        }

        protected void btnUpload_Click(object sender, EventArgs e)
        {
            long ticks = DateTime.Now.Ticks;
            string filePath = MapPath("~\\uploads\\") + ticks + ".jpg";
            string smallFilePath = MapPath("~\\uploads\\") + ticks + "_min.jpg";
            FileUpload1.PostedFile.SaveAs(filePath);
            ImageUtils.SaveImageToFile(ImageUtils.ResizeImage(filePath), smallFilePath);

            Domain.ItemInfo itemInfo = getCurrentItemInfo();

            if (!string.IsNullOrEmpty(itemInfo.Image))
            {
                File.Delete(MapPath("~\\uploads\\") + itemInfo.Image);
                File.Delete(MapPath("~\\uploads\\") + itemInfo.SmallImage);
                
            }
            
            itemInfo.Image = ticks + ".jpg";
            itemInfo.SmallImage = ticks + "_min.jpg";
            itemInfoDao.Save(itemInfo);

            Image1.ImageUrl = ResolveUrl("~\\uploads\\" + itemInfo.SmallImage);
            HyperLink1.NavigateUrl = ResolveUrl("~\\uploads\\" + itemInfo.Image);
        }

        public Item GetCurrentItem()
        {
            return itemDao.FindById(Presenter.IdParameter);
        }

        public Domain.ItemInfo getCurrentItemInfo()
        {
            return GetCurrentItem().ItemInfo;
        }

        protected void btnSaveDescription_Click(object sender, EventArgs e)
        {
            Domain.ItemInfo itemInfo = getCurrentItemInfo();
            itemInfo.Description = Editor1.Content;
            itemInfoDao.Save(itemInfo);
        }
    }
}
