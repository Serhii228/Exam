using API.DbOperations.Entities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Windows;


namespace Front
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        HttpClient client = new();
        public MainWindow()
        {
            
            InitializeComponent();
            var json =  client.GetStringAsync("https://localhost:5001/api/Tasks").Result;
            var list = JsonConvert.DeserializeObject<List<ProjectTaskEntity>>(json);
            UserGrid.ItemsSource = list;
            
        }

        private void UserGrid_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if(e.Key == System.Windows.Input.Key.Delete)
            {
                var task = UserGrid.SelectedItem as ProjectTaskEntity;
                if (task != null)
                {
                    HttpRequestMessage request = new HttpRequestMessage
                    {
                        Content = JsonContent.Create(task),
                        Method = HttpMethod.Delete,
                        RequestUri = new Uri("https://localhost:5001/api/Tasks", UriKind.Relative)
                    };
                    client.SendAsync(request).Wait();
                }
            }
        }

        private void UserGrid_AddingNewItem(object sender, System.Windows.Controls.AddingNewItemEventArgs e)
        {
            var task = UserGrid.SelectedItem as ProjectTaskEntity;
            if (task != null)
            {
                HttpRequestMessage request = new HttpRequestMessage
                {
                    Content = JsonContent.Create(task),
                    Method = HttpMethod.Post,
                    RequestUri = new Uri("https://localhost:5001/api/Tasks", UriKind.Relative)
                };
                client.SendAsync(request).Wait();
            }
        }
    }
}
