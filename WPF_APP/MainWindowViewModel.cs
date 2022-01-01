using System.Collections.ObjectModel;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;

namespace WPF_APP;

public class MainWindowViewModel : ObservableObject
{
    private string _newName = "";
    public RelayCommand AddNameCommand { get; set; }
    public string NewName { get => _newName; set => SetProperty(ref _newName, value); }
    public ObservableCollection<string> Names { get; set; } = new();

    public MainWindowViewModel()
    {
        AddNameCommand = new(AddName);
    }

    public void AddName()
    {
        if (!string.IsNullOrWhiteSpace(NewName))
        {
            Names.Add(NewName);
            NewName = "";
        }
    }

}