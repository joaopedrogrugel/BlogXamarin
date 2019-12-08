using System;
using System.IO;
using Xamarin.Forms;

namespace ProcessoSeletivoSigga.Converter
{
  /// <summary>
  /// Converte o byte[] em source, para a imagem ser exibida na tela corretamente, e funcionar de modo offline.
  /// </summary>
  public class ByteArrayToImageSourceConverter : IValueConverter
  {
    /// <summary>
    /// Convert.
    /// </summary>
    /// <param name="value">The value to convert.</param>
    /// <param name="targetType">The type to which to convert the value.</param>
    /// <param name="parameter">A parameter to use during the conversion.</param>
    /// <param name="culture">The culture to use during the conversion.</param>
    public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
    {
      ImageSource retSource = null;
      if (value != null)
      {
        byte[] imageAsBytes = (byte[])value;
        retSource = ImageSource.FromStream(() => new MemoryStream(imageAsBytes));
      }
      return retSource;
    }
    public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
    {
      throw new NotImplementedException();
    }
  }
}
