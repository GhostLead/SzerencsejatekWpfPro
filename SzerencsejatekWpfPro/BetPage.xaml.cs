using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SzerencsejatekWpfPro
{
    /// <summary>
    /// Interaction logic for BetPage.xaml
    /// </summary>
    public partial class BetPage : Page
    {
        public BetPage()
        {
            InitializeComponent();
            AddCard("Forma1", "Első forma1 futam");
            AddCard("Foci", "Sokadik foci esemény");
            AddCard("Forma1", "Első forma1 futam");
            AddCard("Foci", "Sokadik foci esemény");
            AddCard("Forma1", "Első forma1 futam");
            AddCard("Foci", "Sokadik foci esemény");
            AddCard("Forma1", "Első forma1 futam");
            AddCard("Foci", "Sokadik foci esemény");
            AddCard("Forma1", "Első forma1 futam");
            AddCard("Foci", "Sokadik foci esemény");
            AddCard("Forma1", "Első forma1 futam");
            AddCard("Foci", "Sokadik foci esemény");
        }

        private void AddCard(string titleText, string descriptionText)
        {
            // Create a StackPanel to hold the labels and buttons
            StackPanel cardPanel = new StackPanel();
            cardPanel.Margin = new Thickness(10);
            cardPanel.Orientation = Orientation.Vertical;

            // Create and add the labels (title and description)
            Label titleLabel = new Label();
            titleLabel.Content = titleText;
            titleLabel.FontWeight = FontWeights.Bold;
            cardPanel.Children.Add(titleLabel);

            Label descriptionLabel = new Label();
            descriptionLabel.Content = descriptionText;
            cardPanel.Children.Add(descriptionLabel);

            // Create a StackPanel for buttons (so they appear next to each other)
            StackPanel buttonPanel = new StackPanel();
            buttonPanel.Orientation = Orientation.Horizontal;

            // Create and add the buttons
            Button button1 = new Button();
            button1.Content = "Action 1";
            button1.Margin = new Thickness(5);
            button1.Click += (s, e) => MessageBox.Show("Action 1 clicked!");
            buttonPanel.Children.Add(button1);

            Button button2 = new Button();
            button2.Content = "Action 2";
            button2.Margin = new Thickness(5);
            button2.Click += (s, e) => MessageBox.Show("Action 2 clicked!");
            buttonPanel.Children.Add(button2);

            // Add the button panel to the main card panel
            cardPanel.Children.Add(buttonPanel);

            // Finally, add the card panel to the StackPanel
            content.Children.Add(cardPanel);
        }
    }
}
