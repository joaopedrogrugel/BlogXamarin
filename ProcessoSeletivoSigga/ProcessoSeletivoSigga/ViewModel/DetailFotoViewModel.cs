using ProcessoSeletivoSigga.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProcessoSeletivoSigga.ViewModel
{
  public class DetailFotoViewModel : ViewModelBase
  {
    public DetailFotoViewModel(Foto foto)
    {
      this.Imagem = foto.Imagem;
      this.Title = foto.Title;
    }

    #region Propriedades
    private byte[] _imagem;
    public byte[] Imagem
    {
      set
      {
        if (_imagem != value)
        {
          _imagem = value;
          OnPropertyChanged("Imagem");
        }
      }
      get
      {
        return _imagem;
      }
    }

    private string _title;
    public string Title
    {
      set
      {
        if (_title != value)
        {
          _title = value;
          OnPropertyChanged("Title");
        }
      }
      get
      {
        return _title;
      }
    }
    #endregion
  }
}
