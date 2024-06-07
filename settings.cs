using System;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace BetterServer
{
    public partial class Settings : Form
    {
        private string configFilePath;

        public Settings()
        {
            InitializeComponent();
            configFilePath = Path.Combine(Application.StartupPath, "server", "server.properties");
            InitializeListView();
            LoadConfiguration();
        }

        private void InitializeListView()
        {
            listViewProperties.View = View.Details;
            listViewProperties.Columns.Add("Key", 150);
            listViewProperties.Columns.Add("Value", 300);
            listViewProperties.FullRowSelect = true;
            listViewProperties.GridLines = true;
            listViewProperties.MultiSelect = false;
            listViewProperties.SelectedIndexChanged += listViewProperties_SelectedIndexChanged; // Add event handler
        }

        private void LoadConfiguration()
        {
            listViewProperties.Items.Clear();
            if (!File.Exists(configFilePath))
            {
                MessageBox.Show("Configuration file not found!");
                return;
            }

            var lines = File.ReadAllLines(configFilePath);
            foreach (var line in lines)
            {
                if (!string.IsNullOrWhiteSpace(line) && line.Contains('='))
                {
                    var parts = line.Split('=');
                    var key = parts[0].Trim();
                    var value = parts[1].Trim();
                    var listViewItem = new ListViewItem(new[] { key, value });
                    listViewProperties.Items.Add(listViewItem);
                }
            }
        }

        private void SaveConfiguration()
        {
            try
            {
                var lines = listViewProperties.Items
                    .OfType<ListViewItem>()
                    .Select(item => $"{item.SubItems[0].Text}={item.SubItems[1].Text}")
                    .ToArray();
                File.WriteAllLines(configFilePath, lines);
                MessageBox.Show("Configuration has been saved successfully.");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to save the configuration file: {ex.Message}");
            }
        }

        private void listViewProperties_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listViewProperties.SelectedItems.Count > 0)
            {
                var selectedItem = listViewProperties.SelectedItems[0];
                textBoxKey.Text = selectedItem.SubItems[0].Text;
                textBoxValue.Text = selectedItem.SubItems[1].Text;
            }
        }

        private void buttonAddUpdate_Click_1(object sender, EventArgs e)
        {
            var key = textBoxKey.Text.Trim();
            var value = textBoxValue.Text.Trim();

            if (string.IsNullOrWhiteSpace(key))
            {
                MessageBox.Show("Key cannot be empty.");
                return;
            }

            // Search for an existing item with the same key
            ListViewItem existingItem = null;
            foreach (ListViewItem item in listViewProperties.Items)
            {
                if (item.SubItems[0].Text.Equals(key, StringComparison.OrdinalIgnoreCase))
                {
                    existingItem = item;
                    break;
                }
            }

            // If an existing item is found, update its value; otherwise, add a new item
            if (existingItem != null)
            {
                existingItem.SubItems[1].Text = value;
            }
            else
            {
                var newItem = new ListViewItem(new[] { key, value });
                listViewProperties.Items.Add(newItem);
            }

            SaveConfiguration();
        }
    }
}
