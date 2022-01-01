using System;
using System.Collections.ObjectModel;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;

namespace WPF_APP;

public partial class MainWindowViewModel : ObservableObject
{
    private string _newName = "";
    public RelayCommand AddNameCommand { get; set; }
    public string NewName { get => _newName; set => SetProperty(ref _newName, value); }
    public ObservableCollection<Human> Names { get; set; } = new();

    public MainWindowViewModel()
    {
        AddNameCommand = new(AddName);
    }


    public void AddName()
    {
        if (!string.IsNullOrWhiteSpace(NewName))
        {
            Names.Add(new() { Name = NewName });
            NewName = "";
        }
    }

}


public class Human
{
    public static Random ran = new(1);
    public string Name { get; set; }

    public string SocialSecurityNumber { get; set; }

    public Human()
    {

        uint x = 0;
        for (int i = 0; i < 9; i++)
        {
            x += x * 10 + (uint)ran.Next(0, 10);
        }

        SocialSecurityNumber = x.ToString("000-00-0000");
    }


}