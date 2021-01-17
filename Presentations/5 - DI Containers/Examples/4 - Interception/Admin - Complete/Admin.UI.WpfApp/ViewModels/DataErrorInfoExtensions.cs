using System.ComponentModel;

namespace Admin.UI.WpfApp.ViewModels
{
    public static class DataErrorInfoExtensions
    {
        public static bool HasOverallError(this IDataErrorInfo that)
        {
            PropertyDescriptorCollection properties = TypeDescriptor.GetProperties(that);
            foreach (PropertyDescriptor property in properties)
            {
                if (!string.IsNullOrEmpty(that[property.Name]))
                {
                    return true;
                }
            }
            return false;
        }
    }
}
