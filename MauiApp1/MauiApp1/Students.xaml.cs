using System.Collections.ObjectModel;
using MauiApp1.Models;

namespace MauiApp1;

public partial class Students : ContentPage
{
    ObservableCollection<Student> studentsCollection = new ObservableCollection<Student>();
    public ObservableCollection<Student> StudentsCollection { get { return studentsCollection; } }

    public Students()
    {
        InitializeComponent();
        BindingContext = this;
        LoadData();
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();

        //LoadData();
    }

    private void LoadData()
    {
        studentsCollection.Add(new Student { StudentId = 10, StudentFirstName = "Bob", StudentLastName = "Smith", StudentPercentage = 80.5 });
        studentsCollection.Add(new Student { StudentId = 25, StudentFirstName = "James", StudentLastName = "Brown", StudentPercentage = 77.9 });
        studentsCollection.Add(new Student { StudentId = 15, StudentFirstName = "Joe", StudentLastName = "Martin", StudentPercentage = 52.4 });
        studentsCollection.Add(new Student { StudentId = 12, StudentFirstName = "Dona", StudentLastName = "Taylor", StudentPercentage = 53.6 });
        studentsCollection.Add(new Student { StudentId = 18, StudentFirstName = "Peter", StudentLastName = "Brian", StudentPercentage = 90.9 });

        var orderedStudents = studentsCollection.OrderBy(student => student.StudentId);

        studentsCollectionView.ItemsSource = orderedStudents;
        //studentsCollectionView.SetBinding(ItemsView.ItemsSourceProperty, "StudentsCollection");

        studentsCollectionView.ItemTemplate = new DataTemplate(() =>
        {
            Label studentIdLabel = new Label
            {
                FontSize = 18,
                FontAttributes = FontAttributes.Bold,
                Margin = new Thickness(0, 0, 10, 0) // Add some right margin for spacing
            };
            studentIdLabel.SetBinding(Label.TextProperty, "StudentId");

            Label studentNameLabel = new Label
            {
                FontSize = 16,
                Margin = new Thickness(0, 0, 10, 0) // Add some right margin for spacing
            };
            studentNameLabel.SetBinding(Label.TextProperty, "StudentFirstName");

            Label studentLastNameLabel = new Label
            {
                FontSize = 16,
                Margin = new Thickness(0, 0, 10, 0) // Add some right margin for spacing
            };
            studentLastNameLabel.SetBinding(Label.TextProperty, "StudentLastName");

            Label studentPercentageLabel = new Label
            {
                FontSize = 16,
                FontAttributes = FontAttributes.Italic // Make it italic
            };
            studentPercentageLabel.SetBinding(Label.TextProperty, "StudentPercentage");

            // Use a grid for more precise layout control
            Grid grid = new Grid();
            grid.RowDefinitions.Add(new RowDefinition { Height = GridLength.Auto }); // Auto-sized row for flexibility

            // Add labels to the grid
            
            grid.Add(studentIdLabel, 0, 0); // Column 0, Row 0
            grid.Add(studentNameLabel, 1, 0); // Column 1, Row 0
            grid.Add(studentLastNameLabel, 2, 0); // Column 2, Row 0
            grid.Add(studentPercentageLabel, 3, 0); // Column 3, Row 0

            // Return the grid
            return grid;
        });


    }
}