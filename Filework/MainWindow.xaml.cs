using System;
using System.Collections.Generic;
using System.IO;
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
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Scripting;
using Microsoft.CodeAnalysis.Scripting;
using Microsoft.Win32;
using Functions;

namespace Filework
{
    /// <summary>
    /// Interakční logika pro MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
      
        public MainWindow()
        {
            InitializeComponent();
            //script();
            

            var BaseItem = new item { itemName = "Paper", itemPrice = 1, itemStr = 0 };
            items IItems = new items();
            IItems.Inventory.Add(BaseItem);
            var player = new Player {Class = "Rogue",Strenght = 1, Agility = 2, Inteligence = 0, Health = 0, Inventory = IItems };
  
            script2(player);

        }



        private void btnOpenFile_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
                txtEditor.Text = File.ReadAllText(openFileDialog.FileName);
        }

        //async void script()
        //{
        //    string script = "int a = 2; int b = 14; a*b";
        //    var state = await CSharpScript.RunAsync<int>(script);
        //    label.Content = state.ReturnValue;
        //}




        async void script2(Player existingP) 
        {
            GPlayer GlobalP = new GPlayer();
            
            GlobalP.PPlayer = existingP;
            string code = "PPlayer.AddHealth(1); PPlayer.Add";
            var metadata = MetadataReference.CreateFromFile(GlobalP.GetType().Assembly.Location);
            
            await CSharpScript.RunAsync(code, options: ScriptOptions.Default.WithReferences(metadata).WithImports(GetType().Namespace), globals: GlobalP);
            check.Content = GlobalP.PPlayer.Health;

        }





    }
}
