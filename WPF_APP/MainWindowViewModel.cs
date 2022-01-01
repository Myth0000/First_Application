using System;
using System.Collections.ObjectModel;
using System.Text;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;

namespace WPF_APP;

public partial class MainWindowViewModel : ObservableObject
{
    private string _newName = "";
    private Human _selectedHuman;
    public RelayCommand AddNameCommand { get; set; }
    public string NewName { get => _newName; set { SetProperty(ref _newName, value); AddNameCommand.NotifyCanExecuteChanged(); } }
    public ObservableCollection<Human> Humans { get; set; } = new();
    public Human SelectedHuman { get => _selectedHuman; set => SetProperty(ref _selectedHuman, value); }

    public MainWindowViewModel() => AddNameCommand = new(AddName, CanAddName);

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
    public BloodType BloodType { get; set; }

    public Human()
    {
        var sb = new StringBuilder();
        for (var i = 0; i < 9; i++)
        {
            sb.Append(Ran.Next(0, 9));
            if (i is 2 or 4) { sb.Append('-'); }
        }
        SocialSecurityNumber = sb.ToString();
        var values = Enum.GetValues(typeof(BloodType));
        BloodType = (BloodType)(values.GetValue(Ran.Next(values.Length)) ?? BloodType.Bloodless);
    }
}

public enum BloodType { Bloodless = 0, A = 1, B = 2, AB = 3, O = 4 }