using MauiApp3.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiApp3.Common.MVVM
{
    public class ViewService
    {
        private static Dictionary<Type, Type> registeredViews = new Dictionary<Type, Type>();
        private static Dictionary<ViewModelBase, Page> openedPages = new Dictionary<ViewModelBase, Page>();

        static ViewService()
        {
            registeredViews = new Dictionary<Type, Type>();
            openedPages = new Dictionary<ViewModelBase, Page>();
        }

        public static void RegisterView(Type viewModel, Type page)
        {
            registeredViews[viewModel] = page;
        }

        public static void ShowDialog(ViewModelBase viewModel, ViewModelBase parent = null)
        {
            Type pageType;

            if (registeredViews.TryGetValue(viewModel.GetType(), out pageType))
            {
                Page page = (Page)Activator.CreateInstance(pageType);

                if (page != null)
                {
                    page.BindingContext = viewModel;

                    openedPages[viewModel] = page;

                    // You can navigate to the page here, for example:
                    //App.Current.MainPage.Navigation.PushAsync(page);
                }
            }
        }

        public static void CloseDialog(ViewModelBase viewModel)
        {
            openedPages.Remove(viewModel);
        }

        public static void AddMainWindowToOpened(ViewModelBase viewModel, Page page)
        {
            if (viewModel != null && page != null)
            {
                openedPages[viewModel] = page;
            }
        }
    }
}
