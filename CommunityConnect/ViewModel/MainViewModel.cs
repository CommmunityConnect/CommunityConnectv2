﻿using CommunityConnect.model;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ObservableObject = CommunityToolkit.Mvvm.ComponentModel.ObservableObject;

namespace CommunityConnect.ViewModel
{
    public partial class MainViewModel : ObservableObject
    {

        // Properties
        [ObservableProperty]
        private string? searchQuery;

        [ObservableProperty]
        private string selectedCategory;

        [ObservableProperty]
        private string selectedSortOption;

        public ObservableCollection<string> Categories { get; } = new ObservableCollection<string>
        {
            "All", "Missing", "Wanted"
        };

        public ObservableCollection<string> SortOptions { get; } = new ObservableCollection<string>
        {
            "Name", "Age", "Date Reported"
        };

        public ObservableCollection<Person> Persons { get; } = new ObservableCollection<Person>
        {
            new Person { Name = "John Doe", Age = 25, Photo = "john_doe.png", Description = "Height: 5'10\", scar on forehead", LastSeenLocation = "Makanye", DateLastSeen = "2025-01-15", Status = "Critical" },
            new Person { Name = "Jane Smith", Age = 30, Photo = "jane_smith.png", Description = "Height: 5'6\", tattoo on right arm", WantedFor = "Robbery", Status = "High Risk" }
        };

        public ObservableCollection<Person> FilteredPersons { get; } = new ObservableCollection<Person>();

        // Constructor
        public MainViewModel()
        {
            selectedCategory = "All";
            selectedSortOption = "Name";

            // Initial filter
            FilterPersons();
        }

        // Filter and Sort Logic
        [RelayCommand]
        private void FilterPersons()
        {
            var filtered = Persons.AsEnumerable();

            // Apply category filter
            if (selectedCategory != "All")
            {
                if (selectedCategory == "Missing")
                    filtered = filtered.Where(p => string.IsNullOrEmpty(p.WantedFor));
                else if (selectedCategory == "Wanted")
                    filtered = filtered.Where(p => !string.IsNullOrEmpty(p.WantedFor));
            }

            // Apply search query filter
            if (!string.IsNullOrEmpty(searchQuery))
            {
                filtered = filtered.Where(p =>
                    (p.Name?.Contains(searchQuery, StringComparison.OrdinalIgnoreCase) ?? false) ||
                    (p.Description?.Contains(searchQuery, StringComparison.OrdinalIgnoreCase) ?? false) ||
                    (p.LastSeenLocation?.Contains(searchQuery, StringComparison.OrdinalIgnoreCase) ?? false));
            }

            // Apply sorting
            filtered = selectedSortOption switch
            {
                "Name" => filtered.OrderBy(p => p.Name),
                "Age" => filtered.OrderBy(p => p.Age),
                "Date Reported" => filtered.OrderBy(p => p.DateLastSeen),
                _ => filtered
            };

            // Update the filtered collection
            FilteredPersons.Clear();
            foreach (var person in filtered)
            {
                FilteredPersons.Add(person);
            }
        }

        // Command for the Contact Button
        [RelayCommand]
        private void Report(Person person)
        {
            // Handle reporting logic here
            // For now, display a simple message
            App.Current.MainPage.DisplayAlert("Report Information", $"Reporting {person.Name}", "OK");
        }
    }
}
