using ProcessoSeletivoSigga.Business;
using ProcessoSeletivoSigga.Data;
using ProcessoSeletivoSigga.Services;
using System;
using System.IO;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace ProcessoSeletivoSigga
{
  public partial class App : Application
  {
    /// <summary>
    /// Verifica se o celular está online.
    /// </summary>
    public static bool IsOnline()
    {
      var current = Connectivity.NetworkAccess;
      return current == NetworkAccess.Internet;
    }

    /// <summary>
    /// Registra as Dependencias
    /// </summary>
    private void RegisterDependency()
    {
      DependencyService.Register<IDownloadImagem, DownloadImagem>();
      DependencyService.Register<IAlbumBusiness, AlbumBusiness>();
      DependencyService.Register<IFotoBusiness, FotoBusiness>();
    }

    public static string PathDataBase;
    public App()
    {
      InitializeComponent();
      PathDataBase = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "ProcessoS.db3");
      DataBaseFactory.CreateDataBase(PathDataBase);
      RegisterDependency();
      MainPage = new NavigationPage(new MainPageView());
    }
  }
}
