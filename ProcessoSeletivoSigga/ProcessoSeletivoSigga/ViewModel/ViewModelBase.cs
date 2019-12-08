using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Xamarin.Forms;

namespace ProcessoSeletivoSigga.ViewModel
{
  /// <summary>
  /// ViewModel Base, criado para métodos serem reutilizados entre os viewmodels.
  /// </summary>
  public class ViewModelBase : INotifyPropertyChanged
  {
    #region Property 
    //Propriedades padrões do viewmode.
    public ICommand RefreshCommand { get; set; }

    private bool _isBusy;
    public bool IsBusy
    {
      get => _isBusy;
      set => SetProperty(ref _isBusy, value);
    }

    public event PropertyChangedEventHandler PropertyChanged;

    protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
    {
      PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    protected bool SetProperty<T>(ref T storage, T value, [CallerMemberName] string propertyName = null)
    {
      if (EqualityComparer<T>.Default.Equals(storage, value))
      {
        return false;
      }

      storage = value;
      OnPropertyChanged(propertyName);
      return true;
    }
    #endregion

    /// <summary>
    /// ViewModel Base, usado comando para quando o usuário atualizar a tela.
    /// </summary>
    public ViewModelBase()
    {
      RefreshCommand = new Command(s =>
      {
        //Método criado para que toda vez que o usuário "puxar" a lista para baixo, o sistema realize a atualização dos dados.
        LoadItens();
      });
    }

    /// <summary>
    /// Carrega os itens da listagem quando o usuário solicitar uma atualização puxando a listview para baixo.
    /// </summary>
    public virtual void LoadItens()
    {
      throw new NotImplementedException();
    }
  }
}
