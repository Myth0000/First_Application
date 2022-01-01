using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;

namespace WPF_APP;

public partial class MainWindowViewModel : ObservableObject
{
    private string _newName = "";
    public RelayCommand AddNameCommand { get; set; }
    public string NewName { get => _newName; set { SetProperty(ref _newName, value); AddNameCommand.NotifyCanExecuteChanged(); } }

    public ObservableCollection<Human> Humans { get; set; } = new();

    public MainWindowViewModel()
    {
        AddNameCommand = new(AddName, CanAddName);
    }

    public bool CanAddName() => !string.IsNullOrWhiteSpace(NewName);

    public void AddName()
    {
        Humans.Add(new() { Name = NewName });
        NewName = "";
    }

}


public class Human
{
    private static readonly Random Ran = new(1);
    public string? Name { get; set; }
    public string SocialSecurityNumber { get; set; }

    public Human()
    {
        uint x = 0;
        for (var i = 0; i < 9; i++) { x += x * 10 + (uint)Ran.Next(0, 10); }
        SocialSecurityNumber = x.ToString("000-00-0000");
    }


}